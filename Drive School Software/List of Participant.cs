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
    public partial class List_of_Participant : Form
    {
        public List_of_Participant()
        {
            InitializeComponent();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("جاري عملبة الطباعة");
        }
        void repeter()
        {
            for(int i=0;i <= dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        Point lastPoint;
        private void List_of_Participant_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void List_of_Participant_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
