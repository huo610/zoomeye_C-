using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoomeye
{
    public partial class Messagecs : Form
    {
        string output = "";
        public Messagecs()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void update(string s,int a,int b)
        {
            this.Location =new Point( a,b);

            textBox1.Text = s;
        }

        private void Messagecs_Load(object sender, EventArgs e)
        {

        }
    }
}
