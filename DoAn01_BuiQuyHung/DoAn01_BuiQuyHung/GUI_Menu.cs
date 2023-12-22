using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn01_BuiQuyHung
{
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }
        private void GUI_Menu_Load(object sender, EventArgs e)
        {
            if (Program.code == 0)
            {

                BaoCaoToolStripMenuItem.Enabled = false;
                ThongKeToolStripMenuItem.Enabled = false;
                mnuNguoiDung.Enabled = false;
                mnuQLNV.Enabled = false;

               
            }
            else
            {
                ThongKeToolStripMenuItem.Enabled = true;
                BaoCaoToolStripMenuItem.Enabled = true;
            }
        }
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát cửa sổ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuQLDM_Click(object sender, EventArgs e)
        {
            GUI_DanhMucSanPham f = new GUI_DanhMucSanPham();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLNCC_Click(object sender, EventArgs e)
        {
            GUI_NhaCungCap f = new GUI_NhaCungCap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLHH_Click(object sender, EventArgs e)
        {
            GUI_HangHoa f = new GUI_HangHoa();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLKH_Click(object sender, EventArgs e)
        {
            GUI_KhachHang f = new GUI_KhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLNV_Click(object sender, EventArgs e)
        {
            GUI_NhanVien f = new GUI_NhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLHDB_Click(object sender, EventArgs e)
        {
            GUI_HoaDonBan f = new GUI_HoaDonBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuQLHDN_Click(object sender, EventArgs e)
        {
            GUI_HoaDonNhap f = new GUI_HoaDonNhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            GUI_NguoiDung f = new GUI_NguoiDung();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void sảnPhẩmTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoHangTonKho f = new BaoCaoHangTonKho();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thanhToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu f = new BaoCaoDoanhThu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void nộpPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoHangBanChay f = new BaoCaoHangBanChay();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
