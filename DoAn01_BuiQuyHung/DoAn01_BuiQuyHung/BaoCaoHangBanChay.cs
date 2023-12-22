using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn01_BuiQuyHung
{
    public partial class BaoCaoHangBanChay : Form
    {
        public BaoCaoHangBanChay()
        {
            InitializeComponent();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            if (rbNgay.Checked)
            {

                rptHangBanChay rpt = new rptHangBanChay();
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HangBanChayTheoNgay";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(new SqlParameter("@NgayBan", dtpDoanhThu.Value.Date));
                //SqlDataAdapter dap = new SqlDataAdapter("Select * from HangHoa", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (rbThang.Checked)
            {

                rptHangBanChay rpt = new rptHangBanChay();
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HangBanChayTheoThang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(new SqlParameter("@NgayBan", dtpDoanhThu.Value.Date));
                //SqlDataAdapter dap = new SqlDataAdapter("Select * from HangHoa", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (rbNam.Checked)
            {

                rptHangBanChay rpt = new rptHangBanChay();
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HangBanChayTheoNam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add(new SqlParameter("@NgayBan", dtpDoanhThu.Value.Date));
                //SqlDataAdapter dap = new SqlDataAdapter("Select * from HangHoa", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(ds);
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }

        }
    }
}
