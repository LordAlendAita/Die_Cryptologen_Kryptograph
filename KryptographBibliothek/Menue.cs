using System;
using Figgle;
using ExtendedWinConsole;
using System.IO;
using System.Threading;

namespace KryptographBibliothek
{
    public class Menue
    {
        private static void CenterText(string text, ConsoleColor color = ConsoleColor.White)
        {
            if (ExConsole.Width < text.Length)
            {
                throw new ArgumentException("CenterText: text size must be smaler than width");
            }
            for (int i = 0; i < (ExConsole.Width / 2 - (text.Length / 2)); i++)
            {
                ExConsole.Write(' ');
            }
            ExConsole.WriteLine(text, (ushort)color);
        }
        private static void VerticalLine(char c = '\u2500', ConsoleColor color = ConsoleColor.White)
        {
            for (int i = 0; i < ExConsole.Width-1; i++)
            {
                ExConsole.Write(c,(ushort)color); 
            }
            ExConsole.WriteLine();
        }
        public static void HauptMenue()
        {   
            ExConsole.SetFont(10, 20);
            short width = 100, height = 26;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize((short)(width+1), height);
            ExConsole.SetWindowSize(width, height+2, true); // set window size is a bit buggy therefor the +2
            ExConsole.SetCursorVisiblity(false);

            //for (int i = 0; i < 100; i++)
            //    ExConsole.Write(i % 10);
            ExConsole.WriteLine();
            CenterText("Kryptograph", ConsoleColor.Green);
            ExConsole.WriteLine();
            VerticalLine('\u2500',ConsoleColor.DarkGray);

            ExConsole.Write("\nIn diesem Kryptographen wird die ");
            ExConsole.Write(" Substitution ", (ushort)ConsoleColor.Red);
            ExConsole.WriteLine("benutzt.");

            ExConsole.WriteLine("Geben Sie den Pfad zur verschlüsselten Datei ein:");
            string chipheredFile, fileNotFound = "Datei konnte nicht gefunden werde. Probier es nochmal.";
            chipheredFile = ExConsole.ReadLine();
            while (!File.Exists(chipheredFile))
            {
                ExConsole.WriteLine(fileNotFound);
                //Thread.Sleep(1000);
                for ( int i = 0; i < (chipheredFile.Length+fileNotFound.Length)-4; i++)
                {
                    Thread.Sleep(100);
                    ExConsole.Remove();
                }
                chipheredFile = ExConsole.ReadLine();
            }
           

            ExConsole.ReadLine();
            
        }
        public static void Testing()
        {
            ExConsole.SetFont(10, 20);
            short width = 100, height = 25;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize(width, height);
            ExConsole.SetWindowSize(width, height + 2, true); // set window size is a bit buggy therefor the +2
            ExConsole.SetCursorVisiblity(false);
            ExConsole.Write("abcdef", 3);
            //Thread.Sleep(500);
            //ExConsole.Write("ABC");
            ExConsole.ReadLine();
        }
    }
}
