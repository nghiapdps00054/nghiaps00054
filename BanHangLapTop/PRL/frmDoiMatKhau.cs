using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanHangLapTop.BLL;
using BanHangLapTop.DAL;

namespace BanHangLapTop
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear();
            txtNhapLaiMatKhauMoi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhauMoi.Clear();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "" || txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMatKhauMoi.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống");
                return;
            }
       
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhauMoi.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng!");
                return;
            }

            if (txtMatKhauMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có 6 ký tự trở lên!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn sửa mật khẩu?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var NhanVien = new NhanVien
                {
                    MaNhanVien = frmDangNhap.MaNV,
                    MatKhau = txtMatKhauMoi.Text
                };
                NhanVienDAL.SuaMatKhau(NhanVien);
                MessageBox.Show("Thao tác thành công!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TH = MessageBox.Show("Bạn chắc chắn muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TH == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

       
    }
}
