using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BanHangLapTop
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult TH = MessageBox.Show("Bạn chắc chắn muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TH == DialogResult.Yes)
            {
                frmDangNhap f = new frmDangNhap();
                f.Show();
                this.Close();
            }           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TH = MessageBox.Show("Bạn chắc chắn muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TH == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblQLNV_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.Show();
        }

        private void lblQLKH_Click(object sender, EventArgs e)
        {
            frmQLKhachHang f = new frmQLKhachHang();
            f.Show();
        }

        private void lblLoaiLaptop_Click(object sender, EventArgs e)
        {
            frmQLLoaiLaptop f = new frmQLLoaiLaptop();
            f.Show();
        }

        private void lblLaptop_Click(object sender, EventArgs e)
        {
            frmQLLaptop f = new frmQLLaptop();
            f.Show();
        }

        private void lblDMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang f = new frmBanHang();
            f.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmNhapHang f = new frmNhapHang();
            f.Show();
        }
    }
}
