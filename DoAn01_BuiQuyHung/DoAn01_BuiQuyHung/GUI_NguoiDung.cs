using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace DoAn01_BuiQuyHung
{
    public partial class GUI_NguoiDung : Form
    {
        BUS_NguoiDung busnd = new BUS_NguoiDung();
        public GUI_NguoiDung()
        {
            InitializeComponent();
        }

        private void GUI_NguoiDung_Load(object sender, EventArgs e)
        {
            dgvDanhSachNguoiDung.DataSource = busnd.getNguoiDung();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string userid = txbMaUser.Text;
            string pass = txbPass.Text;
            string per = cbbQuyenHan.Text;
            DTO_NguoiDung nd = new DTO_NguoiDung(userid, pass, per);
            if (busnd.kiemtramatrung(userid) == 1)
            {
                MessageBox.Show("UserID đã tồn tại, vui lòng nhập mã khác!");
            }
            else if (txbMaUser.Text == "")
            {
                MessageBox.Show("Mã User chưa nhập, vui lòng nhập mã!");
            }
            else if (txbPass.Text == "")
            {
                MessageBox.Show("Password chưa nhập, vui lòng nhập Password!");
            }
            else if (cbbQuyenHan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn quyền, vui lòng chọn quyền!");
            }
            else
            {
                if (busnd.themNguoiDung(nd) == true)
                {
                    MessageBox.Show("Thêm người dùng thành công!");
                    dgvDanhSachNguoiDung.DataSource = busnd.getNguoiDung();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string userid = txbMaUser.Text;
            string pass = txbPass.Text;
            string per = cbbQuyenHan.Text;
            DTO_NguoiDung nd = new DTO_NguoiDung(userid, pass, per);
            if (txbMaUser.Text == "")
            {
                MessageBox.Show("Mã User chưa nhập, vui lòng nhập mã!");
            }
            else if (txbPass.Text == "")
            {
                MessageBox.Show("Password chưa nhập, vui lòng nhập Password!");
            }
            else if (cbbQuyenHan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn quyền, vui lòng chọn quyền!");
            }
            else
            {
                if (busnd.suaNguoiDung(nd) == true)
                {
                    MessageBox.Show("Sửa thông tin người dùng thành công!");
                    dgvDanhSachNguoiDung.DataSource = busnd.getNguoiDung();
                }
            }      
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string userid = txbMaUser.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (busnd.xoaNguoiDung(userid) == true)
                {
                    MessageBox.Show("Xóa thông tin người dùng thành công!");
                    dgvDanhSachNguoiDung.DataSource = busnd.getNguoiDung();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbMaUser.Enabled = true;
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
                txbMaUser.Enabled = true;
                txbPass.Enabled = true;
                cbbQuyenHan.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rbMa.Checked)
            {
                string ma = txtTK.Text;
                busnd.timkiemNguoiDungTheoUserID(ma);
                dgvDanhSachNguoiDung.DataSource = busnd.timkiemNguoiDungTheoUserID(ma);
            }
            else
            {
                string ten = txtTK.Text;
                busnd.timkiemNguoiDungTheoPer(ten);
                dgvDanhSachNguoiDung.DataSource = busnd.timkiemNguoiDungTheoPer(ten);
            }
        }

        private void dgvDanhSachNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txbMaUser.Text = dgvDanhSachNguoiDung[0, hang].Value.ToString();
            txbPass.Text = dgvDanhSachNguoiDung[1, hang].Value.ToString();
            cbbQuyenHan.Text = dgvDanhSachNguoiDung[2, hang].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát cửa sổ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
