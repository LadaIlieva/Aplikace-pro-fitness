using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuální_projekt__jaro_2021
{
    class Trener : Osoba
    {
        public List<DruhTreninku> Treninky { get; set; } //str. 159
        public DruhTreninku Trenink { get; set; }

        public Trener(string jmeno, string prijmeni, int telefon, List<DruhTreninku> treninky) : base(jmeno, prijmeni, telefon)
        {
            Treninky = treninky;
        }
        public Trener(string jmeno, string prijmeni, int telefon, DruhTreninku trenink) : base(jmeno, prijmeni, telefon)
        {
            Trenink = trenink;
        }

        //public override string ToString() 
        public void DetailyTrenera()
        {
            if (Treninky == null)
            {
                 ZobrazitTrenink();
            }

            else
            {
                 ZobrazitTreninky();
            }
        }

            void ZobrazitTrenink()
            {
                Console.WriteLine( Jmeno.PadRight(10) + " " + Prijmeni.PadRight(10) + "---> " + Telefon.ToString() + "\n" +
                 Trenink.Nazev.PadRight(21) + " " + Trenink.Popis.PadRight(20));
            }

            void ZobrazitTreninky()
            {
                var result = String.Empty;

                Console.WriteLine("SEZNAM TRÉNINKŮ:");
                Console.WriteLine();

                foreach (var t in Treninky)
                {
                
                result = Jmeno.PadRight(10) + " " + Prijmeni.PadRight(10) + "---> " + Telefon.ToString() + "\n" +
                t.Nazev.PadRight(21) + "--->" + t.Popis.PadRight(20);

                Console.WriteLine(result);
                //Console.WriteLine(t.Nazev + ": " + t.Popis);
                Console.WriteLine();
                }
            }

        public static List<Trener> NastaveniTrenera()
        {
            DruhTreninku treninkJedna = new DruhTreninku("objemový trénink ", " Je zaměřený na získání velkého objemu svalů.Každý cvik se cvičí ve 4 sériích a v každé z nich se provádí 4 - 6 opakování.Rychlost provádění cviku musí být svižná, bez zastavení.");
            DruhTreninku treninkDva = new DruhTreninku("Pumpovací trénink ", " Se zaměřuje na prokrvení všech svalů. Cviky se cvičí ve 4 sériích a v každé z nich se vykoná cca 12 opakování. Rychlost provedení cviku je stejná jako u objemového tréninku.");
            DruhTreninku treninkTri = new DruhTreninku("Vytrvalostní/rýsovací trénink ", " Je koncipovaný pro delší výdrž svalů. Zároveň se uplatňuje při rýsování svalů nebo redukci podkožního tuku. U každého cviku se provádí 6 sérií s nízkými váhami. Počet opakování v každé sérii se pohybuje okolo 20. Rychlost je opět svižná.");
            DruhTreninku treninkCtyri = new DruhTreninku("Silový trénink ", " Se zaměřuje na zesílení a zpevnění svalů. Počet sérií se pohybuje mezi 6 a 7 a cviky se v sérii opakují zhruba 8x. Rychlost pohybu dolů i nahoru zde musí být pomalá.");

            List<Trener> treneri = new List<Trener>();

            List<DruhTreninku> TreninkyBorek = new List<DruhTreninku>();
            TreninkyBorek.Add(treninkJedna);
            TreninkyBorek.Add(treninkTri);

            List<DruhTreninku> TreninkyPremek = new List<DruhTreninku>();
            TreninkyPremek.Add(treninkDva);
            TreninkyPremek.Add(treninkTri);

            List<DruhTreninku> TreninkyStanislav = new List<DruhTreninku>();
            TreninkyStanislav.Add(treninkCtyri);
            TreninkyStanislav.Add(treninkJedna);

            Trener trenerJedna = new Trener("Bořek", "Stavitel", 776456123, TreninkyBorek);
            Trener trenerDva = new Trener("Přemek", "Podlaha", 777784130, TreninkyPremek);
            Trener trenerTri = new Trener("Stanislav", "Činka", 724896184, TreninkyStanislav);


            treneri.Add(trenerJedna);
            treneri.Add(trenerDva);
            treneri.Add(trenerTri);

            return treneri;
        }
    }
}
