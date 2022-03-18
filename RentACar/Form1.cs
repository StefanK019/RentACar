using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
   
    public partial class Form1 : Form
    {
        Administrator a;
        public Form1()
        {
            InitializeComponent();           
            if (File.Exists("kupci.txt"))
                RadSaDatotekama.kupci = RadSaDatotekama.procitaj<Kupac>("kupci.txt");
            else
                RadSaDatotekama.kupci = new List<Kupac>();

            if (File.Exists("automobili.txt"))
                RadSaDatotekama.automobili = RadSaDatotekama.procitaj<Automobil>("automobili.txt");
            else
                RadSaDatotekama.automobili = new List<Automobil>();

            if (File.Exists("ponude.txt"))
                RadSaDatotekama.ponude = RadSaDatotekama.procitaj<Ponuda>("ponude.txt");
            else
                RadSaDatotekama.ponude = new List<Ponuda>();

            a = new Administrator(1111,"Marko","Markovic","admin456","456admin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RadSaDatotekama.upisi<Kupac>(RadSaDatotekama.kupci, "kupci.txt");
            RadSaDatotekama.upisi<Automobil>(RadSaDatotekama.automobili, "automobili.txt");
            RadSaDatotekama.upisi<Ponuda>(RadSaDatotekama.ponude, "ponude.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool uspesno = false;
            if (checkBox1.Checked == false)
            {
                if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
                {
                    foreach (Kupac k in RadSaDatotekama.kupci)
                    {
                        if (k.KorisnickoIme == textBox1.Text && k.Sifra == textBox2.Text)
                        {
                            MessageBox.Show("Uspesno ste se ulogovali");
                            Form3 frm = new Form3(k);
                            frm.Show();
                            uspesno = true;
                            break;
                        }
                    }
                }
                else
                    MessageBox.Show("Unesite podatke");
            }
            else
            {
                if (a.KorisnickoIme == textBox1.Text && a.Sifra == textBox2.Text)
                {
                    MessageBox.Show("Uspesno ste se ulogovali");
                    Form4 frm = new Form4();
                    frm.Show();
                    uspesno = true;
                }
            }

            if (uspesno == false)
            {
                MessageBox.Show("Unesite validne podatke");
            }
        }
    }
}
