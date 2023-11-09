using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Drive_School_Software
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source =.\SQLEXPRESS;Initial Catalog = AutoDriveDB; Integrated Security = True");
        public Form3()
        {
            InitializeComponent();
        }
        private void show_all()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("show_candidates_2", sqlcon);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            show_all();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != string.Empty)
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("search_candidates_2", sqlcon);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@name", textBox5.Text);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                sqlcon.Close();
            }
            else
            {
                show_all();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
    }
}
