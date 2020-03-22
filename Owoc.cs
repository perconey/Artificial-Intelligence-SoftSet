using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1_2
{
    public class Owoc
    {
        public String Nazwa { get; set; }

        public Rodzaj Rodzaj { get; set; }

        public Owoc(String nazwa, Rodzaj rodzaj)
        {
            Nazwa = nazwa;
            Rodzaj = rodzaj;
        }
    }

    [Flags]
    public enum Rodzaj
    {
        Swieze = 1,
        Mrozone = 2,
        Ostre = 4,
        Slodkie = 8,
        Zielone = 16,
        Czerwone = 32,
        Lokalne = 64,
        Tropikalne = 128,
        Lisciaste = 256,
        Bulwowe = 512
    }
}
