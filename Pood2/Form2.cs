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

namespace Pood
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void LoadProducts(DataTable products)
        {
            dataGridViewPood.Controls.Clear();

            foreach (DataRow row in products.Rows)
            {
                PictureBox pic = new PictureBox();
                pic.Width = pic.Height = 100;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                string filePath = Path.Combine(Application.StartupPath, @"..\..\Images\", row["Pilt"].ToString());
                if (File.Exists(filePath))
                    pic.Image = Image.FromFile(filePath);

                dataGridViewPood.Controls.Add(pic);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}