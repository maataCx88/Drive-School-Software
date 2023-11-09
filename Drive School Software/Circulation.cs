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
    public partial class Circulation : Form
    {
        public Circulation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                label9.Text = textBox1.Text;
            }
            else
            {
                label9.Text = " اسم و لقب الممتحن ";
            }
        }
    }
}
