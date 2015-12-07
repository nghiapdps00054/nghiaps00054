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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        // tạo 1 list true false theo vai trò
        public List<TrueFalse> TrueFalseList = new List<TrueFalse>(new TrueFalse[]{
               new TrueFalse(true, "Admin"),
               new TrueFalse(false, "Nhân Viên")});
        // tạo 1 list true false theo giới tính
        public List<TrueFalse1> TrueFalseList1 = new List<TrueFalse1>(new TrueFalse1[]{
               new TrueFalse1(true, "Nam"),
               new TrueFalse1(false, "Nữ")});

        public String MaNV;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //txtMaNV.Enabled = false;
            //dgvDSNV.AutoGenerateColumns = false;
            // hiển thị dữ liệu lên DataGridView
            //bsNV.DataSource = NhanVienDAL.LietKe();
            //dgvDSNV.DataSource = bsNV;


            //hiển thị lên form
            //txtMaNV.DataBindings.Add("Text", bsNV, "MaNhanVien", true);
            //txtTenNV.DataBindings.Add("Text", bsNV, "TenNhanVien", true);
            //cboVaiTro.DataBindings.Add("SelectedValue", bsNV, "VaiTro", true);
            //txtThongTin.DataBindings.Add("Text", bsNV, "ThongTin", true);
            //txtTK.DataBindings.Add("Text", bsNV, "Taikhoan", true);
            //txtMatKhau.DataBindings.Add("text", bsNV, "MatKhau", true);
            //cboGioiTinh.DataBindings.Add("SelectedValue", bsNV, "GioiTinh", true);

            bsNV.DataSource = NhanVienDAL.LietKe();
            dgvDSNV.DataSource = bsNV;
            //nối combobox vai trò với list true false vai trò
            cboVaiTro.DataSource = TrueFalseList;
            cboVaiTro.DisplayMember = "Name";
            cboVaiTro.ValueMember = "Type";
            //nối combobox vai trò với list true false 1 giới tính
            cboGioiTinh.DataSource = TrueFalseList1;
            cboGioiTinh.DisplayMember = "Name";
            cboGioiTinh.ValueMember = "Type";


        }


        private void btnDau_Click(object sender, EventArgs e)
        {
            bsNV.MoveFirst();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bsNV.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsNV.MoveNext();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsNV.MoveLast();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //txtMaNV.Enabled = true;
            //bsNV.AddNew();
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtTK.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
                return;
            }
            if (NhanVienDAL.Tim(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên không được trùng", "Thông Báo");
                return;
            }
          
                bool GT, VT;
                if (cboGioiTinh.SelectedIndex == 0)
                    GT = true;
                else
                    GT = false;

                if (cboVaiTro.SelectedIndex == 0)
                    VT = true;
                else
                    VT = false;

                if (MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var NV = new NhanVien
                    {
                        MaNhanVien = txtMaNV.Text,
                        TenNhanVien = txtTenNV.Text,
                        TaiKhoan = txtTK.Text,
                        MatKhau = txtMatKhau.Text,
                        ThongTin = txtThongTin.Text,
                        GioiTinh = GT,
                        VaiTro = VT
                    };
                    NhanVienDAL.Them(NV);

                    bsNV.DataSource = NhanVienDAL.LietKe();
                    MessageBox.Show("Thao tác thành công", "Thông báo");
                  
                }
                else
                {
                    MessageBox.Show("Nhân viên đã tồn tại", "Lỗi");
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        String MaNhanVien = txtMaNV.Text;
                        NhanVienDAL.Xoa(MaNhanVien);
                        bsNV.DataSource = NhanVienDAL.LietKe();
                        //bsNV.RemoveCurrent();
                        MessageBox.Show("Thao tác thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!!!", "Lỗi");
                    }
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtTK.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
            }
            var NV1 = new NhanVien
            {
                MaNhanVien = txtMaNV.Text,
                TenNhanVien = txtTenNV.Text,
                TaiKhoan = txtTK.Text,
                MatKhau = txtMatKhau.Text,
                ThongTin = txtThongTin.Text


            };
            NhanVienDAL.Sua(NV1);

            bsNV.DataSource = NhanVienDAL.LietKe();
            MessageBox.Show("Thao tác thành công", "Thông báo");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtTK.Clear();
            txtMatKhau.Clear();
            cboGioiTinh.SelectedValue = 0;
            cboVaiTro.SelectedValue = 0;
            txtThongTin.Clear();

        }

        private void txtTKNV_TextChanged(object sender, EventArgs e)
        {
            bsNV.DataSource = NhanVienDAL.LietKeTheoTen(txtTKNV.Text);
        }

        private void dgvDSnhanvien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSNV.SelectedCells.Count > 0)
            {
                var NV = bsNV.Current as NhanVien;

                if (NV.GioiTinh == false)
                {
                    cboGioiTinh.SelectedIndex = 1;
                }
                else
                    cboGioiTinh.SelectedIndex = 0;

                txtMaNV.Text = NV.MaNhanVien.ToString();
                txtTenNV.Text = NV.TenNhanVien.ToString();
                cboGioiTinh.SelectedValue = NV.TenGioiTinh;
                cboVaiTro.SelectedValue = NV.TenVaiTro;
                txtMatKhau.Text = NV.MatKhau.ToString();
                txtTK.Text = NV.TaiKhoan.ToString();
                txtThongTin.Text = NV.ThongTin.ToString();

            }
        }
    }
}
