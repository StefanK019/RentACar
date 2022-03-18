using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    [Serializable]
    public class Automobil
    {
        private int idBr;
        private string marka;
        private string model;
        private int godiste;
        private int kubikaza;
        private string pogon;
        private string vrstaMenjaca;
        private string karoserija;
        private string gorivo;
        private int brVrata;

        public Automobil(int idBr, string marka, string model, int godiste, int kubikaza, string pogon, string vrstaMenjaca, string karoserija, string gorivo, int brVrata)
        {
            this.idBr = idBr;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brVrata = brVrata;
        }

        public int IdBr { get { return idBr; } set { idBr = value; } }
        public string Marka { get { return marka; } set { marka = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Godiste { get { return godiste; } set { godiste = value; } }
        public int Kubikaza { get { return kubikaza; } set { kubikaza = value; } }
        public string Pogon { get { return pogon; } set { pogon = value; } }
        public string VrstaMenjaca { get { return vrstaMenjaca; } set { vrstaMenjaca = value; } }
        public string Karoserija { get { return karoserija; } set { karoserija = value; } }
        public string Gorivo { get { return gorivo; } set { gorivo = value; } }
        public int BrVrata { get { return brVrata; } set { brVrata = value; } }

        public override string ToString()
        {
            return this.idBr + " " + this.marka+ " " + this.model+ " " + this.godiste+ " " + this.kubikaza+ " " + this.karoserija+ " " + this.brVrata+ " " + this.gorivo+ " " + this.pogon+ " " + this.vrstaMenjaca;
        }
    }

    
}