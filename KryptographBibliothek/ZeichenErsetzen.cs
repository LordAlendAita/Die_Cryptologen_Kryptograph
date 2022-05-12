using System.Collections.Generic;

namespace KryptographBibliothek
{
    public class ZeichenErsetzen
    {
        public static void Ersetzen()
        {
            string Chiffre = "Kly ulbl";
            //Alle Zeichen  7
            // K -> 0.1428
            // L -> 0.4285
            // Y -> 0.1428
            // U -> 0.1428
            // B -> 0.1428

            Dictionary<string, double> tabelle_wahrscheinlichkeiten = new Dictionary<string, double>();

            tabelle_wahrscheinlichkeiten.Add("A", 0.0558);
            tabelle_wahrscheinlichkeiten.Add("Ä", 0.0054);
            tabelle_wahrscheinlichkeiten.Add("B", 0.0196);
            tabelle_wahrscheinlichkeiten.Add("C", 0.0316);
            tabelle_wahrscheinlichkeiten.Add("D", 0.0498);
            tabelle_wahrscheinlichkeiten.Add("E", 0.1693);
            tabelle_wahrscheinlichkeiten.Add("F", 0.0149);
            tabelle_wahrscheinlichkeiten.Add("G", 0.0302);
            tabelle_wahrscheinlichkeiten.Add("H", 0.0498);
            tabelle_wahrscheinlichkeiten.Add("I", 0.0802);
            tabelle_wahrscheinlichkeiten.Add("J", 0.0024);
            tabelle_wahrscheinlichkeiten.Add("K", 0.0132);
            tabelle_wahrscheinlichkeiten.Add("L", 0.0360);
            tabelle_wahrscheinlichkeiten.Add("M", 0.0255);
            tabelle_wahrscheinlichkeiten.Add("N", 0.1053);
            tabelle_wahrscheinlichkeiten.Add("O", 0.0224);
            tabelle_wahrscheinlichkeiten.Add("Ö", 0.0030);
            tabelle_wahrscheinlichkeiten.Add("P", 0.0067);
            tabelle_wahrscheinlichkeiten.Add("Q", 0.0002);
            tabelle_wahrscheinlichkeiten.Add("R", 0.0689);
            tabelle_wahrscheinlichkeiten.Add("ß", 0.0037);
            tabelle_wahrscheinlichkeiten.Add("S", 0.0642);
            tabelle_wahrscheinlichkeiten.Add("T", 0.0579);
            tabelle_wahrscheinlichkeiten.Add("U", 0.0383);
            tabelle_wahrscheinlichkeiten.Add("Ü", 0.0065);
            tabelle_wahrscheinlichkeiten.Add("V", 0.0084);
            tabelle_wahrscheinlichkeiten.Add("W", 0.0178);
            tabelle_wahrscheinlichkeiten.Add("X", 0.0005);
            tabelle_wahrscheinlichkeiten.Add("Y", 0.0005);
            tabelle_wahrscheinlichkeiten.Add("Z", 0.0121);

            Dictionary<string, double> tabelle_chiffre = new Dictionary<string, double>();

            tabelle_chiffre.Add("K", 0.1428);
            tabelle_chiffre.Add("L", 0.4285);
            tabelle_chiffre.Add("Y", 0.1428);
            tabelle_chiffre.Add("U", 0.1428);
            tabelle_chiffre.Add("B", 0.1428);

        }
    }
}