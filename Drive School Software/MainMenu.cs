using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive_School_Software
{
    public partial class MainMenu : Form
    {
        Chreno chreno; Circulation circ; Form1 diag; graduate_for_drivers graduate_For_Drivers; List_of_participant_chreno list_Of_Participant_Chreno; List_of_participant_Circulation list_Of_Participant_Circulation; List_of_Participant list_Of_Participant; Login login;ContactUs contactUs;
        int c = 0;
        public MainMenu()
        {
            InitializeComponent();
            chreno = new Chreno();
            circ = new Circulation();
            diag = new Form1();
            graduate_For_Drivers = new graduate_for_drivers();
            list_Of_Participant_Chreno = new List_of_participant_chreno();
            list_Of_Participant_Circulation = new List_of_participant_Circulation();
            list_Of_Participant = new List_of_Participant();
            login = new Login();
            contactUs = new ContactUs();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            date.Text= DateTime.Now.ToString("dddd dd MMMM yyyy", new CultureInfo("ar-AE"));
            time.Text= DateTime.Now.ToString("hh:mm:ss");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            diag.Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            circ.Show();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            chreno.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            
            list_Of_Participant.Show();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
           
            list_Of_Participant_Circulation.Show();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
       
            list_Of_Participant_Chreno.Show();
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            graduate_For_Drivers.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show(" هل تريد الخروج من البرنامج ؟         ", "....تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                login.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                contactUs.Show();
            }
            catch (Exception)
            {
                contactUs = new ContactUs();
                contactUs.Show();
            }
        }
    }
}
