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
using DTO;
using BUS;

namespace DoAn01_BuiQuyHung
{
    public partial class GUI_DanhMucSanPham : Form
    {
        BUS_DanhMucSanPham busdmsp = new BUS_DanhMucSanPham();
        public GUI_DanhMucSanPham()
        {
            InitializeComponent();
        }
        private void GUI_DanhMucSanPham_Load(object sender, EventArgs e)
        {
            dgvDanhMuc.DataSource = busdmsp.getDanhMucSanPham();
            dgvDanhMuc.Columns[0].HeaderText = "Mã danh mục";
            dgvDanhMuc.Columns[1].HeaderText = "Tên danh mục";
        }
        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaDM.Text = dgvDanhMuc[0, hang].Value.ToString();
            txtTenDM.Text = dgvDanhMuc[1, hang].Value.ToString();

        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDM.Enabled = true;
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
                txtTenDM.Enabled = true;
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
            string ma = txtMaDM.Text;
            string ten = txtTenDM.Text;
            DanhMucSanPham dmsp = new DanhMucSanPham(ma, ten);
            if (busdmsp.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã trùng");
            }
            else if (txtMaDM.Text == "")
            {
                MessageBox.Show("Mã danh mục sản phẩm chưa nhập, vui lòng nhập mã danh mục sản phẩm!");
            }
            else if (txtTenDM.Text == "")
            {
                MessageBox.Show("Tên danh mục sản phẩm chưa nhập, vui lòng nhập tên danh mục sản phẩm!");
            }
            else
            {
                if (busdmsp.themDMSP(dmsp) == true)
                {
                    MessageBox.Show("Thêm danh mục thành công");
                    dgvDanhMuc.DataSource = busdmsp.getDanhMucSanPham();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaDM.Text;
            string ten = txtTenDM.Text;
          DanhMucSanPham dmsp = new DanhMucSanPham(ma, ten);
            if (txtMaDM.Text == "")
            {
                MessageBox.Show("Mã danh mục sản phẩm chưa nhập, vui lòng nhập mã danh mục sản phẩm!");
            }
            else if (txtTenDM.Text == "")
            {
                MessageBox.Show("Tên danh mục sản phẩm chưa nhập, vui lòng nhập tên danh mục sản phẩm!");
            }
            else
            {
                if (busdmsp.suaDMSP(dmsp) == true)
                {
                    MessageBox.Show("Sửa danh mục thành công");
                    dgvDanhMuc.DataSource = busdmsp.getDanhMucSanPham();
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Bạn cần xóa hàng hóa trước khi xóa danh mục sản phẩm, hãy kiểm tra !!!");
            string ma = txtMaDM.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busdmsp.xoaDMSP(ma) == true)
                {
                    MessageBox.Show("Xoá danh mục thành công");
                    dgvDanhMuc.DataSource = busdmsp.getDanhMucSanPham();
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
                busdmsp.TKTen(ten);
                dgvDanhMuc.DataSource = busdmsp.TKTen(ten);

            
        }
    }
}
