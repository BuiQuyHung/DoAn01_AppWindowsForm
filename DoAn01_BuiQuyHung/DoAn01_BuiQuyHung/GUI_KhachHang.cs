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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DoAn01_BuiQuyHung
{
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang buskh = new BUS_KhachHang();
        public GUI_KhachHang()
        {
            InitializeComponent();
        }
        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            dgvDSKhachHang.DataSource = buskh.getKhachHang();
            dgvDSKhachHang.Columns[0].HeaderText = "Mã KH";
            dgvDSKhachHang.Columns[1].HeaderText = "Tên KH";
            dgvDSKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvDSKhachHang.Columns[3].HeaderText = "Điện thoại";
        }
        private void dgvDSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaKH.Text = dgvDSKhachHang[0, hang].Value.ToString();
            txtTenKH.Text = dgvDSKhachHang[1, hang].Value.ToString();
            txtDiaChi.Text = dgvDSKhachHang[2, hang].Value.ToString();
            txtDienThoai.Text = dgvDSKhachHang[3, hang].Value.ToString();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = true;
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
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
            }
            foreach (Control ctrl in groupBox5.Controls)
            {
               if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                //if (ctrl is RadioButton)
                //{
                //    (ctrl as RadioButton).Checked = false;
                //}
                txtTimKiem.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            KhachHang kh = new KhachHang(ma, ten, diachi, dt);
            if (buskh.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã trùng");
            }
            else if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng chưa nhập, vui lòng nhập mã khách hàng!");
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng chưa nhập, vui lòng nhập tên khách hàng!");
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
                if (buskh.themKH(kh) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvDSKhachHang.DataSource = buskh.getKhachHang();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            KhachHang kh = new KhachHang(ma, ten, diachi, dt);
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng chưa nhập, vui lòng nhập mã khách hàng!");
            }
            else if (txtTenKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng chưa nhập, vui lòng nhập tên khách hàng!");
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
                if (buskh.suaKH(kh) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvDSKhachHang.DataSource = buskh.getKhachHang();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (buskh.xoaKH(ma) == true)
                {
                    MessageBox.Show("Xoá thành công");
                    dgvDSKhachHang.DataSource = buskh.getKhachHang();
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
                buskh.TKTen(ten);
                dgvDSKhachHang.DataSource = buskh.TKTen(ten);
            
        }
    }
}
