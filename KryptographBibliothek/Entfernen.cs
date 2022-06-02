using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptographBibliothek
{
    public class Entfernen
    {

        public static string Remover(string Text, char zeichen)
        {

            Console.WriteLine(zeichen);
            Console.ReadKey();
     
        string NewString = Text.TrimEnd(zeichen);
        Console.WriteLine(NewString);
        Console.ReadKey();

        return NewString;
        }

    }
}
