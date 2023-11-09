using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Drive_School_Software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int s = 1;
        
        SqlConnection sqlcon = new SqlConnection("Data Source =.\\SQLEXPRESS;Initial Catalog = AutoDriveDB; Integrated Security = True");
        int i = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("هل تود اضافة قائمة جديدة للمتححنين؟","اضافة قائمة",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(rs== DialogResult.Yes)
            {
                
            }
        }
        void ajouter_candidat(string name,string lastname,int birthday,string cc ,string result)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlDbType sd = new SqlDbType();
            
            SqlCommand sqlcmd = new SqlCommand("add_to_1_list", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@name", name);
            //sqlcmd.Parameters["@name"].Value = name;
            sqlcmd.Parameters.AddWithValue("@lastname", lastname);
            //sqlcmd.Parameters["@lastname"].Value = lastname;
            sqlcmd.Parameters.AddWithValue("@birth", birthday);
            sqlcmd.Parameters.AddWithValue("@CatCC", cc);
            //sqlcmd.Parameters["@CatCC"].Value = cc;
            sqlcmd.Parameters.AddWithValue("@Result", result) ;
            //sqlcmd.Parameters["@Result"].Value = SqlDbType.NVarChar.ToString(name);
            sqlcmd.ExecuteNonQuery();
            
            sqlcon.Close();
        }
        void populate()
        {
            
            
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
               
            }
           /**/

        }
        private void show_all()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("show_candidates", sqlcon);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 1;
            textBox1.Focus();
            // dateTimePicker1.Format = DateTimePickerFormat.Custom;
              //dateTimePicker1.CustomFormat = "dd ddd MMM yyyy";
              //  dateTimePicker1.ShowUpDown = true;
            show_all();
            load_price();
            

        }
        private void load_price()
        {
            string query = "select Category from dbo.ListOfExams where idlist=4;";
            SqlCommand command = sqlcon.CreateCommand();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox7.Text= dt.Rows[0][0].ToString();
            sqlcon.Close();
        }
        private void set_price()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            string query = "update dbo.ListOfExams set Category="+textBox7.Text+" where idlist=4;";
            SqlCommand command = new SqlCommand(query,sqlcon);
            command.ExecuteNonQuery();
            MessageBox.Show("تم الحفظ بنجاح");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                label9.Text = textBox1.Text;
            }
            else
            {
                label9.Text = " اسم و لقب الممتحن ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == string.Empty || textBox1.Text == string.Empty || textBox1.Text == string.Empty)
            {
                MessageBox.Show("يجب ملأ جميع المعلومات من فضلكم");
            }
            else
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("add_to_1_list", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox2.Text);
                sqlcmd.Parameters.AddWithValue("@lastname", textBox3.Text);
                sqlcmd.Parameters.AddWithValue("@birth", dateTimePicker1.Value.ToShortDateString());
                sqlcmd.Parameters.AddWithValue("@filenum", textBox4.Text);
                sqlcmd.Parameters.AddWithValue("@CatCC", comboBox2.Text);
                sqlcmd.Parameters.AddWithValue("@montant", Convert.ToDecimal(textBox7.Text));
                sqlcmd.Parameters.AddWithValue("@verse", Convert.ToDecimal(textBox6.Text));
                sqlcmd.Parameters.AddWithValue("@reste", Convert.ToDecimal(textBox1.Text));
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();

                show_all();
                clear();
            }


        }
        private void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox6.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            load_price();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            List_of_Participant lps = new List_of_Participant();
            lps.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox3.Text = string.Empty;
            textBox2.Focus();
            s = 1;
            string nom, prénom  , result , category = "";int birth;
            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
            if (dataGridView1.Rows.Count-1 != 0)
            {
                for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    nom = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    prénom = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    birth =  Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    category = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    //result = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    combo.Value = dataGridView1.Rows[i].Cells[5].Value;
                    if (combo.Value == null)
                    {
                        result = DBNull.Value.ToString();
                        
                    }
                    else
                    {
                        result = dataGridView1.Rows[i].Cells[5].Value.ToString(); 
                    }
                    ajouter_candidat(nom, prénom, birth, category, result);
                }
            }
            
            MessageBox.Show("تم حفظ القائمة بنجاح");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("update_candidate", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(selected));
            sqlcmd.Parameters.AddWithValue("@name", textBox2.Text);
            sqlcmd.Parameters.AddWithValue("@lastname", textBox3.Text);
            sqlcmd.Parameters.AddWithValue("@birth", dateTimePicker1.Value.ToShortDateString());
            sqlcmd.Parameters.AddWithValue("@filenum", textBox4.Text);
            sqlcmd.Parameters.AddWithValue("@CatCC", comboBox2.Text);
            sqlcmd.Parameters.AddWithValue("@montant", Convert.ToDecimal(textBox7.Text));
            sqlcmd.Parameters.AddWithValue("@verse", Convert.ToDecimal(textBox6.Text));
            sqlcmd.Parameters.AddWithValue("@reste", Convert.ToDecimal(textBox1.Text));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            show_all();
            clear();
            selected = "-1";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult rs = MessageBox.Show("هل تود تسجيل الخروج ؟", "تسجيل خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //string[] datasource = { "ناجح", "راسب" };
          //  DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
          //  combo.DataSource = datasource.ToList();
           // dataGridView1.Rows[i].Cells[5] = combo;
          //  i++;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count - 1 != 0 && dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
            {
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "راسب")
                {
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " IS staying here ");
                }
                else
                {
                    MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString() + " IS PASSED TO CHRENO");
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != string.Empty)
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("search_candidates", sqlcon);
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }
        string selected = "-1";

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            selected = "-1";
            clear();
            button1.Enabled = true;
            button5.Enabled = true;
            load_price();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            }
            catch (Exception) { }
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "أ")
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.SelectedIndex = 1;
            }
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            try
            {
                selected = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception) { }
            button1.Enabled = false;

            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("tabtoinf", sqlcon);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(selected));
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            textBox2.Text = dtbl.Rows[0][0].ToString();
            textBox3.Text = dtbl.Rows[0][1].ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox7.Enabled = false;
            button5.Enabled = true;
            set_price();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            button5.Enabled = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != string.Empty && textBox6.Text != ".")
            {
                textBox1.Text = (Convert.ToDecimal(textBox7.Text) - Convert.ToDecimal(textBox6.Text)).ToString();
            }
            else
            {
                textBox1.Text = "0";
            }
        }
    }
}
