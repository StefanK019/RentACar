using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    [Serializable()]
    public abstract class Korisnik
    {
        protected int id;
        protected string ime;
        protected string prezime;
        protected string korisnickoIme;
        protected string sifra;

        public Korisnik(int id,string ime, string prezime, string korisnickoIme, string sifra)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public string KorisnickoIme { get { return korisnickoIme; } set { korisnickoIme = value; } }
        public string Sifra { get { return sifra; } set { sifra = value; } }
    }
}
