using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Individuální_projekt__jaro_2021
{
    class MenuAplikace
    {
        public void ZobrazInformaceOTrenerech(List<Trener> trenery)
        {
            Console.WriteLine("Zobrazení informací o trenérech a jejich trénincích:");
            foreach (Trener t in trenery)
            {
                t.DetailyTrenera();
            }

            Console.WriteLine();
        }

        List<Klient> klienti = new List<Klient>();

        public void PridatKlienta()
        {
            Console.WriteLine("ZADÁNÍ NOVÉHO KLIENTA");
            Console.WriteLine("Jméno:");
            string jmeno = Console.ReadLine();
            jmeno.Trim('"', '!', '.', '-');

            while (String.IsNullOrEmpty(jmeno) == true || String.IsNullOrWhiteSpace(jmeno) == true)
            {
                Console.WriteLine("uživatel zadal nesprávné jméno");
                jmeno = Console.ReadLine();
                jmeno.Trim('"', '!', '.', '-');
            }

            Console.WriteLine("Příjmení:");
            string prijmeni = Console.ReadLine();
            prijmeni.Trim('"', '!', '.', '-');

            while (String.IsNullOrEmpty(prijmeni) == true || String.IsNullOrWhiteSpace(prijmeni) == true)
            {
                Console.WriteLine("uživatel zadal nesprávné příjmení");
                prijmeni = Console.ReadLine();
                prijmeni.Trim('"', '!', '.', '-');
            }

            Console.WriteLine("Telefonní číslo:");
            string stringTelefon = Console.ReadLine();

            int telefon;
            bool jeCisloTelefon = int.TryParse(stringTelefon, out telefon);
            Math.Abs(telefon);                                  //vrátí nezáporné číslo

            while (jeCisloTelefon == false || stringTelefon.Length != 9) // hodnota nemůže být více jak 9 čísel
            {
                Console.WriteLine("uživatel zadal nesprávné telefonní číslo");
                stringTelefon = Console.ReadLine();
                jeCisloTelefon = int.TryParse(stringTelefon, out telefon);
                Math.Abs(telefon);
            }

            Console.WriteLine("Váha (kg): ");
            string stringVaha = Console.ReadLine();
            double vaha;
            bool jeCisloVaha = double.TryParse(stringVaha, out vaha);
            Math.Abs(vaha);

            while (jeCisloVaha == false)
            {
                Console.WriteLine("uživatel nezadal číslo");
                stringVaha = Console.ReadLine();
                jeCisloVaha = double.TryParse(stringVaha, out vaha);
                Math.Abs(vaha);
            }

            Console.WriteLine("Věk:");
            string stringVek = Console.ReadLine();
            int vek;
            bool jeCisloVek = int.TryParse(stringVek, out vek);
            Math.Abs(vek);

            while (jeCisloVek == false || vek > 100)
            {
                Console.WriteLine("uživatel zadal nesprávné číslo");
                stringVek = Console.ReadLine();
                jeCisloVek = int.TryParse(stringVek, out vek);
                Math.Abs(vek);
            }

            Console.WriteLine("Výška (cm): ");
            string stringVyska = Console.ReadLine();
            double vyska;
            bool jeCisloVyska = double.TryParse(stringVyska, out vyska);
            Math.Abs(vyska);

            while (jeCisloVyska == false || vyska > 270)
            {
                Console.WriteLine("uživatel nezadal správné číslo");
                stringVyska = Console.ReadLine();
                jeCisloVyska = double.TryParse(stringVyska, out vyska);
                Math.Abs(vyska);
            }

            Klient klient = new Klient(jmeno, prijmeni, telefon, vaha, vek, vyska);
            klienti.Add(klient);

            StreamWriter streamWriter = null;
            
            try
            {
                streamWriter = new StreamWriter("klienti.txt", append: true);

                //foreach (Klient item in klienti)
                //{
                    streamWriter.WriteLine(klient.Jmeno + ";" +  klient.Prijmeni + ";" + klient.Telefon + ";" + klient.Vaha + ";" + klient.Vek + ";" + klient.Vyska + "\n");
                    //item.DetailyKlienta();
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine("Došlo k neočekávané vyjímce: {0}", e);
            }

            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }

            Console.WriteLine();
        }


        public void UlozeniVsechKlientu()
        {
            StreamWriter streamWriter = null;

            try
            {
                File.Delete("klienti.txt");

                streamWriter = new StreamWriter("klienti.txt");

                foreach (Klient zapsaniKlienti in klienti)
                {
                    //Console.WriteLine(zapsaniKlienti.Jmeno + ";" + zapsaniKlienti.Prijmeni + ";" + zapsaniKlienti.Telefon + ";" + zapsaniKlienti.Vaha + ";" + zapsaniKlienti.Vaha + ";" + zapsaniKlienti.Vyska);
                    streamWriter.WriteLine(zapsaniKlienti.Jmeno + ";" + zapsaniKlienti.Prijmeni + ";" + zapsaniKlienti.Telefon + ";" + zapsaniKlienti.Vaha + ";" + zapsaniKlienti.Vaha + ";" + zapsaniKlienti.Vyska + "\n");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Došlo k neočekávané vyjímce: {0}", e);
            }

            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        public void VypisKlientu()
        {
            Console.WriteLine("VÝPIS KLIENTŮ:");

            foreach (Klient klient in klienti)
            {
                klient.DetailyKlienta();
            }
        }

        public bool NacteniKlientu()
        {
            if (File.Exists("klienti.txt"))
            {
                StreamReader streamReader = null;

                try
                {
                    streamReader = new StreamReader("klienti.txt");
                    Console.WriteLine("KLIENTI:");
                    string radek = "";
                    while ((radek = streamReader.ReadLine()) != null)
                    {

                        string[] hodnoty = radek.Split(';');
                        string jmeno = hodnoty[0];
                        string prijmeni = hodnoty[1];
                        int telefon = int.Parse(hodnoty[2]);
                        double vaha = double.Parse(hodnoty[3]);
                        int vek = int.Parse(hodnoty[4]);
                        double vyska = double.Parse(hodnoty[5]);

                        Klient klient = new Klient(jmeno, prijmeni, telefon, vaha, vek, vyska);
                        klienti.Add(klient);
                        //klient.DetailyKlienta();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Došlo k neočekávané vyjímce: {0}", e.Message);
                    return false;
                }

                finally
                {
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                }

                Console.WriteLine("Bylo načteno {0} klientů.", klienti.Count);
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Soubor s klienty neexistuje.");
                return false;
            }

            return true;
        }

        public int VybratIndexKlientaPodlePrijmeni()
        {
            for (int i = 0; i < klienti.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, klienti[i].Prijmeni);      // i+1 vypíše indexi příjmení A JEHO PŘÍJMENÍ (i+1 protože běžně začínáme počty od čísla 1, ne od nuly, jak je to v poli)
            }

            Console.WriteLine("Napiš index (pořadové číslo) příjmení klienta");

            string stringPrijmeni = Console.ReadLine();

            //if (String.IsNullOrEmpty(stringPrijmeni) == true || String.IsNullOrWhiteSpace(stringPrijmeni) == true)
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("uživatel zadal nesprávné jméno");
            //        stringPrijmeni = Console.ReadLine();
            //    }
            //}
            int prijmeni;
            bool jePrijmeni = Int32.TryParse(stringPrijmeni, out prijmeni);
            Math.Abs(prijmeni);

            int prijmeniOdJednicky = prijmeni - 1;                   // při načtení odečtu 1, protože uživatelé jsou běžně zvyklý číslovat od čísla 1 ne od nuly, jak je to v poli

            if (prijmeniOdJednicky >= 0 && prijmeniOdJednicky < klienti.Count)
            {
                return prijmeniOdJednicky;
            }

            else
            {
                //Console.WriteLine("Zadán nesprávný index příjmení.");
                return -1;       //metoda vrací index a nebo číslo -1, pokud by uživatel vybral neexistující index
            }
        }

        public void SmazatKlienta()
        {
            Console.WriteLine("SMAZÁNÍ KLIENTA");
            int indexKeSmazani = VybratIndexKlientaPodlePrijmeni();

            if (indexKeSmazani >= 0)
            {
                Console.WriteLine("Klient {0} byl smazán", klienti[indexKeSmazani].Prijmeni);
                klienti.Remove(klienti[indexKeSmazani]);

                this.UlozeniVsechKlientu();
            }

            else
            {
                Console.WriteLine("Zadán nesprávný index příjmení.");
            }

            Console.WriteLine();
        }

        public void UpravitExistujicihoUzivatele()
        {
            Console.WriteLine("ÚPRAVA KLIENTA");
            int indexUpravy = VybratIndexKlientaPodlePrijmeni();

            if (indexUpravy >= 0)
            {
                Klient klient = (Klient)klienti[indexUpravy];

                Console.WriteLine("Aktuální jméno: {0}\n Chcete upravit? A/N", klient.Jmeno);
                string pismeno1 = Console.ReadLine();
                pismeno1.Trim('"', '!', '.', '-');

                if (pismeno1.ToLower() == "a")
                {
                    Console.WriteLine("Nové jméno:");
                    klient.Jmeno = Console.ReadLine();
                }

                else if (pismeno1.ToLower() == "n")
                {
                    Console.WriteLine("Jméno zůstává nezměněno.");
                }

                else if (String.IsNullOrEmpty(pismeno1) == true || String.IsNullOrWhiteSpace(pismeno1) == true || pismeno1.ToLower() != "a" || pismeno1.ToLower() != "n")
                {

                    while (true)
                    {
                        Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                        pismeno1 = Console.ReadLine();
                        pismeno1.Trim('"', '!', '.', '-');

                        if (pismeno1.ToLower() == "a")
                        {
                            Console.WriteLine("Nové jméno:");
                            klient.Jmeno = Console.ReadLine();
                            break;
                        }

                        else if (pismeno1.ToLower() == "n")
                        {
                            Console.WriteLine("Jméno zůstává nezměněno.");
                            break;
                        }
                    }
                }


                Console.WriteLine("Aktuální příjmení: {0}\n Chcete upravit? A/N", klient.Prijmeni);
                string pismeno2 = Console.ReadLine();
                pismeno2.Trim('"', '!', '.', '-');

                if (pismeno2.ToLower() == "a")
                {
                    Console.WriteLine("Nové příjmení:");
                    klient.Prijmeni = Console.ReadLine();
                }

                else if (pismeno2.ToLower() == "n")
                {
                    Console.WriteLine("Příjmení zůstává nezměněno.");
                }

                else if (String.IsNullOrEmpty(pismeno2) == true || String.IsNullOrWhiteSpace(pismeno2) == true || pismeno2.ToLower() != "a" || pismeno2.ToLower() != "n")
                {

                    while (true)
                    {
                        Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                        pismeno2 = Console.ReadLine();
                        pismeno2.Trim('"', '!', '.', '-');

                        if (pismeno2.ToLower() == "a")
                        {
                            Console.WriteLine("Nové příjmení:");
                            klient.Prijmeni = Console.ReadLine();
                            break;
                        }

                        else if (pismeno2.ToLower() == "n")
                        {
                            Console.WriteLine("Příjmení zůstává nezměněno.");
                            break;
                        }
                    }
                }


                Console.WriteLine("Aktuální telefon: {0}\n Chcete upravit? A/N", klient.Telefon);
                string pismeno3 = Console.ReadLine();
                pismeno3.Trim('"', '!', '.', '-');

                if (pismeno3.ToLower() == "a")
                {
                    Console.WriteLine("Nové telefonní číslo:");
                    klient.Telefon = int.Parse(Console.ReadLine());
                }

                else if (pismeno3.ToLower() == "n")
                {
                    Console.WriteLine("Telefonní číslo zůstává nezměněno.");
                }

                else if (String.IsNullOrEmpty(pismeno3) == true || String.IsNullOrWhiteSpace(pismeno3) == true || pismeno3.ToLower() != "a" || pismeno3.ToLower() != "n")
                  {

                        while (true)
                        {
                            Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                            pismeno3 = Console.ReadLine();
                            pismeno3.Trim('"', '!', '.', '-');

                            if (pismeno3.ToLower() == "a")
                            {
                                Console.WriteLine("Nové telefonní číslo:");
                                klient.Telefon = int.Parse(Console.ReadLine());
                                break;
                            }

                            else if (pismeno3.ToLower() == "n")
                            {
                                Console.WriteLine("Telefonní číslo zůstává nezměněno.");
                                break;
                            }
                        }
                    }


                Console.WriteLine("Aktuální váha: {0}\n Chcete upravit? A/N", klient.Vaha);
                string pismeno4 = Console.ReadLine();
                pismeno4.Trim('"', '!', '.', '-');

                if (pismeno4.ToLower() == "a")
                {
                    Console.WriteLine("Nová váha (kg):");
                    klient.Vaha = double.Parse(Console.ReadLine());
                }

                else if (pismeno4.ToLower() == "n")
                {
                    Console.WriteLine("Váha zůstává nezměněna.");
                }

                else if (String.IsNullOrEmpty(pismeno4) == true || String.IsNullOrWhiteSpace(pismeno4) == true || pismeno4.ToLower() != "a" || pismeno4.ToLower() != "n")
                {

                    while (true)
                    {
                        Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                        pismeno4 = Console.ReadLine();
                        pismeno4.Trim('"', '!', '.', '-');

                        if (pismeno4.ToLower() == "a")
                        {
                            Console.WriteLine("Nová váha (kg):");
                            klient.Vaha = double.Parse(Console.ReadLine());
                            break;
                        }

                        else if (pismeno4.ToLower() == "n")
                        {
                            Console.WriteLine("Váha zůstává nezměněna.");
                            break;
                        }
                    }
                }


                Console.WriteLine("Aktuální věk: {0}\n Chcete upravit? A/N", klient.Vek);
                string pismeno5 = Console.ReadLine();
                pismeno5.Trim('"', '!', '.', '-');

                if (pismeno5.ToLower() == "a")
                {
                    Console.WriteLine("Nový věk:");
                    klient.Vek = int.Parse(Console.ReadLine());
                }

                else if (pismeno5.ToLower() == "n")
                {
                    Console.WriteLine("Věk zůstává nezměněn.");
                }

                else if (String.IsNullOrEmpty(pismeno5) == true || String.IsNullOrWhiteSpace(pismeno5) == true || pismeno5.ToLower() != "a" || pismeno5.ToLower() != "n")
                {

                    while (true)
                    {
                        Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                        pismeno5 = Console.ReadLine();
                        pismeno5.Trim('"', '!', '.', '-');

                        if (pismeno5.ToLower() == "a")
                        {
                            Console.WriteLine("Nový věk:");
                            klient.Vek = int.Parse(Console.ReadLine());
                            break;
                        }

                        else if (pismeno5.ToLower() == "n")
                        {
                            Console.WriteLine("Věk zůstává nezměněn.");
                            break;
                        }
                    }
                }


                Console.WriteLine("Aktuální výška: {0}\n Chcete upravit? A/N", klient.Vyska);
                string pismeno6 = Console.ReadLine();
                pismeno6.Trim('"', '!', '.', '-');

                if (pismeno6.ToLower() == "a")
                {
                    Console.WriteLine("Nová výška:");
                    klient.Vyska = double.Parse(Console.ReadLine());
                }

                else if (pismeno6.ToLower() == "n")
                {
                    Console.WriteLine("Výška zůstává nezměněna.");
                }

                else if (String.IsNullOrEmpty(pismeno6) == true || String.IsNullOrWhiteSpace(pismeno6) == true || pismeno6.ToLower() != "a" || pismeno6.ToLower() != "n")
                {

                    while (true)
                    {
                        Console.WriteLine("zadáno nesprávné písmenko, zadej znovu");
                        pismeno6 = Console.ReadLine();
                        pismeno6.Trim('"', '!', '.', '-');

                        if (pismeno6.ToLower() == "a")
                        {
                            Console.WriteLine("Nová výška:");
                            klient.Vyska = double.Parse(Console.ReadLine());
                            break;
                        }

                        else if (pismeno6.ToLower() == "n")
                        {
                            Console.WriteLine("Výška zůstává nezměněna.");
                            break;
                        }
                    }
                }

                Console.WriteLine("Úprava dokončena");
                this.UlozeniVsechKlientu();
            }

            else
            {
                Console.WriteLine("zadán nesprávný index příjmení");
            }

            Console.WriteLine();
        }

        public void VyhledatKlientaPodlePrijmeni()
        {

            Console.WriteLine("Napiš příjmení hledaného uživatele:");
            string hledanePrijmeni = Console.ReadLine();

            //var hledanyKlient = from p in klienti
            //                   where (p.Prijmeni.Contains(hledanePrijmeni))
            //                   select p;

            //foreach (var prijmeni in hledanyKlient)
            //{
            //    if (hledanyKlient != null)
            //    {
            //        Console.WriteLine(prijmeni);
            //    }

            //    else
            //    {
            //        Console.WriteLine("Příjmení neexistuje.");
            //    }
            //}

            // Klient hledanyKlient1 = klienti.FindAll(klienti => klienti.Prijmeni.Count(hledanePrijmeni));

            List<Klient> result = new List<Klient>(klienti.FindAll(x => x.Prijmeni == hledanePrijmeni));

            if (result.Count > 0)
            {
                foreach (Klient item in result)
                {
                      Console.WriteLine((item.Jmeno + " " + item.Prijmeni + ": " + item.Telefon + " " + "(Věk: " + item.Vek + ", Váha:" + item.Vaha + ", Výška:" + item.Vyska + ")" + "\n"));
                }
            }

            else
            {
                Console.WriteLine("Příjmení neexistuje.");
            }

            Console.WriteLine();
        }

        public void VypisBMIKlienta()
        {

            Console.WriteLine("VÝPOČET INDEXU TĚLESNÉ HMOTNOSTI KLIENTA (BODY MASS INDEXU, BMI)\n");
            int indexVypisuBMI = VybratIndexKlientaPodlePrijmeni();

            if (indexVypisuBMI >= 0)
            {
                Klient klient = (Klient)klienti[indexVypisuBMI];

                Console.WriteLine("Jméno vybraného klienta: {0}, {1}\n", klient.Jmeno, klient.Prijmeni);
                double BMI = klient.VypocetBMI(klient.Vaha, klient.Vyska);

                Console.WriteLine("BMI klienta při váze {0} kg a výšce {1} cm je roven {2,4:F2}.", klient.Vaha, klient.Vyska, BMI); //číslo 4 znamená celkový počet znaků výstupu, F2 znamená výstupní formát a počet desetinných míst

                List<Trener> treneri = Trener.NastaveniTrenera();

                if (BMI <= 16.5)
                {
                    Console.WriteLine("POZOR, kliet má těžkou podvýživu!");
                    Console.WriteLine();
                    //for (int i = 0; i < treneri.Count; i++)
                    //{
                    //    Console.WriteLine("{0}", treneri[i].Prijmeni);
                    //}

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Činka"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else if (BMI <= 18.5)
                {
                    Console.WriteLine("Klient má podváhu.");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Činka"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else if (BMI <= 25)
                {
                    Console.WriteLine("Klient má ideální váhu.");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Podlaha"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else if (BMI <= 30)
                {
                    Console.WriteLine("Klient má nadváhu.");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Stavitel"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else if (BMI <= 35)
                {
                    Console.WriteLine("Klient má mírnou obezitu.");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Stavitel"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else if (BMI <= 40)
                {
                    Console.WriteLine("Klient má střední obezitu.");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Podlaha"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }

                else
                {
                    Console.WriteLine("Klient má morbidní obezitu!");
                    Console.WriteLine();

                    List<Trener> pridenenyTrener = treneri.FindAll(t => t.Prijmeni.StartsWith("Podlaha"));

                    foreach (Trener t in pridenenyTrener)
                    {
                        Console.WriteLine("doporučen trenér: -------> " + t.Jmeno + " " + t.Prijmeni);
                    }
                }
            }

            else
            {
                Console.WriteLine("zadán nesprávný index přijmení klienta");
            }

            this.UlozeniVsechKlientu();
            Console.WriteLine();
        }

        public void VypisDCIKlienta()
        {
            Console.WriteLine("VÝPOČET DENNÍHO PŘÍJMU KALORIÍ (DCI)\n");
            int indexVypisuDCI = VybratIndexKlientaPodlePrijmeni();

            if (indexVypisuDCI >= 0)
            {
                Klient klient = (Klient)klienti[indexVypisuDCI];

                Console.WriteLine("Jméno vybraného klienta: {0}, {1}\n", klient.Jmeno, klient.Prijmeni);
                Console.WriteLine("Zadej kolikrát týdně klient cvičí (napiš číslo).");
                int tydeniCviceni = int.Parse(Console.ReadLine());

                //Console.WriteLine("Bazální metabolismus klienta (BMR) je:{0}", klient.VypocetBMR(klient.Vaha, klient.Vyska, klient.Vek));

                double BMR = klient.VypocetBMR(klient.Vaha, klient.Vyska, klient.Vek);

                double DCI = 0;

                if (tydeniCviceni <= 0)
                {
                    DCI = BMR * 1.2;
                }

                else if (tydeniCviceni == 1 || tydeniCviceni == 2 || tydeniCviceni == 3)
                {
                    DCI = BMR * 1.375;
                }

                else if (tydeniCviceni == 4 || tydeniCviceni == 5 || tydeniCviceni == 6)
                {
                    DCI = BMR * 1.55;
                }

                else if (tydeniCviceni == 7 || tydeniCviceni == 8 || tydeniCviceni == 9)
                {
                    DCI = BMR * 1.725;
                }

                else
                {
                    DCI = BMR * 1.9;
                }

                Console.WriteLine("Denní příjem kalorií (DCI) při váze {0} kg a výšce {1} cm, věku {2} a týdenní aktivitě ({3}) by měl být {4,5:F2}.", klient.Vaha, klient.Vyska, klient.Vek, tydeniCviceni, DCI);
            }

            else
            {
                Console.WriteLine("zadán nesprávný index přijmení klienta");
            }

            this.UlozeniVsechKlientu();
            Console.WriteLine();
        }

    }
}
