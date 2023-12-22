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
using System.Windows.Media;


namespace DoAn01_BuiQuyHung
{
    
    public partial class GUI_NhaCungCap : Form
    {
        BUS_NhaCungCap busncc = new BUS_NhaCungCap();
        public GUI_NhaCungCap()
        {
            InitializeComponent();
        }
        private void GUI_NhaCungCap_Load(object sender, EventArgs e)
        {
            dgvDSNhaCungCap.DataSource = busncc.getNhaCungCap();
            dgvDSNhaCungCap.Columns[0].HeaderText = "Mã NCC";
            dgvDSNhaCungCap.Columns[1].HeaderText = "Tên NCC";
            dgvDSNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            dgvDSNhaCungCap.Columns[3].HeaderText = "Điện thoại";
        }
        private void dgvDSNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaNCC.Text = dgvDSNhaCungCap[0, hang].Value.ToString();
            txtTenNCC.Text = dgvDSNhaCungCap[1, hang].Value.ToString();
            txtDiaChi.Text = dgvDSNhaCungCap[2, hang].Value.ToString();
            txtDienThoai.Text = dgvDSNhaCungCap[3, hang].Value.ToString();

        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = true;
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
                txtTenNCC.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;    
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
            string ma = txtMaNCC.Text;
            string ten = txtTenNCC.Text;
            string diachi = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            NhaCungCap ncc = new NhaCungCap(ma, ten, diachi, dt);
            if (busncc.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã trùng");
            }
            else if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mã nhà cung cấp chưa nhập, vui lòng nhập mã nhà cung cấp!");
            }
            else if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Tên NCC chưa nhập, vui lòng nhập tên NCC!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ chưa nhập, vui lòng nhập địa chỉ!");
            }
            else if (txtDienThoai.Text == "")
            {
                MessageBox.Show("SĐT chưa nhập, vui lòng nhập SĐT!");
            }
            else
            {
                if (busncc.themNCC(ncc) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvDSNhaCungCap.DataSource = busncc.getNhaCungCap();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            string ma = txtMaNCC.Text;
            string ten = txtTenNCC.Text;
            string diachi = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            NhaCungCap ncc = new NhaCungCap(ma, ten, diachi, dt);
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Mã NCC chưa nhập, vui lòng nhập mã NCC!");
            }
            else if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Tên NCC chưa nhập, vui lòng nhập tên NCC!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ chưa nhập, vui lòng nhập địa chỉ!");
            }
            else if (txtDienThoai.Text == "")
            {
                MessageBox.Show("SĐT chưa nhập, vui lòng nhập SĐT!");
            }
            else
            {
                if (busncc.suaNCC(ncc) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvDSNhaCungCap.DataSource = busncc.getNhaCungCap();
                }
            }   
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNCC.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busncc.xoaNCC(ma) == true)
                {
                    MessageBox.Show("Xoá thành công");
                    dgvDSNhaCungCap.DataSource = busncc.getNhaCungCap();
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
                string ten = txtTimKiem.Text;
                busncc.TKTen(ten);
                dgvDSNhaCungCap.DataSource = busncc.TKTen(ten);
            
        }
    }
}
