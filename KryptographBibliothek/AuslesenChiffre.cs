using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace KryptographBibliothek
{
    public class AuslesenChiffre
    {
        public static void Auslesen()
        {
            Console.WriteLine("Gib den Pfad der Chiffre an.");
            string Chiffre = Console.ReadLine();

            string Ausgabe = File.ReadAllText(Chiffre);
            Console.WriteLine("{0}",Ausgabe);
            Console.ReadLine();

        }
    }
}

