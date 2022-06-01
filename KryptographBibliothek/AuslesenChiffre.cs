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
            static void Main(string[] args)
            {

                string Chiffre = File.ReadAllText("C:\\Users\\karim.l3\\source\\repos\\Die_Cryptologen_Kryptograph\\Chiffre.txt");
                Console.WriteLine("{0}", Chiffre);

                //string Chiffre = File.ReadAllText(@"Chiffre.txt");
                //Console.WriteLine("{0}", Chiffre);


                //TextReader tr = new StreamReader(@"Chiffre.txt");
                //string myText = tr.ReadLine();


            }
        }
    }
}

