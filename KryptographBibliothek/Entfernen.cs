using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptographBibliothek
{
    public class Entfernen
    {

        public static string Remover(string Text, string zeichen)
        {

            Text = Text.Replace(zeichen, "") ;

            return Text;
        }

    }
}
