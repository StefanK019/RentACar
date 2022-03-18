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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && dateTimePicker1.Value >= DateTime.Today && dateTimePicker2.Value >= dateTimePicker1.Value)
            {
                int idAuta = int.Parse(textBox1.Text);
                bool uspesno = false;
                foreach (Automobil a in RadSaDatotekama.automobili)
                {
                    if (a.IdBr == idAuta)
                    {
                        uspesno = true;
                    }
                }
                if (uspesno == true)
                {
                    int id = jedinstveniId();
                    Ponuda p = new Ponuda(id, idAuta, dateTimePicker1.Value, dateTimePicker2.Value, double.Parse(textBox2.Text));
                    RadSaDatotekama.ponude.Add(p);
                    MessageBox.Show("Uspesno ste dodali ponudu");
                    textBox1.Clear();
                    textBox2.Clear();
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                }
                else
                    MessageBox.Show("Ne posoji auto sa unetim id");
            }
            else
                MessageBox.Show("Unesite ispravne podatke");
        }
        private int jedinstveniId()
        {
            Random rnd = new Random();
            int i, novId;
            do
            {
                i = 0;
                novId = rnd.Next(1000, 10000);
                foreach (Ponuda p in RadSaDatotekama.ponude)
                {
                    if (p.IdBr == novId)
                    {
                        i++;
                    }
                }
            } while (i != 0);

            return novId;
        }

    }
}
