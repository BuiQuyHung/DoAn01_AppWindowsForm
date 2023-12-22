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
    public partial class BaoCaoHangTonKho : Form
    {
        public BaoCaoHangTonKho()
        {
            InitializeComponent();
        }

        private void crvProducts_Load(object sender, EventArgs e)
        {
            crpProducts rpt = new crpProducts();
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True");
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("Select * from HangHoa", conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            rpt.SetDataSource(ds.Tables[0]);
            crvProducts.ReportSource = rpt;
        }
    }
}
