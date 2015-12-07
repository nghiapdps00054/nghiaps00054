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
using System.Text.RegularExpressions;

namespace BanHangLapTop
{
    public partial class frmQLKhachHang : Form
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }
        public String MaKH;
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            bsKH.DataSource = KhachHangDAL.LietKe();
            dgvDSKhachHang.DataSource = bsKH;

            cboMaLoaiKH.DataSource = LoaiKHDAL.LietKe();
            cboMaLoaiKH.DisplayMember = "TenLoaiKH";
            cboMaLoaiKH.ValueMember = "MaLoaiKH";
        }

        private void dgvDSKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSKhachHang.SelectedCells.Count > 0)
            {
                var KH = bsKH.Current as KhachHang;

                if (KH.GioiTinh == false)
                {
                    cboGioiTinh.SelectedIndex = 1;
                }
                else
                    cboGioiTinh.SelectedIndex = 0;

                txtMaKH.Text = KH.MaKhachHang.ToString();
                txtHoTenKH.Text = KH.TenKhachHang.ToString();
                cboMaLoaiKH.SelectedValue = KH.MaLoaiKH;
                txtDiaChi.Text = KH.DiaChi.ToString();  
                txtEmail.Text = KH.Email.ToString();
                MaKH = KH.MaKhachHang.ToString();

            }
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsKH.MoveFirst();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsKH.MoveLast();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsKH.MoveNext();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bsKH.MovePrevious();
        }
        public static bool BATLOIEMAIL(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtHoTenKH.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
            }
            if (BATLOIEMAIL(txtEmail.Text) == false)
            {
                MessageBox.Show("Định dạng Email không hợp lệ", "Lỗi");
                return;
            }
            if (KhachHangDAL.Tim(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng không được trùng","Thông Báo");
                return;
            }
                bool GT;

                if (cboGioiTinh.SelectedIndex == 0)
                    GT = true;
                else
                    GT = false;
             if(MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var KH = new KhachHang
                {
                    MaKhachHang = txtMaKH.Text,
                    TenKhachHang = txtHoTenKH.Text,
                    MaLoaiKH = cboMaLoaiKH.SelectedValue.ToString(),
                    DiaChi = txtDiaChi.Text,
                    Email = txtEmail.Text,
                    GioiTinh = GT



                };
                KhachHangDAL.Them(KH);

                bsKH.DataSource = KhachHangDAL.LietKe();
                MessageBox.Show("Thao tác thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại", "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        String MaKhachHang = txtMaKH.Text;
                        KhachHangDAL.Xoa(MaKhachHang);
                        bsKH.DataSource = KhachHangDAL.LietKe();
                        MessageBox.Show("Bạn đã xóa thành công!!!");
                    }
                    catch
                    {
                        MessageBox.Show("Mã khách hàng không tồn tại!!!", "Lỗi");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtHoTenKH.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
                return;
            }
            if (BATLOIEMAIL(txtEmail.Text) == false)
            {
                MessageBox.Show("Định dạng Email không hợp lệ", "Lỗi");
                return;
            }
            
            if (MaKH != txtMaKH.Text)
            {
                MessageBox.Show("Không được thay đổi mã loại", "Thông Báo");
                return;
            }
            bool GT;

            if (cboGioiTinh.SelectedIndex == 0)
                GT = true;
            else
                GT = false;

            var KH1 = new KhachHang
            {

                MaKhachHang = txtMaKH.Text,
                TenKhachHang = txtHoTenKH.Text,
                MaLoaiKH = cboMaLoaiKH.SelectedValue.ToString(),
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                GioiTinh = GT


            };
            KhachHangDAL.Sua(KH1);

            bsKH.DataSource = KhachHangDAL.LietKe();
            MessageBox.Show("Thao tác thành công", "Thông báo");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtHoTenKH.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cboMaLoaiKH.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
            
        }
    }
}
