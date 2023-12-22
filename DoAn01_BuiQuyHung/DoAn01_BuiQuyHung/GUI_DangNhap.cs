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
    public partial class GUI_DangNhap : Form
    {
        public GUI_DangNhap()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string chuoikn = @"Data Source=LAPTOP-H7D5M1J0\SQLEXPRESS;Initial Catalog=DoAn01_BuiQuyHung;Integrated Security=True";
        void ketnoi()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        void ngatkn()
        {
            con = new SqlConnection(chuoikn);
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát cửa sổ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ketnoi();
            cmd = new SqlCommand();
            cmd.CommandText = "AuthoLogin";//truyền vào tên thủ tục
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Username", txtTenDN.Text);
            cmd.Parameters.AddWithValue("@Password", txtMatKhau.Text);
            int code = (int)cmd.ExecuteScalar();//chạy thủ tục và trả về kết quả lưu vào biến i
            //kq trả về: 0,1,2,3
            if (code == 1)
            {
                MessageBox.Show("Chào mừng quản lý đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Text = "";
                txtMatKhau.Text = "";
                txtTenDN.Focus();
                Program.code = 1;
                GUI_Menu frm = new GUI_Menu();
                frm.ShowDialog();
            }
            else if (code == 0)
            {
                MessageBox.Show("Chào mừng nhân viên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Text = "";
                txtMatKhau.Text = "";
                txtTenDN.Focus();
                Program.code = 0;
                GUI_Menu frm = new GUI_Menu();
                frm.ShowDialog();
            }
            else if (code == 2)
            {
                MessageBox.Show("Bạn nhập sai thông tin tài khoản", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                //txtUser.Text = "";
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
            else
            {
                MessageBox.Show("Tài khoản chưa tồn tại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                txtTenDN.Text = "";
                txtMatKhau.Text = "";
                txtTenDN.Focus();
            }
            ngatkn();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            GUI_DangKyTaiKhoan f = new GUI_DangKyTaiKhoan();
            f.ShowDialog();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void txtTenDN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                e.Cancel = true;
                txtTenDN.Focus();
                errorProvider1.SetError(txtTenDN, "Bạn cần nhập tài khoản");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTenDN, "");
            }
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                e.Cancel = true;
                txtMatKhau.Focus();
                errorProvider1.SetError(txtMatKhau, "Bạn cần nhập mật khẩu");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMatKhau, "");
            }
        }
    }
}

        

       
    

