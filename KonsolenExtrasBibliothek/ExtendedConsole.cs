using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;

namespace KonsolenExtrasBibliothek
{
    public class ExtendedConsole
    {
        private static CONSOLE_SCREEN_BUFFER_INFO_EX conScreBufInfo; // great variable naming
        private static CONSOLE_FONT_INFO_EX conFonInfo;
        private static SMALL_RECT _small_rect;
        private static int _width = 20, _height = 10;
        private const int genericWrite = -11;
        private static IntPtr outputHandle;
        private static bool errorFlag = false;
        private static List<string> errors = new();
        private static CHAR_INFO[] screenBuffer;

        static ExtendedConsole()
        {
            outputHandle = GetStdHandle(genericWrite);
            conScreBufInfo = new CONSOLE_SCREEN_BUFFER_INFO_EX();
            setup(_width, _height);
        }
        public static void setup(int width, int height) // width and height of the buffer thats going to be displaied
        {
            _width = width;
            _height = height;
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("width and/or height must me grater 0");
            }
            _small_rect = new SMALL_RECT(0, 0, (short)_width, (short)_height);
            screenBuffer = new CHAR_INFO[_width * _height];
        }
        public static void ajustWindow()
        {
            changeWindowSize((short)Console.BufferWidth, (short)Console.BufferHeight);
        }
        public static void changeWindowSize(short width, short height)
        {
            if (width < Console.LargestWindowWidth && height < Console.LargestWindowHeight && width > 0 && height > 0)
            {
#pragma warning disable
                Console.WindowHeight = height - 1;
                Console.WindowWidth = width;
#pragma warning enable
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static void WriteRect(SMALL_RECT startToEnd, string text) // if if lower and or right are -1 func writes until \n
        {
            int bottom = Console.BufferHeight;
            int right = Console.BufferWidth;
            //out of bounce chacking?
            if (startToEnd.Bottom == -1 ||startToEnd.Right == -1) // write until the \n
            {
                for (int x = startToEnd.Left; x < startToEnd.Right;x++ )
                {
                    for (int y = startToEnd.Top; y < startToEnd.Bottom;y++ )
                    {

                        screenBuffer[ConvertTo1D(x,y)] = ;
                    }
                }
            }
            else // just writes in the buffer 
            {

            }
        }
        public static void displayFrame(CHAR_INFO[] input)
        {
            if (errorFlag)
            {
                return;
            }
            if (!WriteConsoleOutput(outputHandle, input, new COORD((short)_width, (short)_height), new COORD(0, 0), ref _small_rect))
            {
                errorFlag = true;
                errors.Add(Marshal.GetLastWin32Error().ToString());
                Console.WriteLine("Latest Win32Error: " + errors[errors.Count - 1]);
            }
        }
        public static int ConvertTo1D(int x, int y)
        {
            return y * _width + x;
        }
        public static List<string> getAllErrors()
        {
            return errors;
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetConsoleScreenBufferInfoEx(
        IntPtr hConsoleOutput,
        ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleScreenBufferInfoEx(
        IntPtr ConsoleOutput,
        ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfoEx
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)] //this has done the trick
        private static extern bool WriteConsoleOutput(
        IntPtr hConsoleOutput,
        CHAR_INFO[] lpBuffer,
        COORD dwBufferSize,
        COORD dwBufferCoord,
        ref SMALL_RECT lpWriteRegion
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        extern static bool GetCurrentConsoleFontEx(
        IntPtr hConsoleOutput,
        bool bMaximumWindow,
        ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFont);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
        IntPtr ConsoleOutput,
        bool MaximumWindow,
        ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx);

    }

    public enum NewColors // we dont need more colors 9, are enough
    {
        black = 0,
        yellow = 1,
        lightBlue = 2,
        red = 3,
        green = 4,
        orange = 5,
        pink = 6,
        purple = 8,
        white = 15
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_FONT_INFO_EX
    {
        public int cbSize;
        public int FontIndex;
        public short FontWidth;
        public short FontHeight;
        public int FontFamily;
        public int FontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        public uint ColorDWORD;

        public COLORREF(Color color)
        {
            ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
        }
        public COLORREF(uint color)
        {
            ColorDWORD = color;
        }
        public COLORREF(uint r, uint g, uint b)
        {
            ColorDWORD = r + (g << 8) + (b << 16);
        }

        internal Color GetColor()
        {
            return Color.FromArgb((int)(0x000000FFU & ColorDWORD),
                                  (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
        }

        internal void SetColor(Color color)
        {
            ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_SCREEN_BUFFER_INFO_EX
    {
        public int cbSize;
        public COORD dwSize;
        public COORD dwCursorPosition;
        public ushort wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;

        public ushort wPopupAttributes;
        public bool bFullscreenSupported;

        public COLORREF black;
        public COLORREF darkBlue;
        public COLORREF darkGreen;
        public COLORREF darkCyan;
        public COLORREF darkRed;
        public COLORREF darkMagenta;
        public COLORREF darkYellow;
        public COLORREF gray;
        public COLORREF darkGray;
        public COLORREF blue;
        public COLORREF green;
        public COLORREF cyan;
        public COLORREF red;
        public COLORREF magenta;
        public COLORREF yellow;
        public COLORREF white;
    }
    public struct SMALL_RECT
    {
        public SMALL_RECT(short Left, short Top, short Right, short Bottom)
        {
            this.Left = Left;
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
        }
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        public short X;
        public short Y;

        public COORD(short X, short Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)] //encoding seems to make problems
    public struct CHAR_INFO
    {
        [FieldOffset(0)]
        public char UnicodeChar;
        [FieldOffset(0)]
        public char AsciiChar;
        [FieldOffset(2)] //2 bytes seems to work properly
        public UInt16 Attributes;
    }
}
