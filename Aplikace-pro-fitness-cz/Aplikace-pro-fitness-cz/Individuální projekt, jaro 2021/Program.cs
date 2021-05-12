using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Individuální_projekt__jaro_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuAplikace menuAplikace = new MenuAplikace();

            bool bLoad = menuAplikace.NacteniKlientu();

            int volbaMenu = 0;

            do
            {
                Console.WriteLine("HLAVNÍ MENU APLIKACE (zadej číslo požadovaného úkonu):");
                Console.WriteLine("\t 1. Přidat klienta");
                Console.WriteLine("\t 2. Vypsat informace o všech klientech");
                Console.WriteLine("\t 3. Zobrazit informace o trenérech");
                Console.WriteLine("\t 4. Vyhledat klienta podle příjmení");
                Console.WriteLine("\t 5. Smazat klienta");
                Console.WriteLine("\t 6. Upravit klienta");
                Console.WriteLine("\t 7. Výpočet indexu tělesné hmotnosti klienta (BMI), přidělení trenéra");
                Console.WriteLine("\t 8. Výpočet denního příjmu kalorií (DCI) klienta, přes výpočet bazálního metabolismu (BMR)");
                Console.WriteLine("\t 9. Ukončit program");

                string volbaString = Console.ReadLine();
                bool jeVolbaMenu = Int32.TryParse(volbaString, out volbaMenu);
                Math.Abs(volbaMenu);

                switch (volbaMenu)
                {
                    case 1:
                        menuAplikace.PridatKlienta();
                        break;
                    case 2:
                        menuAplikace.VypisKlientu();
                        break;
                    case 3:
                        menuAplikace.ZobrazInformaceOTrenerech(Trener.NastaveniTrenera());
                        break;
                    case 4:
                        menuAplikace.VyhledatKlientaPodlePrijmeni();
                        break;
                    case 5:
                        menuAplikace.SmazatKlienta();
                        break;
                    case 6:
                        menuAplikace.UpravitExistujicihoUzivatele();
                        break;
                    case 7:
                        menuAplikace.VypisBMIKlienta();
                        break;
                    case 8:
                        menuAplikace.VypisDCIKlienta();
                        break;

                }

                while (jeVolbaMenu == false || volbaMenu > 9)
                {
                    Console.WriteLine("uživatel nezadal správné číslo");
                    volbaString = Console.ReadLine();
                    jeVolbaMenu = Int32.TryParse(volbaString, out volbaMenu);
                    Math.Abs(volbaMenu);
                }

            } while (volbaMenu != 9);

            Console.WriteLine("program se ukončuje.....");
            
            
            Console.ReadLine();

        }
    }
}
