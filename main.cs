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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace login
{
    public partial class main : Form
    {

        public main()
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

            dataGridView1.Rows.Clear();
            foreach (Product product in list)
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, product.name, product.price, product.count, product.place, product.visual, product.owner);
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

        private void main_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1 && !textBox1.Text.Contains(' '))
            {
                Product product = new Product(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), textBox2.Text, User.logined.name);
                list.Add(product);
                SaveData();
                LoadData();
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int id) && id > 0 && id <= list.Count)
            {
                Product product = list[id - 1];
                product.name = textBox1.Text;
                product.price = Convert.ToDouble(numericUpDown1.Value);
                product.count = Convert.ToInt32(numericUpDown2.Value);
                product.place = Convert.ToInt32(numericUpDown3.Value);
                product.visual = textBox2.Text;

                SaveData();
                LoadData();
                MessageBox.Show("Изменения сохранены.");
            }
            else
            {
                MessageBox.Show("Неверный ID товара.");
            }
        }
        public class Product
        {
            public string name;
            public double price;
            public int count;
            public int place;
            public string visual;
            public string owner;

            public Product(string name, double price, int count, int place, string visual, string owner)
            {
                this.name = name;
                this.price = price;
                this.count = count;
                this.place = place;
                this.visual = visual;
                this.owner = owner;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int id) && id > 0 && id <= list.Count)
            {
                Product product = list[id - 1];
                textBox1.Text = product.name;
                numericUpDown1.Value = (decimal)product.price;
                numericUpDown2.Value = product.count;
                numericUpDown3.Value = product.place;
                textBox2.Text = product.visual;
            }
            else
            {
                MessageBox.Show("Неверный ID товара.");
            }
        }
    }
}
