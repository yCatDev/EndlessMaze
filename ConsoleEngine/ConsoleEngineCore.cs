using System;
using System.Runtime.InteropServices;
using System.Threading;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;


namespace ConsoleEngine 
{
    public class ConsoleEngine: AbstractCore
    {
        public ConsoleEngine(int w, int h, string title) : base(w, h, title)
        {
            Console.CursorVisible = false;
            Console.Title = title;
            Console.SetWindowSize(w,h);
            Console.SetBufferSize(w+1,h);
            
            //DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
            
            IntPtr stdHandle = GetStdHandle(-11);
            ConsoleScreenBufferInfoEx bufferInfo = new ConsoleScreenBufferInfoEx();
            bufferInfo.cbSize = (uint)Marshal.SizeOf(bufferInfo);
            GetConsoleScreenBufferInfoEx(stdHandle, ref bufferInfo);
            ++bufferInfo.srWindow.Right;
            ++bufferInfo.srWindow.Bottom;
            SetConsoleScreenBufferInfoEx(stdHandle, ref bufferInfo);
            
            SetFont();
        }
        
        protected override void OnRenderStart()
        {
            Console.CursorVisible = false;
        }

        protected override void OnRenderObject(Cell cell, Point cellPos)
        {
            Console.SetCursorPosition(cellPos.X, cellPos.Y);
            Console.ForegroundColor = cell.GetColor<ConsoleColor>();
            Console.BackgroundColor = (ConsoleColor) _clearColor;
            //Console.WriteLine(cellPos.ToString());
            if (cell.GetRenderObject<char>(out var res))
                Console.Write(res);
            else
            {
                Console.Write(' ');
            }
        }

        protected override void OnRenderEnd()
        {
            Thread waitThread = new Thread(() =>Thread.Sleep(10));
            waitThread.Start();                    
            waitThread.Join();
        }

        public override void DrawPrimitive(CellData data, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(data);
        }

        public override void DrawPrimitive(RenderObject renderObject, Point cellPos)
        {
            GameGrid[cellPos] = new Cell(renderObject);
        }

        public override void OnDrawTextSymbol(char c, Point nextPos, Color textColor)
        {
            var d = new CellData()
            {
                RenderObject = new RenderObject(c),
                Color = textColor
            };
            DrawPrimitive(d,nextPos);
        }

        
        
        #region WinAPI
        //Fix size
        const int MF_BYCOMMAND = 0x00000000;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        //Fix console buffer
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleScreenBufferInfoEx(
            IntPtr hConsoleOutput,
            ref ConsoleScreenBufferInfoEx ConsoleScreenBufferInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleScreenBufferInfoEx(
            IntPtr hConsoleOutput,
            ref ConsoleScreenBufferInfoEx ConsoleScreenBufferInfoEx);
        
        
        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X, Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left, Top, Right, Bottom;

            public SmallRect(short width, short height)
            {
                Left = Top = 0;
                Right = width;
                Bottom = height;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct ConsoleScreenBufferInfoEx
        {
            public uint cbSize;
            public Coord dwSize;
            public Coord dwCursorPosition;
            public short wAttributes;
            public SmallRect srWindow;
            public Coord dwMaximumWindowSize;
            public ushort wPopupAttributes;
            public bool bFullscreenSupported;

            public Colorref black, darkBlue, darkGreen, darkCyan, darkRed, darkMagenta, darkYellow, gray, darkGray, blue, green, cyan, red, magenta, yellow, white;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Colorref
        {
            public uint ColorDWORD;
        }
        
        //Fix fonts

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool GetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [StructLayout(LayoutKind.Sequential)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal Coord dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }

        public unsafe void SetFont()
        {
            string fontName = "MS Gothic";
            IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
            if (hnd != INVALID_HANDLE_VALUE) {
                CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                info.cbSize = (uint) Marshal.SizeOf(info);
                bool tt = false;
                // First determine whether there's already a TrueType font.
                if (GetCurrentConsoleFontEx(hnd, false, ref info)) {
                    // Set console font to Lucida Console.
                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint) Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);
                    // Get some settings from current font.
                    newInfo.dwFontSize = new Coord(24, 24);
                    newInfo.FontWeight = info.FontWeight;
                    SetCurrentConsoleFontEx(hnd, false, newInfo);
                }
            }
        }
        
        #endregion
    }
}