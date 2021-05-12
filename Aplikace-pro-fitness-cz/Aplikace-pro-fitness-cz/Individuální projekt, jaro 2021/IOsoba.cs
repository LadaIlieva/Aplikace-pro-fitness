using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuální_projekt__jaro_2021
{
    interface IOsoba
    {
        // interface pro omezeni pristupu k uctu
        // bez set znamená, že je vlastnost jen pro čtení (Vlastnost bez get přístupového objektu je považována za jen pro zápis)
        string Jmeno { get; }
        string Prijmeni { get; }
        int Telefon { get; }
    }
}
