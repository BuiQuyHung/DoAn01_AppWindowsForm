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
using BUS;
using DTO;

namespace DoAn01_BuiQuyHung
{
    public partial class GUI_HangHoa : Form
    {
        BUS_HangHoa bussp = new BUS_HangHoa();
        public GUI_HangHoa()
        {
            InitializeComponent();
        }
        private void GUI_HangHoa_Load(object sender, EventArgs e)
        {
            dgvDSSP.DataSource = bussp.getHangHoa();
            dgvDSSP.Columns[0].HeaderText = "Mã SP";
            dgvDSSP.Columns[1].HeaderText = "Tên SP";
            dgvDSSP.Columns[2].HeaderText = "Mã Danh Mục";
            dgvDSSP.Columns[3].HeaderText = "Số Lượng";
            dgvDSSP.Columns[4].HeaderText = "Ghi Chú";
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaSP.Text = dgvDSSP[0, hang].Value.ToString();
            txtTenSP.Text = dgvDSSP[1, hang].Value.ToString();
            txtMaDM.Text = dgvDSSP[2, hang].Value.ToString();
            txtSoLuong.Text = dgvDSSP[3, hang].Value.ToString();
            txtGhiChu.Text = dgvDSSP[4, hang].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).Text = "";
                }
                txtTenSP.Enabled = true;
                txtMaDM.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGhiChu.Enabled = true;
            }
            foreach (Control ctrl in groupBox4.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
                txtTimKiem.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaSP.Text;
            string ten = txtTenSP.Text;
            string madm = txtMaDM.Text;
            float sl = float.Parse(txtSoLuong.Text);
            string ghichu = txtGhiChu.Text;
          HangHoa sp = new HangHoa(ma, ten, madm, sl, ghichu);
            if (bussp.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã trùng");
            }
            else if (txtMaSP.Text == "")
            {
                MessageBox.Show("Mã sản phẩm chưa nhập, vui lòng nhập mã sản phẩm!");
            }
            else if (txtTenSP.Text == "")
            {
                MessageBox.Show("Tên sản phẩm chưa nhập, vui lòng nhập tên sản phẩm!");
            }
            else if (txtMaDM.Text == "")
            {
                MessageBox.Show("Mã danh mục chưa nhập, vui lòng nhập mã danh mục!");
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng chưa nhập, vui lòng nhập số lượng!");
            }
            else if (txtGhiChu.Text == "")
            {
                MessageBox.Show("Ghi chú chưa nhập, vui lòng nhập ghi chú!");
            }
            else
            {
                if (bussp.themSP(sp) == true)
                {
                    MessageBox.Show("Thêm thông tin hóa đơn bán thành công!");
                    dgvDSSP.DataSource = bussp.getHangHoa();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaSP.Text;
            string ten = txtTenSP.Text;
            string madm = txtMaDM.Text;
            float sl = float.Parse(txtSoLuong.Text);
            string ghichu = txtGhiChu.Text;
            HangHoa sp = new HangHoa(ma, ten, madm, sl, ghichu);
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Mã sản phẩm trống, vui lòng nhập mã sản phẩm!");
            }
            else if (txtTenSP.Text == "")
            {
                MessageBox.Show("Tên sản phẩm trống, vui lòng nhập tên sản phẩm!");
            }
            else if (txtMaDM.Text == "")
            {
                MessageBox.Show("Mã danh mục trống, vui lòng nhập mã danh mục !");
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng trống, vui lòng nhập số lượng!");
            }
            else if (txtGhiChu.Text == "")
            {
                MessageBox.Show("Ghi chú trống, vui lòng nhập ghi chú!");
            }
            else
            {
                if (bussp.suaSP(sp) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvDSSP.DataSource = bussp.getHangHoa();
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSP.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (bussp.xoaSP(ma) == true)
                {
                    MessageBox.Show("Xoá thành công");
                    dgvDSSP.DataSource = bussp.getHangHoa();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát cửa sổ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //if (rbMa.Checked)
            //{
            //    string ma = txtTimKiem.Text;
            //    bussp.TKMa(ma);
            //    dgvDSSP.DataSource = bussp.TKMa(ma);
            //}
            //else
            //{
                string ten = txtTimKiem.Text;
                bussp.TKTen(ten);
                dgvDSSP.DataSource = bussp.TKTen(ten);
            
        }
    }
}
