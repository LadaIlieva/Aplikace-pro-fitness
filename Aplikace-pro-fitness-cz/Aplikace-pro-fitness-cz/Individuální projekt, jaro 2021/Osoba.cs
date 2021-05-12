using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuální_projekt__jaro_2021
{
    class Osoba : IOsoba
    {
        // Osoba dedi z IOsoba, aby MenuAplikace mohla zajistit, ze informace o uzivatelích nejdou zmenit zvenku
        public string Jmeno { get; set; }
      
        public string Prijmeni { get; set; }
        //šlo by také: public int Telefon { get; protected set; }

        private int _telefon;
        //Vlastnost, kterou lze číst z vnějšku třídy:
        public int Telefon
        {
            get 
            { 
                return _telefon; 
            }
            set
            {
                _telefon = value;
            }
        }

        public Osoba (string jmeno, string prijmeni, int telefon)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Telefon = telefon;
        }
    }
}
