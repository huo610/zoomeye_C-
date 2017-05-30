using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace zoomeye
{
    public partial class login : Form
    {
        List<string> users = new List<string>();
        public login()
        {
            InitializeComponent();
            update();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 myfrom = new Form1();
            myfrom.username = comboBox1.Text;
            myfrom.password = textBox1.Text;
            if (!myfrom.login())
            {
                return;
            }
            this.Hide();
            myfrom.ShowDialog();
            this.Visible = true;
            
        }
        private void update()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(path + "users"))
            {
                StreamReader sr = new StreamReader(path+ "users", Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    users.Add(line.ToString());
                }
                sr.Close();
            }
            else
            {
                File.Create(path + "users");
            }
            comboBox1.Items.Clear();
            foreach(string str in users)
            {
                comboBox1.Items.Add(str);
            }
        }
    }
}
