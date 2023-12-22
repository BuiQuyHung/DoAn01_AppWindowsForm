using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace DoAn01_BuiQuyHung
{

    public partial class GUI_HoaDonBan : Form
    {
        BUS_ChiTietHoaDonBan buscthdb = new BUS_ChiTietHoaDonBan();
        BUS_HoaDonBan bushdb = new BUS_HoaDonBan();
        BUS_HangHoa buss = new BUS_HangHoa();
        SqlCommand lenh = new SqlCommand();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public GUI_HoaDonBan()
        {
            InitializeComponent();
        }

        private void GUI_HoaDonBan_Load(object sender, EventArgs e)
        {
            dgvCTHDB.DataSource = buscthdb.getCTHDBan();
            dgvHDB.DataSource = bushdb.getHDBan();
            loadcbbMaHDBan_phikn();
            loadcbbMaHang_phikn();
            loadcbbMaNhanVien_phikn();
            loadcbbMaKhachHang_phikn();
        }
        void loadcbbMaHDBan_phikn()
        {
            cbbMaHDBan.DataSource = buscthdb.loadcbbMaHDBan_phikn();
            cbbMaHDBan.DisplayMember = "MaHDBan";
            cbbMaHDBan.ValueMember = "MaHDBan";
        }
        void loadcbbMaHang_phikn()
        {
            cbbMaHang.DataSource = buscthdb.loadcbbMaHang_phikn();
            cbbMaHang.DisplayMember = "MaHang";
            cbbMaHang.ValueMember = "MaHang";
        }

        private void btnLamMoiHDBan_Click(object sender, EventArgs e)
        {
            txtMaHDB.Enabled = true;
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
                txtMaHDB.Enabled = true;
            }
            dgvHDB.DataSource = bushdb.getHDBan();
        }

        private void btnThemHDBan_Click(object sender, EventArgs e)
        {

            string MaHDBan = txtMaHDB.Text;
            DateTime NgayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            string MaNhanVien = cbbNhanVien.Text;
            string MaKhachHang = cbbKhachHang.Text;
            DTO_HoaDonBan hdb = new DTO_HoaDonBan(MaHDBan, NgayBan, MaNhanVien, MaKhachHang);
            if (bushdb.kiemtramatrung(MaHDBan) == 1)
            {
                MessageBox.Show("Mã hóa đơn bán đã tồn tại, vui lòng nhập mã khác!");
            }
            else if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Mã hóa đơn bán chưa nhập, vui lòng nhập mã hóa đơn bán!");
            }
            else if (dtpNgayBan.Text == "")
            {
                MessageBox.Show("Ngày bán chưa nhập, vui lòng nhập ngày bán!");
            }
            else if (cbbNhanVien.Text == "")
            {
                MessageBox.Show("Nhân viên nhập chưa nhập, vui lòng nhập nhân viên nhập!");
            }
            else if (cbbKhachHang.Text == "")
            {
                MessageBox.Show("Khách hàng mua chưa nhập, vui lòng nhập khách hàng mua!");
            }
            else
            {
                if (bushdb.themHoaDonBan(hdb) == true)
                {
                    MessageBox.Show("Thêm thông tin hóa đơn bán thành công!");
                    dgvHDB.DataSource = bushdb.getHDBan();
                    loadcbbMaHDBan_phikn();
                }
            }
        }

        private void btnSuaHDBan_Click(object sender, EventArgs e)
        {
            string MaHDBan = txtMaHDB.Text;
            DateTime NgayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            string MaNhanVien = cbbNhanVien.Text;
            string MaKhachHang = cbbKhachHang.Text;

            DTO_HoaDonBan hdb = new DTO_HoaDonBan(MaHDBan, NgayBan, MaNhanVien, MaKhachHang);
            if (txtMaHDB.Text == "")
            {
                MessageBox.Show("Mã hóa đơn bán chưa nhập, vui lòng nhập mã hóa đơn bán!");
            }
            else if (dtpNgayBan.Text == "")
            {
                MessageBox.Show("Ngày bán chưa nhập, vui lòng nhập ngày bán!");
            }
            else if (cbbNhanVien.Text == "")
            {
                MessageBox.Show("Nhân viên nhập chưa nhập, vui lòng nhập nhân viên nhập!");
            }
            else if (cbbKhachHang.Text == "")
            {
                MessageBox.Show("Khách hàng mua chưa nhập, vui lòng nhập khách hàng mua!");
            }
            else
            {
                if (bushdb.suaHoaDonBan(hdb) == true)
                {
                    MessageBox.Show("Sửa thông tin hóa đơn bán thành công!");
                    dgvHDB.DataSource = bushdb.getHDBan();
                }
            } 
        }

        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn cần xóa Chi tiết hóa đơn bán trước, hãy kiểm tra !!!");
            string ma = txtMaHDB.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (bushdb.xoaHoaDonBan(ma) == true)
                {
                    MessageBox.Show("Xóa thông tin  hóa đơn bán thành công!");
                    dgvHDB.DataSource = bushdb.getHDBan();
                }
            }
        }

        private void btnThoatHDBan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnTimKiemHDBan_Click(object sender, EventArgs e)
        {
            if (rbMaHDBan.Checked)
            {
                string mahdb = txtTKHDBan.Text;
                bushdb.timkiemHoaDonBanTheoMaHDBan(mahdb);
                dgvHDB.DataSource = bushdb.timkiemHoaDonBanTheoMaHDBan(mahdb);
            }
            else
            {
                string makh = txtTKHDBan.Text;
                bushdb.timkiemHoaDonBanTheoMaKhachHang(makh);
                dgvHDB.DataSource = bushdb.timkiemHoaDonBanTheoMaKhachHang(makh);
            }
        }

        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaHDB.Text = dgvHDB[0, hang].Value.ToString();
            dtpNgayBan.Text = dgvHDB[1, hang].Value.ToString();
            cbbNhanVien.Text = dgvHDB[2, hang].Value.ToString();
            cbbKhachHang.Text = dgvHDB[3, hang].Value.ToString();
            lblTongTien.Text = "Tổng tiền: " + dgvHDB[4, hang].Value.ToString();
        }
        void loadcbbMaNhanVien_phikn()
        {
            cbbNhanVien.DataSource = bushdb.loadcbbMaNhanVien_phikn();
            cbbNhanVien.DisplayMember = "MaNhanVien";
            cbbNhanVien.ValueMember = "MaNhanVien";
        }
        void loadcbbMaKhachHang_phikn()
        {
            cbbKhachHang.DataSource = bushdb.loadcbbMaKhachHang_phikn();
            cbbKhachHang.DisplayMember = "MaKhach";
            cbbKhachHang.ValueMember = "MaKhach";
        }
        //void loadcbbTenKhachHang_phikn()
        //{
        //    cbbKhachHang.DataSource = bushdb.loadcbbTenKhachHang_phikn();
        //    cbbKhachHang.DisplayMember = "TenKhach";
        //    cbbKhachHang.ValueMember = "TenKhach";
        //}
        //-------------------------------------------------------------------
        private void btnLamMoiCTHDB_Click(object sender, EventArgs e)
        {
            txbMaCTHDBan.Enabled = true;
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).Text = "";
                }
                txbMaCTHDBan.Enabled = true;
            }
            dgvCTHDB.DataSource = buscthdb.getCTHDBan();
            loadcbbMaHDBan_phikn();
            loadcbbMaHang_phikn();
        }

        private void btnThemCTHDB_Click(object sender, EventArgs e)
        {

            string MaCTHDBan = txbMaCTHDBan.Text;
            string MaHDBan = cbbMaHDBan.Text;
            string MaHang = cbbMaHang.Text;
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm !");
            }
            else if (txbDonGia.Text == "")
            {
                MessageBox.Show("Đơn giá bán chưa nhập, vui lòng nhập đơn giá bán!");
            }
            else
            {
                string SoLuong = txbSoLuong.Text;
                int SoLuong1 = int.Parse(SoLuong);
                float DonGia = float.Parse(txbDonGia.Text);
                float ThanhTien = SoLuong1 * DonGia;
                DTO_ChiTietHoaDonBan cthdb = new DTO_ChiTietHoaDonBan(MaCTHDBan, MaHDBan, MaHang, SoLuong1, DonGia, ThanhTien);
                if (buscthdb.kiemtramatrung(MaCTHDBan) == 1)
                {
                    MessageBox.Show("Mã chi tiết hóa đơn bán đã tồn tại, vui lòng nhập mã khác!");
                }
                else if (txbMaCTHDBan.Text == "")
                {
                    MessageBox.Show("Mã chi tiết hóa đơn bán chưa nhập, vui lòng nhập mã chi tiết hóa đơn bán!");
                }
                else if (cbbMaHDBan.Text == "")
                {
                    MessageBox.Show("Mã hóa đơn bán chưa nhập, vui lòng nhập mã hóa đơn bán!");
                }
                else if (cbbMaHang.Text == "")
                {
                    MessageBox.Show("Mã sản phẩm chưa nhập, vui lòng nhập mã sản phẩm!");
                }
                else if (txbSoLuong.Text == "")
                {
                    MessageBox.Show("Số lượng bán chưa nhập, vui lòng nhập số lượng bán!");
                }
                else if (txbDonGia.Text == "")
                {
                    MessageBox.Show("Đơn giá chưa nhập, vui lòng nhập đơn giá!");
                }
                else
                {
                    double sl, slcon, slxoa;
                    int hang = 0;
                    sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                    if (sl < SoLuong1)
                    {
                        MessageBox.Show("Số lượng sản phẩm không đủ !");
                    }
                    else if (buscthdb.themChiTietHoaDonBan(cthdb) == true)
                    {
                        MessageBox.Show("Thêm thông tin chi tiết hóa đơn bán thành công!");
                        dgvCTHDB.DataSource = buscthdb.getCTHDBan();
                        // Cập nhật lại số lượng cho các mặt hàng
                        sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                        slxoa = Convert.ToDouble(buscthdb.SoLuongHang(MaCTHDBan).Rows[hang][1].ToString());
                        slcon = sl - slxoa;
                        string slcon1 = slcon.ToString();
                        buscthdb.SuaSP(slcon1, MaHang);
                    }
                }
            }
        }

        private void btnSuaCTHDB_Click(object sender, EventArgs e)
        {
            //string MaCTHDBan = txbMaCTHDBan.Text;
            //string MaHDBan = cbbMaHDBan.Text;
            //string MaHang = cbbMaHang.Text;
            //int SoLuong = int.Parse(txbSoLuong.Text);
            //float DonGia = float.Parse(txbDonGia.Text);
            //float ThanhTien = SoLuong * DonGia;

            //DTO_ChiTietHoaDonBan cthdb = new DTO_ChiTietHoaDonBan(MaCTHDBan, MaHDBan, MaHang, SoLuong, DonGia, ThanhTien);
            //if (buscthdb.suaChiTietHoaDonBan(cthdb) == true)
            //{
            //    MessageBox.Show("Sửa thông tin chi tiết hóa đơn bán thành công!");
            //    dgvCTHDB.DataSource = buscthdb.getCTHDBan();
            //}

            string MaCTHDBan = txbMaCTHDBan.Text;
            string MaHDBan = cbbMaHDBan.Text;
            string MaHang = cbbMaHang.Text;
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm!");
            }
            else if (txbDonGia.Text == "")
            {
                MessageBox.Show("Đơn giá bán chưa nhập, vui lòng nhập đơn giá bán!");
            }
            else
            {
                string SoLuong = txbSoLuong.Text;
                int SoLuong1 = int.Parse(SoLuong);

                float DonGia = float.Parse(txbDonGia.Text);
                float ThanhTien = SoLuong1 * DonGia;
                DTO_ChiTietHoaDonBan cthdb = new DTO_ChiTietHoaDonBan(MaCTHDBan, MaHDBan, MaHang, SoLuong1, DonGia, ThanhTien);
                if (txbMaCTHDBan.Text == "")
                {
                    MessageBox.Show("Mã chi tiết hóa đơn bán chưa nhập, vui lòng nhập mã chi tiết hóa đơn bán!");
                }
                else if (cbbMaHDBan.Text == "")
                {
                    MessageBox.Show("Mã hóa đơn bán chưa nhập, vui lòng nhập mã hóa đơn bán!");
                }
                else if (cbbMaHang.Text == "")
                {
                    MessageBox.Show("Mã SP chưa nhập, vui lòng nhập mã sản phẩm!");
                }
                else if (txbSoLuong.Text == "")
                {
                    MessageBox.Show("Số lượng bán chưa nhập, vui lòng nhập số lượng bán!");
                }
                else if (txbDonGia.Text == "")
                {
                    MessageBox.Show("Đơn giá chưa nhập, vui lòng nhập đơn giá!");
                }
                else
                {
                    double sl, slcon, slxoa, slxoa2;
                    int hang = 0;
                    sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                    slxoa = Convert.ToDouble(buscthdb.SoLuongHang(MaCTHDBan).Rows[hang][1].ToString());

                    if (SoLuong1 < slxoa)
                    {
                        slxoa2 = slxoa - SoLuong1;
                        slcon = sl + slxoa2;
                        string slcon2 = slcon.ToString();
                        buscthdb.SuaSP(slcon2, MaHang);
                        if (buscthdb.suaChiTietHoaDonBan(cthdb) == true)
                        {
                            MessageBox.Show("Sửa thông tin chi tiết hóa đơn bán thành công!");
                            dgvCTHDB.DataSource = buscthdb.getCTHDBan();

                        }

                    }
                    else if (SoLuong1 > slxoa)
                    {
                        slxoa2 = SoLuong1 - slxoa;
                        if (slxoa2 > sl)
                        {
                            MessageBox.Show("Số lượng SP trong kho không đủ !");
                        }
                        else
                        {
                            slcon = sl - slxoa2;
                            string slcon2 = slcon.ToString();
                            buscthdb.SuaSP(slcon2, MaHang);
                        }
                        if (buscthdb.suaChiTietHoaDonBan(cthdb) == true)
                        {
                            MessageBox.Show("Sửa thông tin chi tiết hóa đơn bán thành công!");
                            dgvCTHDB.DataSource = buscthdb.getCTHDBan();

                        }
                    }
                }
            }
        }

        private void btnXoaCTHDB_Click(object sender, EventArgs e)
        {
            //string ma = txbMaCTHDBan.Text;
            //DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    if (buscthdb.xoaChiTietHoaDonBan(ma) == true)
            //    {
            //        MessageBox.Show("Xóa thông tin chi tiết hóa đơn bán thành công!");
            //        dgvCTHDB.DataSource = buscthdb.getCTHDBan();
            //    }
            //}

            string MaCTHDBan = txbMaCTHDBan.Text;
            string MaHDBan = cbbMaHDBan.Text;
            string MaHang = cbbMaHang.Text;
            string SoLuong = txbSoLuong.Text;
            int SoLuong1 = int.Parse(SoLuong);
            float DonGia = float.Parse(txbDonGia.Text);
            float ThanhTien = SoLuong1 * DonGia;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                double sl, slcon, slxoa;
                int hang = 0;
                sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                slxoa = Convert.ToDouble(buscthdb.SoLuongHang(MaCTHDBan).Rows[hang][1].ToString());
                slcon = sl + slxoa;
                string slcon1 = slcon.ToString();
                buscthdb.SuaSP(slcon1, MaHang);
                if (buscthdb.xoaChiTietHoaDonBan(MaCTHDBan) == true)
                {

                    MessageBox.Show("Xóa thông tin chi tiết hóa đơn bán thành công!");
                    dgvCTHDB.DataSource = buscthdb.getCTHDBan();
                    // Cập nhật lại số lượng cho các mặt hàng

                }

            }
        }

        private void btnThoatCTHDB_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiemCTHDB_Click(object sender, EventArgs e)
        {
            if (rbMaCTHDBan.Checked)
            {
                string macthdb = txtTKCTHDBan.Text;
                buscthdb.timkiemChiTietHoaDonBanTheoMaCTHDBan(macthdb);
                dgvCTHDB.DataSource = buscthdb.timkiemChiTietHoaDonBanTheoMaCTHDBan(macthdb);
            }
            else
            {
                string mahdb = txtTKCTHDBan.Text;
                buscthdb.timkiemChiTietHoaDonBanTheoMaHDBan(mahdb);
                dgvCTHDB.DataSource = buscthdb.timkiemChiTietHoaDonBanTheoMaHDBan(mahdb);
            }
        }

        private void dgvCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txbMaCTHDBan.Text = dgvCTHDB[0, hang].Value.ToString();
            cbbMaHDBan.Text = dgvCTHDB[1, hang].Value.ToString();
            cbbMaHang.Text = dgvCTHDB[2, hang].Value.ToString();
            txbSoLuong.Text = dgvCTHDB[3, hang].Value.ToString();
            txbDonGia.Text = dgvCTHDB[4, hang].Value.ToString();
            lblThanhTien.Text = "Thành tiền: " + dgvCTHDB[5, hang].Value.ToString();
        }

        private void txbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;//Bo qua phim nhap
            }
        }

        private void txbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;//Bo qua phim nhap
            }
        }
        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgvHDB.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvHDB.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvHDB.Rows.Count; i++)
            {
                for (int j = 0; j < dgvHDB.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvHDB.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
//------------------------------------------------------------------------------------
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            Excel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            Excel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop My kingDom";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Thành phố Hải Dương - tỉnh Hải Dương";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (0220)3123456";
            exRange.Range["C4:C4"].Font.Size = 16;
            exRange.Range["C4:C4"].Font.Bold = true;
            exRange.Range["C4:C4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:C4"].MergeCells = true;
            exRange.Range["C4:C4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:C4"].Value = "HÓA ĐƠN BÁN";

            // Biểu diễn thông tin chung của hóa đơn bán
            string mahdb = txtMaHDB.Text;
            tblThongtinHD = bushdb.KetXuatHDBExcel(mahdb);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B4:B15"].ColumnWidth = 21;
            exRange.Range["C4:C15"].ColumnWidth = 30;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn bán:";
            exRange.Range["B6:B6"].Font.Bold = true;
            exRange.Range["C6:C6"].MergeCells = true;
            exRange.Range["C6:C6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Ngày bán:";
            exRange.Range["B7:B7"].Font.Bold = true;
            exRange.Range["C7:C7"].MergeCells = true;
            exRange.Range["C7:C7"].Value = tblThongtinHD.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "Nhân viên lập hóa đơn:";
            exRange.Range["B8:B8"].Font.Bold = true;
            exRange.Range["C8:C8"].MergeCells = true;
            exRange.Range["C8:C8"].Value = tblThongtinHD.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = "Tên khách hàng:";
            exRange.Range["B9:B9"].Font.Bold = true;
            exRange.Range["C9:C9"].MergeCells = true;
            exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B10:B10"].Value = "Sản phẩm:";
            exRange.Range["B10:B10"].Font.Bold = true;
            exRange.Range["C10:C10"].MergeCells = true;
            exRange.Range["C10:C10"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B11:B11"].Value = "Đơn giá:";
            exRange.Range["B11:B11"].Font.Bold = true;
            exRange.Range["C11:C11"].MergeCells = true;
            exRange.Range["C11:C11"].Value = tblThongtinHD.Rows[0][5].ToString();
            exRange.Range["B12:B12"].Value = "Số lượng:";
            exRange.Range["B12:B12"].Font.Bold = true;
            exRange.Range["C12:C12"].MergeCells = true;
            exRange.Range["C12:C12"].Value = tblThongtinHD.Rows[0][6].ToString();
            exRange.Range["B13:B13"].Value = "Thành tiền:";
            exRange.Range["B13:B13"].Font.Bold = true;
            exRange.Range["C13:C13"].MergeCells = true;
            exRange.Range["C13:C13"].Value = tblThongtinHD.Rows[0][7].ToString();

            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["C1:C1"].MergeCells = true;
            exRange.Range["C1:C1"].Font.Italic = true;
            exRange.Range["C1:C1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["C1:C1"].Value = "Hải Dương, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["C1:C1"].Font.Bold = true;
            exRange.Range["C2:C2"].MergeCells = true;
            exRange.Range["C2:C2"].Font.Italic = true;
            exRange.Range["C2:C2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["C2:C2"].Font.Bold = true;
            exRange.Range["C6:C6"].MergeCells = true;
            exRange.Range["C6:C6"].Font.Italic = true;
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }

    }
}
