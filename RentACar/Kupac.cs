using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    [Serializable()]
    public class Kupac : Korisnik
    {
        private string jmbg;
        private DateTime datRodjenja;
        private string telefon;
        private List<Rezervacija>rezervacije = new List<Rezervacija>();
        public Kupac(int id ,string ime, string prezime, string korisnickoIme, string sifra, string jmbg, DateTime datRodjenja, string telefon) : base(id, ime, prezime, korisnickoIme, sifra)
        {
            this.jmbg = jmbg;
            this.datRodjenja = datRodjenja;
            this.telefon = telefon;
        }

        public string Jmbg { get { return jmbg; } set { jmbg = value; } }
        public DateTime DatRodjenja { get { return datRodjenja; } set { datRodjenja = value; } }
        public string Telefon { get { return telefon; } set { telefon = value; } }
        public List<Rezervacija> Rezervacije { get { return rezervacije; } set { rezervacije = value; } }
        public override string ToString()
        {
            return this.ime + " " +this.prezime + " " +this.korisnickoIme+" " + this.sifra+" " + this.jmbg+" " + this.datRodjenja.ToShortDateString()+" " + this.telefon;
        }
    }
}
