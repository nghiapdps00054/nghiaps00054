﻿using System;
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
    public partial class frmBanHang : Form
    {
        List<Laptop> Laptop = new List<Laptop>();
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // không cho tự sinh cột
            dgvChiTietHD.AutoGenerateColumns = false;

            dgvChiTietHD.DataSource = bsBanHang;
            bsBanHang.DataSource = Laptop;

            cbolaptop.DataSource = LaptopDAL.LietKe();
            cbolaptop.ValueMember = "MaLaptop";
            cbolaptop.DisplayMember = "TenLaptop";

            cboKH.DataSource = KhachHangDAL.LietKe();
            cboKH.ValueMember = "MaKhachHang";
            cboKH.DisplayMember = "TenKhachHang";

            cboNV.DataSource = NhanVienDAL.LietKe();
            cboNV.ValueMember = "MaNhanVien";
            cboNV.DisplayMember = "TenNhanVien";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Lấy mặt hàng đã chọn trên combobox đổ vào datagridview
                var LT = cbolaptop.SelectedItem as Laptop;
                LT.SoLuong = int.Parse(txtSoLuong.Text);

                //Nếu chưa chọn hoặc không có trong list box thì đổ vào ô lưới

                if (!Laptop.Contains(LT))
                {
                    bsBanHang.Add(LT);
                }

                // Cập nhật lại ô lưới khi đã thêm biến
                bsBanHang.ResetCurrentItem();

                //Tính và hiển thị tổng tiền của HD

                double Tongtien = 0;
                foreach (var lt in Laptop)
                {
                    Tongtien += lt.DonGia * lt.SoLuong;
                }
                txtThanhTien.Text = Tongtien.ToString();
                MessageBox.Show("Thêm Thành công", "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sản phẩm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Xóa mặt hàng đã chọn trên ô lưới 
                bsBanHang.RemoveCurrent();

                //Tính lại tổng tiền của HD 
                double Tongtien = 0;
                foreach (var lt in Laptop)
                {
                    Tongtien += lt.DonGia * lt.SoLuong;
                }
                txtThanhTien.Text = Tongtien.ToString();
                MessageBox.Show("Xóa thành công", "Thông Báo");
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "" || cboNV.Text == "" || cboKH.Text == ""  )
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
                return;
            }

            if (dtpNgay.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập hóa đơn không được lớn hơn ngày hiện tại", "Thông Báo");
                return;
            }
            if (HDXuatDAL.Tim(txtMaHD.Text)!= null)
            {
                MessageBox.Show("Mã hóa đơn không được trùng", "Thông Báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn tạo Hóa đơn?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Tạo Hóa đơn và thêm vào bàng HDXuat
                var HD = new HDXuat
                {
                    MaHDXuat = txtMaHD.Text,
                    NgayXuat = dtpNgay.Value.Date,
                    MaKhachHang = cboKH.SelectedValue.ToString(),
                    MaNhanVien = cboNV.SelectedValue.ToString(),
                    TongTien = double.Parse(txtThanhTien.Text)

                };
                HDXuatDAL.Them(HD);

                //Duyệt các hàng đã chọn
                foreach (var lt in Laptop)
                {

                    //Tạo HD và thêm vào bảng CTHDXuat
                    var CTHD = new ChiTietHDXuat
                    {
                        MaHDXuat = txtMaHD.Text,
                        MaLaptop = lt.MaLaptop,
                        DonGia = lt.DonGia,
                        SoLuong = lt.SoLuong
                    };
                }
                MessageBox.Show("Bạn đã tạo thành công", "Thông Báo");
            }
        }

    }

}
