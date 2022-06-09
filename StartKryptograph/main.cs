using System;
using System.Collections.Generic;
namespace StartKryptograph
{
    class main
    {
        static void Main(string[] args)
        {
            string chiffre = "Kly ulbl";



            Dictionary<String, double> tabelle_chiffre = new Dictionary<string, double>();



            tabelle_chiffre.Add("K", 1 / 7.0);
            tabelle_chiffre.Add("L", 3 / 7.0);
            tabelle_chiffre.Add("Y", 1 / 7.0);
            tabelle_chiffre.Add("U", 1 / 7.0);
            tabelle_chiffre.Add("B", 1 / 7.0);






            Dictionary<String, double> Tabelle = new Dictionary<string, double>();



            Tabelle.Add("A", 0.0558);
            Tabelle.Add("Ä", 0.0054);
            Tabelle.Add("B", 0.0196);
            Tabelle.Add("C", 0.0316);
            Tabelle.Add("D", 0.0498);
            Tabelle.Add("E", 0.1693);
            Tabelle.Add("F", 0.0149);
            Tabelle.Add("G", 0.0302);
            Tabelle.Add("H", 0.0498);
            Tabelle.Add("I", 0.0802);
            Tabelle.Add("J", 0.0024);
            Tabelle.Add("K", 0.0132);
            Tabelle.Add("L", 0.0360);
            Tabelle.Add("M", 0.0255);
            Tabelle.Add("N", 0.1053);
            Tabelle.Add("O", 0.0224);
            Tabelle.Add("Ö", 0.0030);
            Tabelle.Add("P", 0.0067);
            Tabelle.Add("Q", 0.0002);
            Tabelle.Add("R", 0.0689);
            Tabelle.Add("ß", 0.0037);
            Tabelle.Add("S", 0.0642);
            Tabelle.Add("T", 0.0579);
            Tabelle.Add("U", 0.0383);
            Tabelle.Add("Ü", 0.0065);
            Tabelle.Add("V", 0.0084);
            Tabelle.Add("W", 0.0178);
            Tabelle.Add("X", 0.0005);
            Tabelle.Add("Y", 0.0005);
            Tabelle.Add("Z", 0.0121);



            string text = KryptographBibliothek.ZeichenErsetzen.Ersetzen(chiffre, tabelle_chiffre, Tabelle);

        }
    }
}