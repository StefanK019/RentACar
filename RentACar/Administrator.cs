using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    public class Administrator : Korisnik
    {
        public Administrator(int id, string ime, string prezime, string korisnickoIme, string sifra) : base(id, ime, prezime, korisnickoIme, sifra)
        {
        }

    }
}
