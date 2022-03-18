using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class Form3 : Form
    {
        Form7 frm;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Kupac k)
        {
            frm = new Form7(k);
            InitializeComponent();
            label8.Text = k.Id.ToString();
            label9.Text = k.Ime;
            label10.Text = k.Prezime;
            label11.Text = k.KorisnickoIme;
            label12.Text = k.Jmbg;
            label13.Text = k.DatRodjenja.ToShortDateString();
            label14.Text = k.Telefon;
        }

        private void button1_Click(object sender, EventArgs e)
        {        
           frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (Kupac k in RadSaDatotekama.kupci)
            {
                if (k.Id == int.Parse(label8.Text) && k.Rezervacije.Count != 0)
                {
                    foreach (Rezervacija r in k.Rezervacije)
                    {
                        listBox1.Items.Add(r.ToString());
                    }
                }
            }
        }
    }
}
