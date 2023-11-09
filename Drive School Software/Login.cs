using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive_School_Software
{
    public partial class Login : Form
    {
        ContactUs contactUs;
        public Login()
        {
            InitializeComponent();
            contactUs = new ContactUs();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {      
                if (user.Text == "Enter your username")
                {
                    user.Text = "";
                    user.ForeColor = Color.Black;
                }
        }

        private void pw_Click(object sender, EventArgs e)
        {
            if (pw.Text == "Enter your account password")
            {
                pw.Text = "";
                pw.ForeColor = Color.Black;
                pw.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contactUs.Show();

        }
    }
}
