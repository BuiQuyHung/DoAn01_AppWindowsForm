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
    public partial class GUI_HoaDonNhap : Form
    {
        BUS_ChiTietHoaDonNhap buscthdn = new BUS_ChiTietHoaDonNhap();
        BUS_HoaDonNhap bushdn = new BUS_HoaDonNhap();
        BUS_HangHoa buss = new BUS_HangHoa();
        SqlCommand lenh = new SqlCommand();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public GUI_HoaDonNhap()
        {
            InitializeComponent();
        }

        private void txbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;//Bo qua phim nhap
            }
        }
        void loadcbbMaHDNhap_phikn()
        {
            cbbMaHDNhap.DataSource = buscthdn.loadcbbMaHDNhap_phikn();
            cbbMaHDNhap.DisplayMember = "MaHDNhap";
            cbbMaHDNhap.ValueMember = "MaHDNhap";
        }
        void loadcbbMaHang_phikn()
        {
            cbbMaHang.DataSource = buscthdn.loadcbbMaHang_phikn();
            cbbMaHang.DisplayMember = "MaHang";
            cbbMaHang.ValueMember = "MaHang";
        }
        void loadcbbMaNhanVien_phikn()
        {
            cbbNhanVien.DataSource = bushdn.loadcbbMaNhanVien_phikn();
            cbbNhanVien.DisplayMember = "MaNhanVien";
            cbbNhanVien.ValueMember = "MaNhanVien";
        }
        void loadcbbMaNhaCungCap_phikn()
        {
            cbbNhaCungCap.DataSource = bushdn.loadcbbMaNhaCungCap_phikn();
            cbbNhaCungCap.DisplayMember = "MaNhaCungCap";
            cbbNhaCungCap.ValueMember = "MaNhaCungCap";
        }

        private void btnLamMoiCTHDN_Click(object sender, EventArgs e)
        {
            txbMaCTHDNhap.Enabled = true;
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
                txbMaCTHDNhap.Enabled = true;
            }
            dgvCTHDN.DataSource = buscthdn.getCTHDNhap();
            //loadcbbMaHDNhap_phikn();
            //loadcbbMaHang_phikn();
            loadcbbMaNhanVien_phikn();
            loadcbbMaNhaCungCap_phikn();
        }

        private void btnThemCTHDN_Click(object sender, EventArgs e)
        {
            string MaCTHDNhap = txbMaCTHDNhap.Text;
            string MaHDNhap = cbbMaHDNhap.Text;
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
                DTO_ChiTietHoaDonNhap cthdn = new DTO_ChiTietHoaDonNhap(MaCTHDNhap, MaHDNhap, MaHang, SoLuong1, DonGia, ThanhTien);
                if (buscthdn.kiemtramatrung(MaCTHDNhap) == 1)
                {
                    MessageBox.Show("Mã chi tiết hóa đơn nhập đã tồn tại, vui lòng nhập mã khác!");
                }
                else if (txbMaCTHDNhap.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã chi tiết hóa đơn nhập!");
                }
                else if (cbbMaHDNhap.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn bán!");
                }
                else if (cbbMaHang.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm!");
                }
                else
                {
                    double sl, slcon, slxoa;
                    int hang = 0;
                    sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                    if (buscthdn.themChiTietHoaDonNhap(cthdn) == true)
                    {
                        MessageBox.Show("Thêm thông tin chi tiết hóa đơn nhập thành công!");
                        dgvCTHDN.DataSource = buscthdn.getCTHDNhap();
                        // Cập nhật lại số lượng cho các mặt hàng
                        sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                        slxoa = Convert.ToDouble(buscthdn.SoLuongHang(MaCTHDNhap).Rows[hang][1].ToString());
                        slcon = sl + slxoa;
                        string slcon1 = slcon.ToString();
                        buscthdn.SuaSP(slcon1, MaHang);
                    }
                }
            }
        }
        private void btnSuaCTHDN_Click(object sender, EventArgs e)
        {
            string MaCTHDNhap = txbMaCTHDNhap.Text;
            string MaHDNhap = cbbMaHDNhap.Text;
            string MaHang = cbbMaHang.Text;
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm!");
            }
            else if (txbDonGia.Text == "")
            {
                MessageBox.Show("Đơn giá nhập chưa nhập, vui lòng nhập đơn giá nhập!");
            }
            else if (cbbMaHDNhap.Text == "")
            {
                MessageBox.Show("Chưa chọn mã HD nhập, vui lòng chọn mã hóa đơn nhập!");
            }
            else if (cbbMaHang.Text == "")
            {
                MessageBox.Show("Chưa chọn mã hàng, vui lòng chọn mã hàng!");
            }
            else
            {
                string SoLuong = txbSoLuong.Text;
                int SoLuong1 = int.Parse(SoLuong);

                float DonGia = float.Parse(txbDonGia.Text);
                float ThanhTien = SoLuong1 * DonGia;
                DTO_ChiTietHoaDonNhap cthdn = new DTO_ChiTietHoaDonNhap(MaCTHDNhap, MaHDNhap, MaHang, SoLuong1, DonGia, ThanhTien);
                if (txbMaCTHDNhap.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã chi tiết hóa đơn nhập!");
                }
                else if (cbbMaHDNhap.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn nhập!");
                }
                else if (cbbMaHang.Text == "")
                {
                    MessageBox.Show("Mã sản phẩm chưa nhập, vui lòng nhập mã sản phẩm!");
                }

                else
                {
                    double sl, slcon, slxoa, slxoa2;
                    int hang = 0;
                    sl = Convert.ToDouble(buss.SoLuongHangHoa(MaHang).Rows[hang][0].ToString());
                    slxoa = Convert.ToDouble(buscthdn.SoLuongHang(MaCTHDNhap).Rows[hang][1].ToString());

                    if (SoLuong1 < slxoa)
                    {
                        slxoa2 = slxoa - SoLuong1;
                        slcon = sl - slxoa2;
                        string slcon2 = slcon.ToString();
                        buscthdn.SuaSP(slcon2, MaHang);
                        if (buscthdn.suaChiTietHoaDonNhap(cthdn) == true)
                        {
                            MessageBox.Show("Sửa thông tin chi tiết hóa đơn nhập thành công!");
                            dgvCTHDN.DataSource = buscthdn.getCTHDNhap();

                        }

                    }
                    else if (SoLuong1 > slxoa)
                    {
                        slxoa2 = SoLuong1 - slxoa;
                        slcon = sl + slxoa2;
                        string slcon2 = slcon.ToString();
                        buscthdn.SuaSP(slcon2, MaHang);
                        if (buscthdn.suaChiTietHoaDonNhap(cthdn) == true)
                        {
                            MessageBox.Show("Sửa thông tin chi tiết hóa đơn nhập thành công!");
                            dgvCTHDN.DataSource = buscthdn.getCTHDNhap();
                        }
                    }
                }
            }
        }

        private void btnXoaCTHDN_Click(object sender, EventArgs e)
        {
            string MaCTHDNhap = txbMaCTHDNhap.Text;
            string MaHDNhap = cbbMaHDNhap.Text;
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
                slxoa = Convert.ToDouble(buscthdn.SoLuongHang(MaCTHDNhap).Rows[hang][1].ToString());
                slcon = sl - slxoa;
                string slcon1 = slcon.ToString();
                buscthdn.SuaSP(slcon1, MaHang);
                if (buscthdn.xoaChiTietHoaDonNhap(MaCTHDNhap) == true)
                {

                    MessageBox.Show("Xóa thông tin chi tiết hóa đơn bán thành công!");
                    dgvCTHDN.DataSource = buscthdn.getCTHDNhap();
                    // Cập nhật lại số lượng cho các mặt hàng

                }

            }
        }
        private void btnThoatCTHDN_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiemCTHDN_Click(object sender, EventArgs e)
        {
            if (rbMaCTHDNhap.Checked)
            {
                string macthdn = txtTKCTHDNhap.Text;
                buscthdn.timkiemChiTietHoaDonNhapTheoMaCTHDNhap(macthdn);
                dgvCTHDN.DataSource = buscthdn.timkiemChiTietHoaDonNhapTheoMaCTHDNhap(macthdn);
            }
            else
            {
                string mahdn = txtTKCTHDNhap.Text;
                buscthdn.timkiemChiTietHoaDonNhapTheoMaHDNhap(mahdn);
                dgvCTHDN.DataSource = buscthdn.timkiemChiTietHoaDonNhapTheoMaHDNhap(mahdn);
            }
        }

        private void dgvCTHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txbMaCTHDNhap.Text = dgvCTHDN[0, hang].Value.ToString();
            cbbMaHDNhap.Text = dgvCTHDN[1, hang].Value.ToString();
            cbbMaHang.Text = dgvCTHDN[2, hang].Value.ToString();
            txbSoLuong.Text = dgvCTHDN[3, hang].Value.ToString();
            txbDonGia.Text = dgvCTHDN[4, hang].Value.ToString();
            lblThanhTien.Text = "Thành tiền: " + dgvCTHDN[5, hang].Value.ToString();
            txbMaCTHDNhap.Enabled = false;
        }

        private void GUI_HoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvCTHDN.DataSource = buscthdn.getCTHDNhap();
            dgvHDN.DataSource = bushdn.getHDNhap();
            loadcbbMaHDNhap_phikn();
            loadcbbMaHang_phikn();
            loadcbbMaNhanVien_phikn();
            loadcbbMaNhaCungCap_phikn();
        }

        private void txbDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;//Bo qua phim nhap
            }
        }

        private void btnLamMoiHDNhap_Click(object sender, EventArgs e)
        {
            txtMaHDN.Enabled = true;
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
                txtMaHDN.Enabled = true;
            }
            dgvHDN.DataSource = bushdn.getHDNhap();
            //loadcbbMaHDNhap_phikn();
            //loadcbbMaHang_phikn();
            //loadcbbMaNhanVien_phikn();
            //loadcbbMaNhaCungCap_phikn();
        }

        private void btnThemHDNhap_Click(object sender, EventArgs e)
        {
            string MaHDNhap = txtMaHDN.Text;
            DateTime NgayNhap = DateTime.Parse(dtpNgayNhap.Value.ToShortDateString());
            string MaNhanVien = cbbNhanVien.Text;
            string MaNhaCungCap = cbbNhaCungCap.Text;
            DTO_HoaDonNhap hdn = new DTO_HoaDonNhap(MaHDNhap, NgayNhap, MaNhanVien, MaNhaCungCap);
            if (bushdn.kiemtramatrung(MaHDNhap) == 1)
            {
                MessageBox.Show("Mã hóa đơn nhập đã tồn tại, vui lòng nhập mã khác!");
            }
            else if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Mã hóa đơn nhập chưa nhập, vui lòng nhập mã hóa đơn nhập!");
            }
            else if (dtpNgayNhap.Text == "")
            {
                MessageBox.Show("Ngày nhập chưa nhập, vui lòng nhập ngày nhập!");
            }
            else if (cbbNhanVien.Text == "")
            {
                MessageBox.Show("Nhân viên nhập chưa nhập, vui lòng nhập nhân viên nhập!");
            }
            else if (cbbNhaCungCap.Text == "")
            {
                MessageBox.Show("NCC chưa nhập, vui lòng nhập NCC!");
            }
            else
            {
                if (bushdn.themHoaDonNhap(hdn) == true)
                {
                    MessageBox.Show("Thêm thông tin hóa đơn nhập thành công!");
                    dgvHDN.DataSource = bushdn.getHDNhap();
                    loadcbbMaHDNhap_phikn();
                }

            }
        }

        private void btnSuaHDNhap_Click(object sender, EventArgs e)
        {
            string MaHDNhap = txtMaHDN.Text;
            DateTime NgayNhap = DateTime.Parse(dtpNgayNhap.Value.ToShortDateString());
            string MaNhanVien = cbbNhanVien.Text;
            string MaNhaCungCap = cbbNhaCungCap.Text;

            DTO_HoaDonNhap hdn = new DTO_HoaDonNhap(MaHDNhap, NgayNhap, MaNhanVien, MaNhaCungCap);
            if (txtMaHDN.Text == "")
            {
                MessageBox.Show("Mã hóa đơn nhập chưa nhập, vui lòng nhập mã hóa đơn nhập!");
            }
            else if (dtpNgayNhap.Text == "")
            {
                MessageBox.Show("Ngày nhập chưa nhập, vui lòng nhập ngày nhập!");
            }
            else if (cbbNhanVien.Text == "")
            {
                MessageBox.Show("Nhân viên nhập chưa nhập, vui lòng nhập nhân viên nhập!");
            }
            else if (cbbNhaCungCap.Text == "")
            {
                MessageBox.Show("NCC chưa nhập, vui lòng nhập NCC!");
            }
            else
            {
                if (bushdn.suaHoaDonNhap(hdn) == true)
                {
                    MessageBox.Show("Sửa thông tin hóa đơn nhập thành công!");
                    dgvHDN.DataSource = bushdn.getHDNhap();
                }
            }   
        }

        private void btnXoaHDNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn cần xóa Chi tiết hóa đơn nhập trước, hãy kiểm tra !!!");
            string ma = txtMaHDN.Text;
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (bushdn.xoaHoaDonNhap(ma) == true)
                {
                    MessageBox.Show("Xóa thông tin  hóa đơn nhập thành công!");
                    dgvHDN.DataSource = bushdn.getHDNhap();
                }
            }
        }

        private void btnThoatHDNhap_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiemHDNhap_Click(object sender, EventArgs e)
        {

            if (rbMaHDNhap.Checked)
            {
                string mahdn = txtTKHDNhap.Text;
                bushdn.timkiemHoaDonNhapTheoMaHDNhap(mahdn);
                dgvHDN.DataSource = bushdn.timkiemHoaDonNhapTheoMaHDNhap(mahdn);
            }
            else
            {
                string mancc = txtTKHDNhap.Text;
                bushdn.timkiemHoaDonNhapTheoMaNhaCungCap(mancc);
                dgvHDN.DataSource = bushdn.timkiemHoaDonNhapTheoMaNhaCungCap(mancc);
            }
        }

        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaHDN.Text = dgvHDN[0, hang].Value.ToString();
            dtpNgayNhap.Text = dgvHDN[1, hang].Value.ToString();
            cbbNhanVien.Text = dgvHDN[2, hang].Value.ToString();
            cbbNhaCungCap.Text = dgvHDN[3, hang].Value.ToString();
            lblTongTien.Text = "Tổng tiền: " + dgvHDN[4, hang].Value.ToString();
        }

        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgvHDN.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvHDN.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvHDN.Rows.Count; i++)
            {
                for (int j = 0; j < dgvHDN.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvHDN.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
        private void btnKetXuatExcelHDB_Click(object sender, EventArgs e)
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
            exRange.Range["C4:C4"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            string mahdn = txtMaHDN.Text;
            tblThongtinHD = bushdn.KetXuatHDNExcel(mahdn);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B4:B15"].ColumnWidth = 21;
            exRange.Range["C4:C15"].ColumnWidth = 30;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn nhập:";
            exRange.Range["B6:B6"].Font.Bold = true;
            exRange.Range["C6:C6"].MergeCells = true;
            exRange.Range["C6:C6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Ngày nhập:";
            exRange.Range["B7:B7"].Font.Bold = true;
            exRange.Range["C7:C7"].MergeCells = true;
            exRange.Range["C7:C7"].Value = tblThongtinHD.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "Nhân viên lập hóa đơn:";
            exRange.Range["B8:B8"].Font.Bold = true;
            exRange.Range["C8:C8"].MergeCells = true;
            exRange.Range["C8:C8"].Value = tblThongtinHD.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = "Tên nhà cung cấp:";
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
            exRange.Range["C2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["C2:C2"].Font.Bold = true;
            exRange.Range["C6:C6"].MergeCells = true;
            exRange.Range["C6:C6"].Font.Italic = true;
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
    }
}


