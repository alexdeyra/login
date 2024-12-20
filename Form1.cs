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

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<User> list = new List<User>();
      

        void LoadData()
        {
            list.Clear();
            StreamReader sr = File.OpenText("data.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(' ');
                User user = new User(line[0], line[1], line[2], line[3]);
                list.Add(user);
            }
            sr.Close();
        }
        void SaveData()
        {
            StreamWriter sw = File.CreateText("data.txt");
            foreach (User user in list)
            {
                sw.WriteLine($"{user.login} {user.password} {user.name} {user.type}");
            }
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length >= 8 && (!textBox2.Text.Contains(' ')) && textBox3.Text != "" && (comboBox1.Text == "Продавец" || comboBox1.Text == "Покупатель"))
                    {
                        bool symbols = false;
                        bool highLetter = false;
                        bool lowLetter = false;
                        foreach (Char chr in textBox2.Text)
                        {
                            if (!Char.IsLetterOrDigit(chr))
                            {
                                symbols = true;
                            }
                            if (Char.IsLetter(chr) && chr == Char.ToUpper(chr))
                            {
                                highLetter = true;
                            }
                            if (Char.IsLetter(chr) && chr == Char.ToLower(chr))
                            {
                                lowLetter = true;
                            }
                        }
                        if (symbols && highLetter && lowLetter)
                        {
                            User user = new User(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
                            bool completed = false;
                            foreach (User userList in list)
                            {
                                if (userList.login != textBox1.Text)
                                {
                                    completed = true;

                                }
                            }
                            if (!completed)
                            {
                                MessageBox.Show("Такой аккаунт уже существует");
                            }
                            else
                            {
                                MessageBox.Show("Успешная регистрация");
                            }
                            list.Add(user);
                            SaveData();
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен состоять из маленьких и больших букв и со спец. символами");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введены данные, пароль должен быть не менее 8 символов, без пробелов");
                    }
                    break;
                case 1:
                    if (textBox5.Text != "" && textBox6.Text != "")
                    {
                        User loginedUser = new User(null,null,null,null);
                        bool completed = false;
                        foreach (User user in list)
                        {
                            if (user.login == textBox5.Text && user.password == textBox6.Text)
                            {
                                loginedUser = user;
                                completed = true;
                            }
                        }
                        if (!completed)
                        {
                            MessageBox.Show("Данные введены неверно");
                        }
                        else
                        {
                            MessageBox.Show("Вы успешно вошли в аккаунт");
                            User.logined = loginedUser;
                            if (loginedUser.type == "Продавец")
                            {
                                main mainForm = new main();
                                mainForm.Show();
                            }
                            else
                            {
                                client clientForm = new client();
                                clientForm.Show();
                            }
                           
                        }
                        
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '\0';
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '*';
        }
    }
}
