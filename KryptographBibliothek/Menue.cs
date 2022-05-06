using System;
using Figgle;
using KonsolenExtrasBibliothek;

namespace KryptographBibliothek
{
    public class Menue
    {
        public static void HauptMenue()
        {
            Console.Clear();
            Console.Title = "Substitutons-Dechiffrierer - Cryptologen";

            string willkommen = FiggleFonts.Standard.Render("Willkommen zum Dechiffrirer");
            int length = willkommen.IndexOf('\n') + 1;
            
            Console.WriteLine();
        }
    }
}
