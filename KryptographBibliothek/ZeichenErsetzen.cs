using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace KryptographBibliothek
{
    public class ZeichenErsetzen
    {
        public static string Ersetzen(string chiffre, Dictionary<String, double> tabelle_chiffre, Dictionary<String, double> tabelle_sprache)
        {



            {





                chiffre = chiffre.ToUpper();
                var tabelle_sprache_sorted = from entry in tabelle_sprache orderby entry.Value descending select entry;
                var tabelle_chiffre_sorted = from entry in tabelle_chiffre orderby entry.Value ascending select entry;



                tabelle_sprache = tabelle_sprache.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);
                tabelle_chiffre = tabelle_chiffre.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);



                StringBuilder ch = new StringBuilder(chiffre);




                int index = 0;
                for (int i = 0; i < chiffre.Length; i++)
                {
                    for (int r = 0; r < tabelle_chiffre.Count; r++)
                    {
                        if (tabelle_chiffre.Keys.ElementAt(r) == chiffre[i].ToString())




                            index = r;





                    }



                    ch[i] = tabelle_sprache.Keys.ElementAt(index).ToCharArray()[0];

                }




                Console.WriteLine(ch.ToString());
                return ch.ToString();
            }
        }
    }
}