using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuální_projekt__jaro_2021
{
    class Klient : Osoba
    {
        public double Vaha { get; set; }
        public int Vek { get; set; }
        public double Vyska { get; set; }

        public Klient (string jmeno, string prijmeni, int telefon, double vaha, int vek, double vyska) :base (jmeno, prijmeni, telefon)
        {
            //Jmeno = jmeno;
            //Prijmeni = prijmeni;
            //Telefon = telefon;
            Vaha = vaha;
            Vek = vek;
            Vyska = vyska;
        }

        public void DetailyKlienta()
        {
            Console.WriteLine("Jméno: " + Jmeno + ", " + "Příjmení: " + Prijmeni + ", " + "Telefonní číslo: " + Telefon.ToString() + "\n" +
                 "Váha: " + Vaha.ToString() + ", " + "Věk: " + Vek.ToString() + ", " + "Výška: " + Vyska.ToString());
            Console.WriteLine();
        }

        public double VypocetBMI(double vaha, double vyska)
        {
            double BMI = vaha / (vyska * vyska) * 10000;
            return BMI;
        }

        public double VypocetBMR(double vaha, double vyska, int vek)
        {
            Console.Write("Je muž nebo žena? zapiš písmeno M nebo Z\n");
            string pohlavi = Console.ReadLine();

            double muzBMR = 0;
            double zenaBMR = 0;

            if (pohlavi.ToLower() == "m")
            {
                muzBMR = (66.5 + (13.75 * vaha) + (5.003 * vyska) - (6.755 * vek));
                return muzBMR;
            }

            else if (pohlavi.ToLower() == "z")
            {
                zenaBMR = (655 + (9.563 * vaha) + (1.850 * vyska) - (4.676 * vek));
                return zenaBMR;
            }

            else
            {
                // v angličtině se používá: Console.WriteLine("WRONG INPUT! Please enter \"f\" for female or \"m\" for men");
                Console.WriteLine("uživatel zadal nesprávné písmeno, nutno zadat \"z\" pro ženu nebo \"m\" pro muže");
                return -1;
            }

        }

    }
}
