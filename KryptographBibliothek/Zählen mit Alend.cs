using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptographBibliothek
{
    public class Class1
    {
        public static object CountChar;

        public static char[] Kürzen(char[] Wort)
        {
            if (Wort is null)
            {
                throw new ArgumentNullException(nameof(Wort));
            }
        }

        public static int CountChar(char[] Wort, char b)
        {
            int count = 0;
            foreach (char v in Wort)
            {
                if (v == b) count = count + 1;
                return count;
            }
        }
        public static void Counter(string[] args)
        {
            char[] s1 = "Ananas".ToCharArray();
            int c;
           
            for (char b = ' ';b< 256;b++)
            {
                c = CountChar(s1, b);
                Console.WriteLine(b + ": " + c);


            }


        }
    

    }
}
