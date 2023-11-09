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
using System.Collections;

namespace Drive_School_Software
{
    public partial class graduate_for_drivers : Form
    {
        public graduate_for_drivers()
        {
            InitializeComponent();

        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutoDriveDB;Integrated Security=True");
        void affichage()
        {
            
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter("affichage_1_list", sqlcon);
            SqlDataAdapter sda2 = new SqlDataAdapter("affichage_2_list", sqlcon);
            SqlDataAdapter sda3 = new SqlDataAdapter("affichage_3_list", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            sqlcon.Close();
        }
        void modify(int id, string result)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("update_result", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@result", result);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        void chreno(int id)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("add_to_2_list", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.ExecuteNonQuery();           
            sqlcon.Close();
        }
        void Drive(int id)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("add_to_3_list", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
   


        private void graduate_for_drivers_Load(object sender, EventArgs e)
        {
            affichage();
            string[] datasource = { "غائب", "راسب", "ناجح" };
            comboBox1.Items.AddRange(datasource.ToArray());
            comboBox2.Items.AddRange(datasource.ToArray());
            comboBox3.Items.AddRange(datasource.ToArray());
        }

        private void changed(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (dataGridView1.Rows.Count - 1 != 0 && dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (comboBox3.SelectedIndex == 0 || comboBox3.SelectedIndex == 1)
                    {
                        MessageBox.Show(dataGridView1.CurrentRow.Cells[3].Value.ToString() + " IS staying here ");
                        modify(id, dataGridView1.CurrentCell.Value.ToString());
                        label12.Text = id.ToString();
                    }
                    else if (comboBox3.SelectedIndex == 2)
                    {

                        chreno(id);
                        MessageBox.Show(dataGridView1.CurrentRow.Cells[3].Value.ToString() + " IS PASSED TO CHRENO");
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    affichage();
                }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count - 1 != 0 && dataGridView2.CurrentRow.Index != dataGridView2.Rows.Count - 1)
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
                {
                    MessageBox.Show(dataGridView2.CurrentRow.Cells[3].Value.ToString() + " IS staying here ");
                    modify(id, dataGridView2.CurrentCell.Value.ToString());  
                    label10.Text = id.ToString();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Drive(id);
                    MessageBox.Show(dataGridView2.CurrentRow.Cells[3].Value.ToString() + " IS PASSED TO DRIVING EXAM");
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                }
               
                    comboBox1.ResetText();
                
                affichage();
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count - 1 != 0 && dataGridView3.CurrentRow.Index != dataGridView3.Rows.Count - 1)
            {
                if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 1)
                {
                    MessageBox.Show(dataGridView3.CurrentRow.Cells[3].Value.ToString() + " IS staying here ");
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    MessageBox.Show(dataGridView3.CurrentRow.Cells[3].Value.ToString() + " IS  finishing his license drive");
                    dataGridView3.Rows.Remove(dataGridView3.CurrentRow);
                }
                affichage();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 != 0 && dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                label12.Text = id.ToString();
                label10.Text = label9.Text = "0";
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count - 1 != 0 && dataGridView2.CurrentRow.Index != dataGridView2.Rows.Count - 1)
            {
                int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                label10.Text = id.ToString();
                label12.Text = label9.Text = "0";
            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count - 1 != 0 && dataGridView3.CurrentRow.Index != dataGridView3.Rows.Count - 1)
            {
                int id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value);
                label9.Text = id.ToString();
                label12.Text = label10.Text = "0";
            }
        }
    }
}
