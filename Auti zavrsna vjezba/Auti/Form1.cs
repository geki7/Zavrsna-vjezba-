using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillProizvodac();
        }

        public void FillProizvodac()
        {
            using(var context = new Labs2022Entities())
            {
                var query = from p in context.Cars
                            select p.Manufacturer;

                comboBox1.DataSource = query.Distinct().ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string odabrani = comboBox1.SelectedItem.ToString();

            using (var context = new Labs2022Entities())
            {
                var query = from p in context.Cars
                            where p.Manufacturer == odabrani
                            select p.Model;

                comboBox2.DataSource = query.Distinct().ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string odabrani = comboBox1.SelectedItem.ToString();
            string odabranimodel = comboBox2.SelectedItem.ToString();

            using (var context = new Labs2022Entities())
            {
                var query = from p in context.Cars
                            where p.Manufacturer == odabrani && p.Model == odabranimodel
                            select p;

                dataGridView1.DataSource = query.ToList();
            }

        }
    }
}
