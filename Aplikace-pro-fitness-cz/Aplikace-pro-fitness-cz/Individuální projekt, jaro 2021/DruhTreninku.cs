using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuální_projekt__jaro_2021
{
    class DruhTreninku
    {
        public string Nazev { get; set; }
        public string Popis { get; set; }

        public DruhTreninku (string nazev, string popis)
        {
            Nazev = nazev;
            Popis = popis;
        }
    }
}
