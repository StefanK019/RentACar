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
    public partial class Form7 : Form
    {
        Kupac k1;
        Ponuda p1;
        public Form7(Kupac k)
        {
            k1 = k;
            InitializeComponent();
            popuniComboBox();
        }

        private void popuniComboBox()
        {
            foreach (Automobil a in RadSaDatotekama.automobili)
            {               
                comboBox1.Items.Add(a.Marka);
                comboBox2.Items.Add(a.Model);
                comboBox3.Items.Add(a.Godiste);
                comboBox4.Items.Add(a.Kubikaza);
                comboBox5.Items.Add(a.Karoserija);
                comboBox6.Items.Add(a.BrVrata);
                comboBox7.Items.Add(a.Gorivo);
                comboBox8.Items.Add(a.Pogon);
                comboBox9.Items.Add(a.VrstaMenjaca);
                obrisiDuplikate(comboBox1);
                obrisiDuplikate(comboBox2);
                obrisiDuplikate(comboBox3);
                obrisiDuplikate(comboBox4);
                obrisiDuplikate(comboBox5);
                obrisiDuplikate(comboBox6);
                obrisiDuplikate(comboBox7);
                obrisiDuplikate(comboBox8);
                obrisiDuplikate(comboBox9);
            }
        }

        private void obrisiDuplikate(ComboBox myComboBox)
        {
            for (int i = 0; i < myComboBox.Items.Count-1; i++)
            {
                for (int j = i + 1; j < myComboBox.Items.Count;j++)
                {
                    if (myComboBox.Items[i].ToString() == myComboBox.Items[j].ToString())
                    {
                        myComboBox.Items.RemoveAt(j);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.Text.Trim().Length != 0 && comboBox2.Text.Trim().Length != 0 && comboBox3.Text.Trim().Length != 0 &&
                comboBox4.Text.Trim().Length != 0 && comboBox5.Text.Trim().Length != 0 && comboBox6.Text.Trim().Length != 0 &&
               comboBox7.Text.Trim().Length != 0 && comboBox8.Text.Trim().Length != 0 && comboBox9.Text.Trim().Length != 0)
            {
                foreach (Automobil a in RadSaDatotekama.automobili)
                {
                    if (a.Marka == comboBox1.Text && a.Model == comboBox2.Text && a.Godiste == int.Parse(comboBox3.Text) &&
                        a.Kubikaza == int.Parse(comboBox4.Text) && a.Karoserija == comboBox5.Text && a.BrVrata == int.Parse(comboBox6.Text) &&
                        a.Gorivo == comboBox7.Text && a.Pogon == comboBox8.Text && a.VrstaMenjaca == comboBox9.Text)
                    {
                        foreach (Ponuda p in RadSaDatotekama.ponude)
                        {
                            if (p.IdAuta == a.IdBr)
                            {
                                listBox1.Items.Add(p.ToString());
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Popunite sva polja");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            string[] podeli = str.Split(' ');
            int id;
            bool uspesno = int.TryParse(podeli[0], out id);
            if (uspesno == true)
            {
                foreach (Ponuda p in RadSaDatotekama.ponude)
                {
                    if (p.IdBr == id)
                    {
                        p1 = p;
                        dateTimePicker2.Value = p1.DatumDo;
                        dateTimePicker1.Value = p1.DatumOd;                        
                        int dani = (dateTimePicker2.Value - dateTimePicker1.Value).Days;                       
                        textBox1.Text = (p1.CenaPoDanu * (dani+1)).ToString();                        
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (p1!=null)
            {
                if (dateTimePicker1.Value >= p1.DatumOd)
                {
                    if (dateTimePicker1.Value <= dateTimePicker2.Value)
                    {
                        int dani = (dateTimePicker2.Value - dateTimePicker1.Value).Days;
                        textBox1.Text = (p1.CenaPoDanu * (dani+1)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("1Datum Od ne moze biti veci od datuma Do");
                        dateTimePicker1.Value = p1.DatumOd;
                    }
                }
                else
                {
                    MessageBox.Show("Datum ne moze da bude van opsega ponude");
                    dateTimePicker1.Value = p1.DatumOd;
                }
            }
            else
            {
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (p1!=null)
            {
                if (dateTimePicker2.Value <= p1.DatumDo)
                {
                    if (dateTimePicker2.Value >= dateTimePicker1.Value)
                    {
                        int dani = (dateTimePicker2.Value - dateTimePicker1.Value).Days;
                        textBox1.Text = (p1.CenaPoDanu * (dani+1)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("2Datum Do ne moze biti manji od datuma Od");                        
                        dateTimePicker2.Value = p1.DatumDo;
                    }
                }
                else
                {
                    MessageBox.Show("Datum ne moze da bude van opsega ponude");
                    dateTimePicker2.Value = p1.DatumDo;
                }
            }
            else
            {
                dateTimePicker2.Value = DateTime.Today;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            string[] podeli = str.Split(' ');
            Rezervacija r = new Rezervacija(int.Parse(podeli[1]), k1.Id, dateTimePicker1.Value, dateTimePicker2.Value, double.Parse(textBox1.Text));

            foreach (Kupac k in RadSaDatotekama.kupci)
            {
                if (k.Id == k1.Id)
                {
                    k.Rezervacije.Add(r);
                }
            }
            MessageBox.Show("Uspesno ste rezervisali auto");
        }
    }
}
