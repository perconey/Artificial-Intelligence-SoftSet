using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1_2
{
    class Program
    {
        private static Dictionary<Rodzaj, float> Decisions = new Dictionary<Rodzaj, float>();

        private static Owoc[] DostepneSpodnie = null;

        static void Main(string[] args)
        {
            Console.WriteLine(@"
   Oto dostępne parametry owoców:
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
      
  Podaj numery tych, które Cię interesują wraz z procentową wartością wagową stosując się do szablonu:
  Przykładowo: ""1:30,8:40,512:50"" oznacza, że interesują Cię owoce Swieze w 30%, Slodkie w 40%, Bulwowe w 50%
                ");

            String input = Console.ReadLine();

            Decisions = input.Split(',').Select(dec => new KeyValuePair<Rodzaj, float>((Rodzaj)float.Parse(dec.Split(':')[0]), float.Parse(dec.Split(':')[1]) / 100)).ToDictionary(kv => kv.Key, kv => kv.Value);

            DostepneSpodnie = new Owoc[]
            {
                new Owoc("Owoc1", Rodzaj.Bulwowe | Rodzaj.Czerwone | Rodzaj.Mrozone | Rodzaj.Lisciaste),
                new Owoc("Owoc2", Rodzaj.Bulwowe | Rodzaj.Lokalne | Rodzaj.Zielone),
                new Owoc("Owoc3", Rodzaj.Lokalne | Rodzaj.Mrozone | Rodzaj.Czerwone),
                new Owoc("Owoc4", Rodzaj.Bulwowe | Rodzaj.Tropikalne | Rodzaj.Ostre),
                new Owoc("Owoc5", Rodzaj.Ostre | Rodzaj.Zielone | Rodzaj.Czerwone),
                new Owoc("Owoc6", Rodzaj.Bulwowe | Rodzaj.Czerwone | Rodzaj.Ostre | Rodzaj.Mrozone | Rodzaj.Lisciaste),
                new Owoc("Owoc7", Rodzaj.Slodkie | Rodzaj.Swieze | Rodzaj.Czerwone),
                new Owoc("Owoc8", Rodzaj.Ostre | Rodzaj.Zielone | Rodzaj.Tropikalne | Rodzaj.Bulwowe)
            };

            Classification[] classifications = Classificator.GetClassification(Decisions, DostepneSpodnie);

            Console.WriteLine("Według podjętych decyzji, klasyfikator przedstawia następujące rezultaty dla poszczególnych owoców:");
            foreach (Classification cls in classifications)
                Console.WriteLine($"Owoc o nazwie {cls.Nazwa} -> {cls.Rezultat}");

            float max = classifications.Max(c => c.Rezultat);
            Console.WriteLine("Owoc/owoce, które najbardziej spełniają wybrane parametry to: ");
            foreach (Classification c in classifications)
                if (c.Rezultat == max)
                    Console.WriteLine(c.Nazwa);

            float mostOptimisticResult = Decisions.Sum(dec => dec.Value);
            Console.WriteLine($"Maksymalny rezultat klasyfikacji dla podjętych decyzji wynosi {mostOptimisticResult}");
            IEnumerable<Classification> mostOptimisticClassifications = classifications.Where(c => c.Rezultat == mostOptimisticResult);
            if (mostOptimisticClassifications.Any())
            {
                Console.WriteLine("I te owoce wpasowują się w niego w pełni: ");
                foreach (Classification c in mostOptimisticClassifications)
                    Console.WriteLine(c.Nazwa);
            }
            else
                Console.WriteLine("Lecz żaden owoc nie pasuje do niego w pełni");

            Console.WriteLine("Koniec działania programu");
            Console.ReadLine();
        }
    }
}
