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
            //ExConsole.WriteLine();
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

            ExConsole.Write("In diesem Kryptographen wird die ");
            ExConsole.Write(" Substitution ", (ushort)ConsoleColor.Red);
            ExConsole.WriteLine("benutzt.");
            Thread.Sleep(500);
            ExConsole.WriteLine("Geben Sie den Pfad zur verschlüsselten Datei ein:");
            string chipheredFile, fileNotFound = "Datei konnte nicht gefunden werde. Drück eine taste und probier es nochmal";
            chipheredFile = ExConsole.ReadLine();
            while (!File.Exists(chipheredFile)) // a bug where pressing Enter resaults in a new line the doesnt get removed again
            {
                ExConsole.WriteLine(fileNotFound);
                ExConsole.ReadKey();
                for ( int i = 0; i < (chipheredFile.Replace(' ', '_').Length+fileNotFound.Replace(' ', '_').Length-11); i++) 
                {
                    Thread.Sleep(50);
                    ExConsole.Remove();
                }
                ExConsole.Remove();
                //ExConsole.Write(chipheredFile.Length + fileNotFound.Length);
                chipheredFile = ExConsole.ReadLine();
            }
            ExConsole.WriteLine("worked");

            ExConsole.ReadLine();
            
        }
        public static void Testing() // purely for debuging 
        {
            ExConsole.SetFont(10, 20);
            short width = 100, height = 26;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize((short)(width + 1), height);
            ExConsole.SetWindowSize(width, height + 3, true); // set window size is a bit buggy therefor the +2
            ExConsole.SetCursorVisiblity(false);
            for (int i = 0; i < 10; i++)
                if (i % 10 != 0)
                    ExConsole.Write(i % 10, 3);
                else
                    ExConsole.Write(' ');
            ExConsole.Write('\n');
            ExConsole.ReadKey();
            for (int i = 0; i < 10; i++)
            {
                ExConsole.Remove(false);
                Thread.Sleep(200);
            }

            ExConsole.ReadKey(true);
        }
    }
}
