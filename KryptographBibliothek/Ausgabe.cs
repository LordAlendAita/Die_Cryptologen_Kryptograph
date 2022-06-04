using System;

namespace KryptographBibliothek
{
    public class ZeichenAusgabe
    {
        public static void ausgabe() // ccode für ayyoub eingefügt
        {
            string chiffre = "Kly, ";
            string klartext = ("Das, ");

            Console.WriteLine("Ihr Chiffrierter text");

            for (int i = 0; i < chiffre.Length; i++)
            {
                if (chiffre[i] != klartext[i])
                {
                    Console.BackgroundColor = ConsoleColor.Red;

                    Console.Write(chiffre[i]);

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write(chiffre[i]);
                }
            }

            Console.WriteLine("\nIhr Dechiffrierter Text");
            Console.WriteLine(klartext);

        }
    }
}
