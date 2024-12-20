using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }
        List<Product> list = new List<Product>();


        void LoadData()
        {
            list.Clear();
            StreamReader sr = File.OpenText("products.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(' ');
                Product product = new Product(line[0], Convert.ToDouble(line[1]), Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), line[4], line[5]);
                list.Add(product);
            }
            sr.Close();

            Point currPos = new Point(12, 12);

            foreach (Product product in list)
            { 
                Panel panel = new Panel();
                panel.Size = new Size(200, 200);
                panel.BorderStyle = BorderStyle.FixedSingle;
                PictureBox pic = new PictureBox();
                pic.Size = new Size(115,115);
                pic.Location = new Point(36, 0);
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Image = Image.FromFile(product.visual);
                panel.Controls.Add(pic);
                Label label = new Label();
                label.Font = new Font(label.Font.FontFamily, 7, label.Font.Style);
                label.Size = new Size(200, 50);
                label.Location = new Point(2, 120);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = $"Название : {product.name}\nЦена : {product.price}\nКоличество : {product.count}\nИзготовитель : {product.owner}";
                panel.Controls.Add(label);
                Button button = new Button();
                button.Font = new Font(label.Font.FontFamily, 7, label.Font.Style);
                button.Size = new Size(125, 30);
                button.Location = new Point(36, 170);
                button.Text = "Добавить";
                panel.Controls.Add(button);
                flowLayoutPanel1.Controls.Add(panel);
            }
          
        }
        void SaveData()
        {
            StreamWriter sw = File.CreateText("products.txt");
            foreach (Product product in list)
            {
                sw.WriteLine($"{product.name} {product.price} {product.count} {product.place} {product.visual} {product.owner}");
            }
            sw.Close();
        }

        private void client_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void купитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* int index = dataGridView1.CurrentCell.RowIndex;
            list[index].count -= 1;

            double profit = 0;
            StreamReader sr = File.OpenText("profit.txt");
            while (!sr.EndOfStream)
            {
              profit = Convert.ToDouble(sr.ReadLine());
            }
            sr.Close();

            StreamWriter sw = File.CreateText("profit.txt");

            double final = profit + list[index].price;
            sw.WriteLine($"{final}");
            sw.Close();
            SaveData();
            LoadData();*/
        }
    }
}
