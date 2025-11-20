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

        public void LoadProducts(DataTable ToodeTabel)
        {
            
            dataGridViewPood.Controls.Clear();

            
            foreach (DataColumn col in ToodeTabel.Columns)
            {
                Console.WriteLine("Veerg: " + col.ColumnName);
            }

            
            foreach (DataRow row in ToodeTabel.Rows)
            {
                PictureBox pic = new PictureBox();
                pic.Width = 120;
                pic.Height = 120;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                string imagesPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Image"));
                string filePath = Path.Combine(imagesPath, row["Pilt"].ToString());

                if (File.Exists(filePath))
                    pic.Image = Image.FromFile(filePath);
                else
                    pic.BackColor = Color.Gray; 

                
                pic.Tag = row;

                pic.Click += Pic_Click;

                
                dataGridViewPood.Controls.Add(pic);
            }
        }

        
        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            DataRow product = pic.Tag as DataRow;

            if (product != null)
            {
                string nimi = product["Toodenimetus"].ToString();
                string hind = product["Hind"].ToString();
                string kogus = product["Kogus"].ToString();
                string kategooria = product["Kategooriad"].ToString();
                

                MessageBox.Show(
                    $"Toode: {nimi}\n" +
                    $"Hind: {hind} €\n" +
                    $"Kogus: {kogus}\n" +
                    $"Kategooria: {kategooria}\n",
                    "Tooteinfo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}