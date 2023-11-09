using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace Drive_School_Software
{
    public partial class Form2 : Form
    {
        string name,type;
        public Form2(string name,string type)
        {
            InitializeComponent();
            this.name = name;
            this.type = type;
            if (type == "الشفهي")
            {
                refr();
            }
            else if (type == "المناورات")
            {
                refr2();
            }
            else
            {
                refr3();
            }
        }
      /*  List<Students> get_studs(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                order.Add(new Students { id = Convert.ToInt32(dt.Rows[i][0].ToString()), name = dt.Rows[i][1].ToString(), birth = dt.Rows[i][2].ToString(), cat = dt.Rows[i][3].ToString()});
            
            }
            return order;
        }*/
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AutoDriveDB;Integrated Security=True");
        DataSet dt = new DataSet();
        List<Students> order = new List<Students>();
        void refr()
        {
            this.reportViewer1.RefreshReport();
            dt.Clear();
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("printer_of_1", sqlcon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.Fill(dt);
            ReportParameter nomclient = new ReportParameter("name", name);
            ReportParameter typep = new ReportParameter("type", type);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { nomclient, typep });
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.Refresh();
            sqlcon.Close();
        }
        void refr2()
        {
            this.reportViewer1.RefreshReport();
            dt.Clear();
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("printer_of_2", sqlcon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.Fill(dt);
            ReportParameter nomclient = new ReportParameter("name", name);
            ReportParameter typep = new ReportParameter("type", type);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { nomclient, typep });
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.Refresh();
            sqlcon.Close();
        }
        void refr3()
        {
            this.reportViewer1.RefreshReport();
            dt.Clear();
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("printer_of_3", sqlcon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.Fill(dt);
            ReportParameter nomclient = new ReportParameter("name", name);
            ReportParameter typep = new ReportParameter("type", type);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { nomclient, typep });
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.Refresh();
            sqlcon.Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (type == "الشفهي")
            {
                refr();
            }
            else if (type == "المناورات")
            {
                refr2();
            }
            else
            {
                refr3();
            }
        }
    }
}
