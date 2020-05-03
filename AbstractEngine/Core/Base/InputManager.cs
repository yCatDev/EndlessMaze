using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AbstractEngine.Core.Base
{   
    public enum VirtualKeys : ushort
            {
                LeftButton = 0x01,
                RightButton = 0x02,
                Cancel = 0x03,
                MiddleButton = 0x04,
                ExtraButton1 = 0x05,
                ExtraButton2 = 0x06,
                Back = 0x08,
                Tab = 0x09,
                Clear = 0x0C,
                Return = 0x0D,
                Shift = 0x10,
                Control = 0x11,
                /// <summary></summary>
                Menu = 0x12,
                /// <summary></summary>
                Pause = 0x13,
                /// <summary></summary>
                CapsLock = 0x14,
                /// <summary></summary>
                Kana = 0x15,
                /// <summary></summary>
                Hangeul = 0x15,
                /// <summary></summary>
                Hangul = 0x15,
                /// <summary></summary>
                Junja = 0x17,
                /// <summary></summary>
                Final = 0x18,
                /// <summary></summary>
                Hanja = 0x19,
                /// <summary></summary>
                Kanji = 0x19,
                /// <summary></summary>
                Escape = 0x1B,
                /// <summary></summary>
                Convert = 0x1C,
                /// <summary></summary>
                NonConvert = 0x1D,
                /// <summary></summary>
                Accept = 0x1E,
                /// <summary></summary>
                ModeChange = 0x1F,
                /// <summary></summary>
                Space = 0x20,
                /// <summary></summary>
                Prior = 0x21,
                /// <summary></summary>
                Next = 0x22,
                /// <summary></summary>
                End = 0x23,
                /// <summary></summary>
                Home = 0x24,
                /// <summary></summary>
                Left = 0x25,
                /// <summary></summary>
                Up = 0x26,
                /// <summary></summary>
                Right = 0x27,
                /// <summary></summary>
                Down = 0x28,
                /// <summary></summary>
                Select = 0x29,
                /// <summary></summary>
                Print = 0x2A,
                /// <summary></summary>
                Execute = 0x2B,
                /// <summary></summary>
                Snapshot = 0x2C,
                /// <summary></summary>
                Insert = 0x2D,
                /// <summary></summary>
                Delete = 0x2E,
                /// <summary></summary>
                Help = 0x2F,
                /// <summary></summary>
                N0 = 0x30,
                /// <summary></summary>
                N1 = 0x31,
                /// <summary></summary>
                N2 = 0x32,
                /// <summary></summary>
                N3 = 0x33,
                /// <summary></summary>
                N4 = 0x34,
                /// <summary></summary>
                N5 = 0x35,
                /// <summary></summary>
                N6 = 0x36,
                /// <summary></summary>
                N7 = 0x37,
                /// <summary></summary>
                N8 = 0x38,
                /// <summary></summary>
                N9 = 0x39,
                /// <summary></summary>
                A = 0x41,
                /// <summary></summary>
                B = 0x42,
                /// <summary></summary>
                C = 0x43,
                /// <summary></summary>
                D = 0x44,
                /// <summary></summary>
                E = 0x45,
                /// <summary></summary>
                F = 0x46,
                /// <summary></summary>
                G = 0x47,
                /// <summary></summary>
                H = 0x48,
                /// <summary></summary>
                I = 0x49,
                /// <summary></summary>
                J = 0x4A,
                /// <summary></summary>
                K = 0x4B,
                /// <summary></summary>
                L = 0x4C,
                /// <summary></summary>
                M = 0x4D,
                /// <summary></summary>
                N = 0x4E,
                /// <summary></summary>
                O = 0x4F,
                /// <summary></summary>
                P = 0x50,
                /// <summary></summary>
                Q = 0x51,
                /// <summary></summary>
                R = 0x52,
                /// <summary></summary>
                S = 0x53,
                /// <summary></summary>
                T = 0x54,
                /// <summary></summary>
                U = 0x55,
                /// <summary></summary>
                V = 0x56,
                /// <summary></summary>
                W = 0x57,
                /// <summary></summary>
                X = 0x58,
                /// <summary></summary>
                Y = 0x59,
                /// <summary></summary>
                Z = 0x5A,
                /// <summary></summary>
                LeftWindows = 0x5B,
                /// <summary></summary>
                RightWindows = 0x5C,
                /// <summary></summary>
                Application = 0x5D,
                /// <summary></summary>
                Sleep = 0x5F,
                /// <summary></summary>
                Numpad0 = 0x60,
                /// <summary></summary>
                Numpad1 = 0x61,
                /// <summary></summary>
                Numpad2 = 0x62,
                /// <summary></summary>
                Numpad3 = 0x63,
                /// <summary></summary>
                Numpad4 = 0x64,
                /// <summary></summary>
                Numpad5 = 0x65,
                /// <summary></summary>
                Numpad6 = 0x66,
                /// <summary></summary>
                Numpad7 = 0x67,
                /// <summary></summary>
                Numpad8 = 0x68,
                /// <summary></summary>
                Numpad9 = 0x69,
                /// <summary></summary>
                Multiply = 0x6A,
                /// <summary></summary>
                Add = 0x6B,
                /// <summary></summary>
                Separator = 0x6C,
                /// <summary></summary>
                Subtract = 0x6D,
                /// <summary></summary>
                Decimal = 0x6E,
                /// <summary></summary>
                Divide = 0x6F,
                /// <summary></summary>
                F1 = 0x70,
                /// <summary></summary>
                F2 = 0x71,
                /// <summary></summary>
                F3 = 0x72,
                /// <summary></summary>
                F4 = 0x73,
                /// <summary></summary>
                F5 = 0x74,
                /// <summary></summary>
                F6 = 0x75,
                /// <summary></summary>
                F7 = 0x76,
                /// <summary></summary>
                F8 = 0x77,
                /// <summary></summary>
                F9 = 0x78,
                /// <summary></summary>
                F10 = 0x79,
                /// <summary></summary>
                F11 = 0x7A,
                /// <summary></summary>
                F12 = 0x7B,
                /// <summary></summary>
                F13 = 0x7C,
                /// <summary></summary>
                F14 = 0x7D,
                /// <summary></summary>
                F15 = 0x7E,
                /// <summary></summary>
                F16 = 0x7F,
                /// <summary></summary>
                F17 = 0x80,
                /// <summary></summary>
                F18 = 0x81,
                /// <summary></summary>
                F19 = 0x82,
                /// <summary></summary>
                F20 = 0x83,
                /// <summary></summary>
                F21 = 0x84,
                /// <summary></summary>
                F22 = 0x85,
                /// <summary></summary>
                F23 = 0x86,
                /// <summary></summary>
                F24 = 0x87,
                /// <summary></summary>
                NumLock = 0x90,
                /// <summary></summary>
                ScrollLock = 0x91,
                /// <summary></summary>
                NEC_Equal = 0x92,
                /// <summary></summary>
                Fujitsu_Jisho = 0x92,
                /// <summary></summary>
                Fujitsu_Masshou = 0x93,
                /// <summary></summary>
                Fujitsu_Touroku = 0x94,
                /// <summary></summary>
                Fujitsu_Loya = 0x95,
                /// <summary></summary>
                Fujitsu_Roya = 0x96,
                /// <summary></summary>
                LeftShift = 0xA0,
                /// <summary></summary>
                RightShift = 0xA1,
                /// <summary></summary>
                LeftControl = 0xA2,
                /// <summary></summary>
                RightControl = 0xA3,
                /// <summary></summary>
                LeftMenu = 0xA4,
                /// <summary></summary>
                RightMenu = 0xA5,
                /// <summary></summary>
                BrowserBack = 0xA6,
                /// <summary></summary>
                BrowserForward = 0xA7,
                /// <summary></summary>
                BrowserRefresh = 0xA8,
                /// <summary></summary>
                BrowserStop = 0xA9,
                /// <summary></summary>
                BrowserSearch = 0xAA,
                /// <summary></summary>
                BrowserFavorites = 0xAB,
                /// <summary></summary>
                BrowserHome = 0xAC,
                /// <summary></summary>
                VolumeMute = 0xAD,
                /// <summary></summary>
                VolumeDown = 0xAE,
                /// <summary></summary>
                VolumeUp = 0xAF,
                /// <summary></summary>
                MediaNextTrack = 0xB0,
                /// <summary></summary>
                MediaPrevTrack = 0xB1,
                /// <summary></summary>
                MediaStop = 0xB2,
                /// <summary></summary>
                MediaPlayPause = 0xB3,
                /// <summary></summary>
                LaunchMail = 0xB4,
                /// <summary></summary>
                LaunchMediaSelect = 0xB5,
                /// <summary></summary>
                LaunchApplication1 = 0xB6,
                /// <summary></summary>
                LaunchApplication2 = 0xB7,
                /// <summary></summary>
                OEM1 = 0xBA,
                /// <summary></summary>
                OEMPlus = 0xBB,
                /// <summary></summary>
                OEMComma = 0xBC,
                /// <summary></summary>
                OEMMinus = 0xBD,
                /// <summary></summary>
                OEMPeriod = 0xBE,
                /// <summary></summary>
                OEM2 = 0xBF,
                /// <summary></summary>
                OEM3 = 0xC0,
                /// <summary></summary>
                OEM4 = 0xDB,
                /// <summary></summary>
                OEM5 = 0xDC,
                /// <summary></summary>
                OEM6 = 0xDD,
                /// <summary></summary>
                OEM7 = 0xDE,
                /// <summary></summary>
                OEM8 = 0xDF,
                /// <summary></summary>
                OEMAX = 0xE1,
                /// <summary></summary>
                OEM102 = 0xE2,
                /// <summary></summary>
                ICOHelp = 0xE3,
                /// <summary></summary>
                ICO00 = 0xE4,
                /// <summary></summary>
                ProcessKey = 0xE5,
                /// <summary></summary>
                ICOClear = 0xE6,
                /// <summary></summary>
                Packet = 0xE7,
                /// <summary></summary>
                OEMReset = 0xE9,
                /// <summary></summary>
                OEMJump = 0xEA,
                /// <summary></summary>
                OEMPA1 = 0xEB,
                /// <summary></summary>
                OEMPA2 = 0xEC,
                /// <summary></summary>
                OEMPA3 = 0xED,
                /// <summary></summary>
                OEMWSCtrl = 0xEE,
                /// <summary></summary>
                OEMCUSel = 0xEF,
                /// <summary></summary>
                OEMATTN = 0xF0,
                /// <summary></summary>
                OEMFinish = 0xF1,
                /// <summary></summary>
                OEMCopy = 0xF2,
                /// <summary></summary>
                OEMAuto = 0xF3,
                /// <summary></summary>
                OEMENLW = 0xF4,
                /// <summary></summary>
                OEMBackTab = 0xF5,
                /// <summary></summary>
                ATTN = 0xF6,
                /// <summary></summary>
                CRSel = 0xF7,
                /// <summary></summary>
                EXSel = 0xF8,
                /// <summary></summary>
                EREOF = 0xF9,
                /// <summary></summary>
                Play = 0xFA,
                /// <summary></summary>
                Zoom = 0xFB,
                /// <summary></summary>
                Noname = 0xFC,
                /// <summary></summary>
                PA1 = 0xFD,
                /// <summary></summary>
                OEMClear = 0xFE
            }
    public static class InputManger
    {
        private static GlobalKeyboardHook _globalKeyboardHook;
        public static VirtualKeys _keyDown = VirtualKeys.Noname, _keyUp= VirtualKeys.Noname, _keyPress= VirtualKeys.Noname;
        private static bool IsNewKey;
        
        public static void RegisterInput()
        {
            
            _globalKeyboardHook = new GlobalKeyboardHook();
           
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private static void OnKeyPressed(object? sender, GlobalKeyboardHookEventArgs e)
        {
            
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                if (IsNewKey)
                {
                    _keyDown = _keyPress = e.KeyboardData.Key;
                    IsNewKey = false;
                }
            }else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                _keyUp = e.KeyboardData.Key;
                _keyPress = VirtualKeys.Noname;
                IsNewKey = true;
            }
        }

        public static bool OnKeyDown(VirtualKeys key)
        {
            if (_keyDown == key)
            {
                _keyDown = VirtualKeys.Noname;
                return true;
            }
            
            return false;
        }
        
        public static bool OnKeyUp(VirtualKeys key)
        {
            if (_keyUp == key)
            {
                _keyUp = VirtualKeys.Noname;
                return true;
            }
            
            return false;
        }
        
        public static bool OnKeyPress(VirtualKeys key)
        {
            if (_keyPress == key)
            {
                return true;
            }
            
            return false;
        }
        
    }
    
    /// <summary>
    /// Hook class around keyboard input
    /// </summary>
    internal class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }
        public GlobalKeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

        public GlobalKeyboardHookEventArgs(
            GlobalKeyboardHook.LowLevelKeyboardInputEvent keyboardData,
            GlobalKeyboardHook.KeyboardState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }
    }

    //Based on https://gist.github.com/Stasonix
    internal class GlobalKeyboardHook : IDisposable
    {
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

        public GlobalKeyboardHook()
        {
            _windowsHookHandle = IntPtr.Zero;
            _user32LibraryHandle = IntPtr.Zero;
            _hookProc = LowLevelKeyboardProc;
            _user32LibraryHandle = LoadLibrary("User32"); // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.
            

            
            if (_user32LibraryHandle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }

            _windowsHookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, _user32LibraryHandle,0);
            if (_windowsHookHandle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
           
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // because we can unhook only in the same thread, not in garbage collector thread
                if (_windowsHookHandle != IntPtr.Zero)
                {
                    if (!UnhookWindowsHookEx(_windowsHookHandle))
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                    }
                    _windowsHookHandle = IntPtr.Zero;

                    // ReSharper disable once DelegateSubtraction
                    _hookProc -= LowLevelKeyboardProc;
                }
            }

            if (_user32LibraryHandle != IntPtr.Zero)
            {
                if (!FreeLibrary(_user32LibraryHandle)) // reduces reference to library by 1.
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _user32LibraryHandle = IntPtr.Zero;
            }
        }

        ~GlobalKeyboardHook()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IntPtr _windowsHookHandle;
        private IntPtr _user32LibraryHandle;
        private IntPtr _callNext;
        private HookProc _hookProc;

        delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        /// The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events. These events are
        /// associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">hook type</param>
        /// <param name="lpfn">hook procedure</param>
        /// <param name="hMod">handle to application instance</param>
        /// <param name="dwThreadId">thread identifier</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        /// <summary>
        /// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">handle to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        /// <summary>
        /// The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hHook">handle to current hook</param>
        /// <param name="code">hook code passed to hook procedure</param>
        /// <param name="wParam">value passed to hook procedure</param>
        /// <param name="lParam">value passed to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct LowLevelKeyboardInputEvent
        {
            /// <summary>
            /// A virtual-key code. The code must be a value in the range 1 to 254.
            /// </summary>
            public VirtualKeys Key {get=>(VirtualKeys) VirtualCode;}
            private int VirtualCode;

            /// <summary>
            /// A hardware scan code for the key. 
            /// </summary>
            public int HardwareScanCode;

            /// <summary>
            /// The extended-key flag, event-injected Flags, context code, and transition-state flag. This member is specified as follows. An application can use the following values to test the keystroke Flags. Testing LLKHF_INJECTED (bit 4) will tell you whether the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
            /// </summary>
            public int Flags;

            /// <summary>
            /// The time stamp stamp for this message, equivalent to what GetMessageTime would return for this message.
            /// </summary>
            public int TimeStamp;

            /// <summary>
            /// Additional information associated with the message. 
            /// </summary>
            public IntPtr AdditionalInformation;
        }

        public const int WH_KEYBOARD_LL = 13;
        //const int HC_ACTION = 0;

        public enum KeyboardState
        {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SysKeyDown = 0x0104,
            SysKeyUp = 0x0105
        }

        
        public IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
           
            bool fEatKeyStroke = false;
            
            var wparamTyped = wParam.ToInt32();
            
            if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
            {
                object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                LowLevelKeyboardInputEvent p = (LowLevelKeyboardInputEvent)o;

                var eventArguments = new GlobalKeyboardHookEventArgs(p, (KeyboardState)wparamTyped);

                EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
                handler?.Invoke(this, eventArguments);

                fEatKeyStroke = eventArguments.Handled;
            }

            if (fEatKeyStroke)
                return (IntPtr) 1;
             
            _callNext= CallNextHookEx(_windowsHookHandle, nCode, wParam, lParam);
            return _callNext;
        }
    }
}
