using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1_2
{
    public static class Classificator
    {
        public static Classification[] GetClassification(Dictionary<Rodzaj, float> determinants, Owoc[] softSet)
        {
            List<Classification> c = new List<Classification>();
            foreach (Owoc s in softSet)
            {
                c.Add(new Classification
                {
                    Nazwa = s.Nazwa,
                    Rezultat = determinants.Select(dec => s.Rodzaj.HasFlag(dec.Key) ? dec.Value : 0).Sum()
                });
            }

            return c.ToArray();
        }

    }

    public class Classification
    {
        public String Nazwa { get; set; }

        public float Rezultat { get; set; }
    }
}
