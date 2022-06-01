using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptographBibliothek
{
     public class Class1
     {



        public static double CountChar(char[] Wort, char b)
        {
            int count = 0;
            for (int i = 0;i< Wort.Length;i++)
            {
                if (Wort[i] == b) 
                    count++;
                
            }
            //return count;
            return count/(double)Wort.Length*100;
        }
        public static Dictionary<char,double> Counter(string input)
        {
            char[] s1 = input.ToLower().ToCharArray();
            double c;
            string zeichen = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, double> output = new();
            for (int i = 0; i < zeichen.Length; i++)
            {
                c = CountChar(s1, zeichen[i]);
                //Console.WriteLine(zeichen[i] + ": " + c);

                if (c > 0)
                {

                    output.Add(zeichen[i], c);

                }
                   
             
             
            }
             return output;
        
        }
     
     
     }
}
