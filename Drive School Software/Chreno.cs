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
    public partial class Chreno : Form
    {
        public Chreno()
        {
            InitializeComponent();
        }
        int s = 1;
        private void Chreno_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 1;
            textBox1.Focus();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox1.Text == string.Empty || textBox1.Text == string.Empty)
            {
                MessageBox.Show("يجب ملأ جميع المعلومات من فضلكم");
            }
            else
            {
                string[] row = new string[] { s.ToString(), textBox2.Text, textBox3.Text, dateTimePicker1.Value.Year.ToString(), comboBox2.Text };
                dataGridView1.Rows.Add(row);
                textBox2.Text = textBox3.Text = string.Empty;
                textBox2.Focus();
                s = s + 1;
            }
            s = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graduate_for_drivers dgv = new graduate_for_drivers();
            dgv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox3.Text = string.Empty;
            textBox2.Focus();
            s = 1;
            dataGridView1.Rows.Clear();
            MessageBox.Show("تم حفظ القائمة بنجاح");
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
