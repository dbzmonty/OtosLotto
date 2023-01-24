using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtosLotto
{
    class Program
    {
        public static List<int> GolyokGombjeFeltolto()
        {
            List<int> GolyokGombje = new List<int>();
            for (int i = 0; i < 90; i++)
            {
                GolyokGombje.Add(i + 1);
            }

            return GolyokGombje;
        }

        public static int[] Sorsolo(List<int> innenSorsolunk)
        {
            Random r = new Random();
            int[] sorsolt = new int[5];
            for (int i = 0; i < sorsolt.Length; i++)
            {
                int aktualisanSorsoltIndex = r.Next(0, innenSorsolunk.Count);
                sorsolt[i] = innenSorsolunk[aktualisanSorsoltIndex];
                innenSorsolunk.RemoveAt(aktualisanSorsoltIndex);
            }

            Array.Sort(sorsolt);

            return sorsolt;
        }

        public static List<int> JatekosSzamaiBekero()
        {
            List<int> JatekosSzamai = new List<int>();
            do
            {
                Console.WriteLine("Kérem a {0}. számot: ", JatekosSzamai.Count + 1);

                int jatekosSzama;
                bool validSzam = int.TryParse(Console.ReadLine(), out jatekosSzama);

                if (validSzam && 0 < jatekosSzama && jatekosSzama < 91)
                {
                    if (!JatekosSzamai.Contains(jatekosSzama))
                        JatekosSzamai.Add(jatekosSzama);
                    else
                    {
                        Console.WriteLine("Ezt a számot már kiválasztottad!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Érvénytelen szám!");
                    continue;
                }
            }
            while (JatekosSzamai.Count < 5);

            JatekosSzamai.Sort();

            return JatekosSzamai;
        }

        public static List<int> TalalatokMegszamlalasa(int[] sorsolt, List<int> JatekosSzamai)
        {
            List<int> nyertesSzamok = new List<int>();

            foreach (int jatekosSzama in JatekosSzamai)
            {
                if (sorsolt.Contains(jatekosSzama))
                    nyertesSzamok.Add(jatekosSzama);
            }

            return nyertesSzamok;
        }

        public static void Kiiras(int[] Sorsolt, List<int> JatekosSzamai, List<int> Talalatok)
        {
            Console.WriteLine();
            Console.WriteLine("A kisorsolt számok:");
            for (int i = 0; i < Sorsolt.Length; i++)
            {
                if (i == Sorsolt.Length - 1)
                    Console.Write(Sorsolt[i]);
                else
                    Console.Write(Sorsolt[i] + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("A játékos számai:");
            for (int i = 0; i < JatekosSzamai.Count; i++)
            {
                if (i == JatekosSzamai.Count - 1)
                    Console.Write(JatekosSzamai[i]);
                else
                    Console.Write(JatekosSzamai[i] + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();

            if (0 < Talalatok.Count)
            {
                Console.WriteLine("A találatok:");
                for (int i = 0; i < Talalatok.Count; i++)
                {
                    if (i == Talalatok.Count -1)
                        Console.Write(Talalatok[i]);
                    else
                        Console.Write(Talalatok[i] + ", ");
                }
            }
            else
            {
                Console.WriteLine("Sajnos nincs találat :(");
            }
        }

        static void Main(string[] args)
        {
            // Feltöltesz egy gömböt (listát) a 90 nyerőszámmal
            List<int> GolyokGombje = GolyokGombjeFeltolto();

            // Kisorsoljuk a nyerőszámokat
            int[] Sorsolt = Sorsolo(GolyokGombje);

            // Bekérem az 5 számot a játékostól
            List<int> JatekosSzamai = JatekosSzamaiBekero();

            // Találatok megszámlálása
            List<int> Talalatok = TalalatokMegszamlalasa(Sorsolt, JatekosSzamai);

            // Kiírom a számokat
            Kiiras(Sorsolt, JatekosSzamai, Talalatok);
            
            Console.ReadKey();
        }
    }
}
