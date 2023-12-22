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
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien busnv = new BUS_NhanVien();
        public GUI_NhanVien()
        {
            InitializeComponent();
        }
        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            dgvDSNhanVien.DataSource = busnv.getNhanVien();
            dgvDSNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvDSNhanVien.Columns[1].HeaderText = "Tên NV";
            dgvDSNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvDSNhanVien.Columns[3].HeaderText = "Địa chỉ";
            dgvDSNhanVien.Columns[4].HeaderText = "Điện thoại";
            dgvDSNhanVien.Columns[5].HeaderText = "Ngày sinh";
        }

        private void dgvDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaNV.Text = dgvDSNhanVien[0, hang].Value.ToString();
            txtTenNV.Text = dgvDSNhanVien[1, hang].Value.ToString();
            ckbGioiTinh.Text = dgvDSNhanVien[2, hang].Value.ToString();
            txtDiaChi.Text = dgvDSNhanVien[3, hang].Value.ToString();
            mtbDienThoai.Text = dgvDSNhanVien[4, hang].Value.ToString();
            dtpBir.Text = dgvDSNhanVien[5, hang].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
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
                if (ctrl is MaskedTextBox)
                {
                    (ctrl as MaskedTextBox).Text = "";
                }
                if (ctrl is DateTimePicker)
                {
                    (ctrl as DateTimePicker).Text = "";
                }
                txtTenNV.Enabled = true;
                ckbGioiTinh.Enabled = true;
                txtDiaChi.Enabled = true;
                mtbDienThoai.Enabled = true;
                dtpBir.Enabled = true;
            }
            foreach (Control ctrl in groupBox4.Controls)
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
            string ma = txtMaNV.Text;
            string ten = txtTenNV.Text;
            string gt = ckbGioiTinh.Text;
            string dc = txtDiaChi.Text;
            string dt = mtbDienThoai.Text;
            DateTime ns = DateTime.Parse(dtpBir.Value.ToShortDateString());
            NhanVien nv = new NhanVien(ma, ten, gt, dc, dt, ns);
            if (busnv.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã trùng");
            }
            else if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên chưa nhập, vui lòng nhập mã nhân viên!");
            }
            else if (txtTenNV.Text == "")
            {
                MessageBox.Show("Tên nhân viên chưa nhập, vui lòng nhập tên nhân viên!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ chưa nhập, vui lòng nhập địa chỉ!");
            }
            else if (mtbDienThoai.Text == "")
            {
                MessageBox.Show("SĐT chưa nhập, vui lòng nhập SĐT!");
            }
            else if (dtpBir.Text == "")
            {
                MessageBox.Show("Ngày sinh chưa nhập, vui lòng nhập ngày sinh!");
            }
            else if (ckbGioiTinh.Text == "")
            {
                MessageBox.Show("Giới tính chưa chọn, vui lòng chọn giới tính!");
            }
            else
            {
                if (busnv.themNV(nv) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvDSNhanVien.DataSource = busnv.getNhanVien();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text;
            string ten = txtTenNV.Text;
            string gt = ckbGioiTinh.Text;
            string dc = txtDiaChi.Text;
            string dt = mtbDienThoai.Text;
            DateTime ns = DateTime.Parse(dtpBir.Value.ToShortDateString());
            NhanVien nv = new NhanVien(ma, ten, gt, dc, dt, ns);
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên chưa nhập, vui lòng nhập mã nhân viên!");
            }
            else if (txtTenNV.Text == "")
            {
                MessageBox.Show("Tên nhân viên chưa nhập, vui lòng nhập tên nhân viên!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ chưa nhập, vui lòng nhập địa chỉ!");
            }
            else if (mtbDienThoai.Text == "")
            {
                MessageBox.Show("SĐT chưa nhập, vui lòng nhập SĐT!");
            }
            else if (dtpBir.Text == "")
            {
                MessageBox.Show("Ngày sinh chưa nhập, vui lòng nhập ngày sinh!");
            }
            else if (ckbGioiTinh.Text == "")
            {
                MessageBox.Show("Giới tính chưa chọn, vui lòng chọn giới tính!");
            }
            else
            {
                if (busnv.suaNV(nv) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvDSNhanVien.DataSource = busnv.getNhanVien();
                }
            } 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nếu xóa nhân viên, bạn sẽ xóa hết các hóa đơn liên quan tới nhân viên đó!!!");
            string ma = txtMaNV.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busnv.xoaNV(ma) == true)
                {
                    MessageBox.Show("Xoá thành công");
                    dgvDSNhanVien.DataSource = busnv.getNhanVien();
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
            if (rbMa.Checked)
            {
                string ma = txtTimKiem.Text;
                busnv.TKMa(ma);
                dgvDSNhanVien.DataSource = busnv.TKMa(ma);
            }
            else
            {
                string ten = txtTimKiem.Text;
                busnv.TKTen(ten);
                dgvDSNhanVien.DataSource = busnv.TKTen(ten);
            }
        }
    }
}
