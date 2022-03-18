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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0 && textBox4.Text.Trim().Length != 0 &&
                comboBox1.Text.Trim().Length != 0 && comboBox2.Text.Trim().Length != 0 && comboBox3.Text.Trim().Length != 0 && comboBox4.Text.Trim().Length != 0 && comboBox5.Text.Trim().Length != 0)
            {
                int id = jedinstveniId();
                Automobil a = new Automobil(id,textBox1.Text,textBox2.Text,int.Parse(textBox3.Text),int.Parse(textBox4.Text),comboBox4.Text,comboBox5.Text,comboBox1.Text,comboBox3.Text,int.Parse(comboBox2.Text));
                RadSaDatotekama.automobili.Add(a);
                MessageBox.Show("Uspesno ste dodali automobil");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                textBox1.Focus();
            } else
                MessageBox.Show("Unesite sve podatke");
        }

        private int jedinstveniId()
        {
            Random rnd = new Random();
            int i, novId;
            do
            {
                i = 0;
                novId = rnd.Next(1000, 10000);
                foreach (Automobil a in RadSaDatotekama.automobili)
                {
                    if (a.IdBr == novId)
                    {
                        i++;
                    }
                }
            } while (i != 0);

            return novId;
        }
    }
}
