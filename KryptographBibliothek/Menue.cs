using System;
using Figgle;
using ExtendedWinConsole;

namespace KryptographBibliothek
{
    public class Menue
    {
        public static void HauptMenue()
        {   
            ExConsole.SetFont(10, 20);
            short width = 100, height = 25;
            ExConsole.SetMaximumBufferSize(width, height);
            ExConsole.SetBufferSize(width, height);
            ExConsole.SetWindowSize(width, height+2, true); // set window size is a bit buggy therefor the +2
            ExConsole.SetCursorVisiblity(false);

            string title = "Kryptograph";
            int space = ExConsole.Width/2-(title.Length/2);
            for (int i = 0; i < space; i++)
            {
                ExConsole.Write(' ');
            }
            ExConsole.WriteLine(title, (ushort)ConsoleColor.Green);
            ExConsole.Write("\nIn diesem Kryptographen wird die ");
            ExConsole.Write("Substitution ", (ushort)ConsoleColor.Red);
            ExConsole.WriteLine("benutzt.");
            for (int i = 0; i < ExConsole.Width; i++)
            {
                ExConsole.Write(' ');
            }
            //to be added functionality



            ExConsole.ReadLine();
            
        }
    }
}
