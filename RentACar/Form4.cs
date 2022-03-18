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
    public partial class Form4 : Form
    { 
        public Form4()
        {
            InitializeComponent();
            osveziListu<Automobil>(RadSaDatotekama.automobili);
            popuniComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }

        private void osveziListu<T>(List<T>lista)
        {
            foreach (T t in lista)
            {
                listBox1.Items.Add(t.ToString());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(radioButton1.Checked)
                osveziListu<Automobil>(RadSaDatotekama.automobili);
            if(radioButton2.Checked)
                osveziListu<Ponuda>(RadSaDatotekama.ponude);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            string[] podeli = str.Split(' ');
            int id;
            bool uspesno = int.TryParse(podeli[0], out id);
            if (uspesno == true && radioButton1.Checked)
            {
                foreach (Automobil a in RadSaDatotekama.automobili.ToList())
                {
                    if (a.IdBr == id)
                    {
                        RadSaDatotekama.automobili.Remove(a);
                    }
                }

                foreach (Ponuda p in RadSaDatotekama.ponude.ToList())
                {
                    if (p.IdBr == id)
                    {
                        RadSaDatotekama.ponude.Remove(p);
                    }
                }

            }
            else if (uspesno == true && radioButton2.Checked)
            {
                foreach (Ponuda p in RadSaDatotekama.ponude.ToList())
                {
                    if (p.IdBr == id)
                    {
                        RadSaDatotekama.ponude.Remove(p);
                    }
                }
            }
        }

        public void popuniComboBox()
        {
            foreach (Kupac k in RadSaDatotekama.kupci)
            {
                comboBox1.Items.Add(k.Id + " " + k.Ime + " " + k.Prezime);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string str = comboBox1.Text;
            string[] podeli = str.Split(' ');
            foreach (Kupac k in RadSaDatotekama.kupci)
            {
                if (k.Id == int.Parse(podeli[0]))
                {
                    if (k.Rezervacije.Count != 0)
                    {
                        foreach (Rezervacija r in k.Rezervacije)
                        {
                            listBox2.Items.Add(r.ToString());
                        }
                    }
                    else
                        listBox2.Items.Add("Korisnik nema ni jednu rezervaciju");
                }
            }
        }

    }
}
