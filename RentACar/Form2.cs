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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length!=0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0 &&
                textBox4.Text.Trim().Length != 0 && textBox5.Text.Trim().Length != 0 && textBox6.Text.Trim().Length != 0 &&
                textBox7.Text.Trim().Length != 0 && dateTimePicker1.Value!=new DateTime(2019,1,1))
            {
                if (textBox4.Text == textBox5.Text && samoBrojevi(textBox6.Text)==true && samoBrojevi(textBox7.Text)==true &&
                    textBox4.Text.Length>6 && textBox4.Text.Length > 6)
                {
                    int id = jedinstveniId();
                    Kupac k = new Kupac(id,textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, dateTimePicker1.Value, textBox7.Text);
                    RadSaDatotekama.kupci.Add(k);
                    MessageBox.Show("Uspesno ste napravili nalog");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox1.Focus();
                    dateTimePicker1.Value=new DateTime(2019,1,1);
                }
                else
                    MessageBox.Show("Podatci nisu tacno popunjeni");
            }
            else
                MessageBox.Show("Unesite sve podatke");
        }

        private bool samoBrojevi(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private int jedinstveniId()
        {
            Random rnd = new Random();
            int i, novId;
            do{
                i = 0;
                novId = rnd.Next(1000, 10000);                
                foreach (Kupac k in RadSaDatotekama.kupci)
                {
                    if (k.Id == novId)
                    {
                        i++;
                    }
                }
            } while (i != 0);

            return novId;
        }
    }
}
