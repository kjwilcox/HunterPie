﻿using System;

using System.Runtime.InteropServices;

namespace HunterPie.Core {
    public class KeyboardHookHelper {
        public enum KeyboardKeys{
            None = 0,
            LButton = 1,
            RButton = 2,
            Cancel = 3,
            MButton = 4,
            XButton1 = 5,
            XButton2 = 6,
            Back = 8,
            Tab = 9,
            LineFeed = 10,
            Clear = 12,
            Enter = 13,
            Return = 13,
            ShiftKey = 16,
            ControlKey = 17,
            Menu = 18,
            Pause = 19,
            CapsLock = 20,
            Capital = 20,
            HangulMode = 21,
            HanguelMode = 21,
            KanaMode = 21,
            JunjaMode = 23,
            FinalMode = 24,
            KanjiMode = 25,
            HanjaMode = 25,
            Escape = 27,
            IMEConvert = 28,
            IMENonconvert = 29,
            IMEAccept = 30,
            IMEAceept = 30,
            IMEModeChange = 31,
            Space = 32,
            Prior = 33,
            PageUp = 33,
            PageDown = 34,
            Next = 34,
            End = 35,
            Home = 36,
            Left = 37,
            Up = 38,
            Right = 39,
            Down = 40,
            Select = 41,
            Print = 42,
            Execute = 43,
            Snapshot = 44,
            PrintScreen = 44,
            Insert = 45,
            Delete = 46,
            Help = 47,
            D0 = 48,
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57,
            A = 65,
            B = 66,
            C = 67,
            D = 68,
            E = 69,
            F = 70,
            G = 71,
            H = 72,
            I = 73,
            J = 74,
            K = 75,
            L = 76,
            M = 77,
            N = 78,
            O = 79,
            P = 80,
            Q = 81,
            R = 82,
            S = 83,
            T = 84,
            U = 85,
            V = 86,
            W = 87,
            X = 88,
            Y = 89,
            Z = 90,
            LWin = 91,
            RWin = 92,
            Apps = 93,
            Sleep = 95,
            NumPad0 = 96,
            NumPad1 = 97,
            NumPad2 = 98,
            NumPad3 = 99,
            NumPad4 = 100,
            NumPad5 = 101,
            NumPad6 = 102,
            NumPad7 = 103,
            NumPad8 = 104,
            NumPad9 = 105,
            Multiply = 106,
            Add = 107,
            Separator = 108,
            Subtract = 109,
            Decimal = 110,
            Divide = 111,
            F1 = 112,
            F2 = 113,
            F3 = 114,
            F4 = 115,
            F5 = 116,
            F6 = 117,
            F7 = 118,
            F8 = 119,
            F9 = 120,
            F10 = 121,
            F11 = 122,
            F12 = 123,
            F13 = 124,
            F14 = 125,
            F15 = 126,
            F16 = 127,
            F17 = 128,
            F18 = 129,
            F19 = 130,
            F20 = 131,
            F21 = 132,
            F22 = 133,
            F23 = 134,
            F24 = 135,
            NumLock = 144,
            Scroll = 145,
            LShiftKey = 160,
            RShiftKey = 161,
            LControlKey = 162,
            RControlKey = 163,
            LMenu = 164,
            RMenu = 165,
            BrowserBack = 166,
            BrowserForward = 167,
            BrowserRefresh = 168,
            BrowserStop = 169,
            BrowserSearch = 170,
            BrowserFavorites = 171,
            BrowserHome = 172,
            VolumeMute = 173,
            VolumeDown = 174,
            VolumeUp = 175,
            MediaNextTrack = 176,
            MediaPreviousTrack = 177,
            MediaStop = 178,
            MediaPlayPause = 179,
            LaunchMail = 180,
            SelectMedia = 181,
            LaunchApplication1 = 182,
            LaunchApplication2 = 183,
            OemSemicolon = 186,
            Oem1 = 186,
            Oemplus = 187,
            Oemcomma = 188,
            OemMinus = 189,
            OemPeriod = 190,
            Oem2 = 191,
            OemQuestion = 191,
            Oem3 = 192,
            Oemtilde = 192,
            Oem4 = 219,
            OemOpenBrackets = 219,
            OemPipe = 220,
            Oem5 = 220,
            OemCloseBrackets = 221,
            Oem6 = 221,
            OemQuotes = 222,
            Oem7 = 222,
            Oem8 = 223,
            Oem102 = 226,
            OemBackslash = 226,
            ProcessKey = 229,
            Packet = 231,
            Attn = 246,
            Crsel = 247,
            Exsel = 248,
            EraseEof = 249,
            Play = 250,
            Zoom = 251,
            NoName = 252,
            Pa1 = 253,
            OemClear = 254,
            KeyCode = 65535,
            Shift = 65536,
            Control = 131072,
            Alt = 262144,
            Modifiers = -65536
        }
        /*
         Deals with the keyboard
        */
        public static readonly int  WH_KEYBOARD_LL = 0xD;

        public enum KeyboardMessage {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105
        }

        public static KeyboardKeys GetKeyboardKeyByID(int id) {
            return (KeyboardKeys)Enum.Parse(typeof(KeyboardKeys), id.ToString());
        }

        public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    }
    public class KeyboardHook {
        [StructLayout(LayoutKind.Sequential)]
        internal struct KeyboardLowLevelHookStruct {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        KeyboardHookHelper.HookProc KeyboardProc;
        public event EventHandler<KeyboardInputEventArgs> OnKeyboardKeyPress;

        public IntPtr KeyboardHk { get; private set; } = IntPtr.Zero;

        public KeyboardHook() {
            KeyboardProc = LowLevelKeyboardProc;
        }
        
        private IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0) {
                var st = Marshal.PtrToStructure<KeyboardLowLevelHookStruct>(lParam);
                OnKeyboardKeyPress?.Invoke(this, new KeyboardInputEventArgs(st.vkCode, (KeyboardHookHelper.KeyboardMessage)wParam));
            }
            return KeyboardHookHelper.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public void InstallHooks() {
            if (KeyboardHk == IntPtr.Zero) {
                KeyboardHk = KeyboardHookHelper.SetWindowsHookEx(KeyboardHookHelper.WH_KEYBOARD_LL, KeyboardProc, IntPtr.Zero, 0);
            }
        }

        public void UninstallHooks() {
            KeyboardHookHelper.UnhookWindowsHookEx(KeyboardHk);
        }
    }
}
