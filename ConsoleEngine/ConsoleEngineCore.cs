using System;
using System.Runtime.InteropServices;
using System.Threading;
using AbstractEngine.Core;
using AbstractEngine.Core.Base;

namespace ConsoleEngine
{
    public class ConsoleEngine : AbstractCore
    {
        public ConsoleEngine(int w, int h, uint fontSize, string title) : base(w, h, title)
        {
            Console.CursorVisible = false;
            Console.Title = title;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w + 1, h);

            //DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);

            var stdHandle = GetStdHandle(-11);
            var bufferInfo = new ConsoleScreenBufferInfoEx();
            bufferInfo.cbSize = (uint) Marshal.SizeOf(bufferInfo);
            GetConsoleScreenBufferInfoEx(stdHandle, ref bufferInfo);
            ++bufferInfo.srWindow.Right;
            ++bufferInfo.srWindow.Bottom;
            SetConsoleScreenBufferInfoEx(stdHandle, ref bufferInfo);

            SetFont((short) fontSize);

            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => { SetFont(16); };
        }

        protected override void OnRenderStart()
        {
            Console.CursorVisible = false;
        }

        protected override void OnRenderObject(Cell cell, Point cellPos)
        {
            if (!cell.Updated) return;
            Console.SetCursorPosition(cellPos.X, cellPos.Y);
            Console.ForegroundColor = cell.GetColor<ConsoleColor>();
            Console.BackgroundColor = (ConsoleColor) ClearColor;
            if (cell.GetRenderObject<char>(out var res))
                Console.Write(res);
            else
                Console.Write(' ');

            cell.Updated = false;
        }

        protected override void OnRenderEnd()
        {
            var waitThread = new Thread(() => Thread.Sleep(10));
            waitThread.Start();
            waitThread.Join();
        }

        protected override void OnDrawTextSymbol(char c, Point nextPos, Color textColor)
        {
            var d = new CellData
            {
                RenderObject = new RenderObject(c),
                Color = textColor
            };
            DrawPrimitive(d, nextPos);
        }


        #region WinAPI

        //Fix size
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;

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
        private struct Coord
        {
            public readonly short X;
            public readonly short Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public readonly short Left;
            public readonly short Top;
            public short Right, Bottom;

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
            public readonly Coord dwSize;
            public readonly Coord dwCursorPosition;
            public readonly short wAttributes;
            public SmallRect srWindow;
            public readonly Coord dwMaximumWindowSize;
            public readonly ushort wPopupAttributes;
            public readonly bool bFullscreenSupported;

            public readonly Colorref black;
            public readonly Colorref darkBlue;
            public readonly Colorref darkGreen;
            public readonly Colorref darkCyan;
            public readonly Colorref darkRed;
            public readonly Colorref darkMagenta;
            public readonly Colorref darkYellow;
            public readonly Colorref gray;
            public readonly Colorref darkGray;
            public readonly Colorref blue;
            public readonly Colorref green;
            public readonly Colorref cyan;
            public readonly Colorref red;
            public readonly Colorref magenta;
            public readonly Colorref yellow;
            public readonly Colorref white;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Colorref
        {
            public readonly uint ColorDWORD;
        }

        //Fix fonts

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [StructLayout(LayoutKind.Sequential)]
        private unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal readonly uint nFont;
            internal Coord dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }

        private unsafe void SetFont(short size)
        {
            const string fontName = "MS Gothic";
            var hnd = GetStdHandle(STD_OUTPUT_HANDLE);
            if (hnd == INVALID_HANDLE_VALUE) return;
            var info = new CONSOLE_FONT_INFO_EX();
            info.cbSize = (uint) Marshal.SizeOf(info);
            if (!GetCurrentConsoleFontEx(hnd, false, ref info)) return;
            var newInfo = new CONSOLE_FONT_INFO_EX();
            newInfo.cbSize = (uint) Marshal.SizeOf(newInfo);
            newInfo.FontFamily = TMPF_TRUETYPE;
            var ptr = new IntPtr(newInfo.FaceName);
            Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);
            newInfo.dwFontSize = new Coord(size, size);
            newInfo.FontWeight = info.FontWeight;
            SetCurrentConsoleFontEx(hnd, false, newInfo);
        }

        #endregion
    }
}