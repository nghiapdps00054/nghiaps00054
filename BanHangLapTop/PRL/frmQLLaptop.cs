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
using System.IO;

namespace BanHangLapTop
{
    public partial class frmQLLaptop : Form
    {
        public frmQLLaptop()
        {
            InitializeComponent();
        }
        public String MaHH;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmQLHangHoa_Load(object sender, EventArgs e)
        {
            bsLaptop.DataSource = LaptopDAL.LietKe();
            dgvDSHangHoa.DataSource = bsLaptop;

            cboLoai.DataSource = LoaiLaptopDAL.LietKe();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
        }

        private void ptbHinhAnh_Click(object sender, EventArgs e)
        {
            if (ofdHinh.ShowDialog() == DialogResult.OK)
            {
                File.Copy(ofdHinh.FileName, "Hinh/" + ofdHinh.SafeFileName, true);
                txtHinhAnh.Text = ofdHinh.SafeFileName;
            }

        }

        private void txtHinhAnh_TextChanged(object sender, EventArgs e)
        {
            ptbHinhAnh.ImageLocation = "Hinh/" + txtHinhAnh.Text;
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsLaptop.MoveFirst();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bsLaptop.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsLaptop.MoveNext();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsLaptop.MoveLast();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "" || txtTenHH.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
                return;
            }
            if (dtpNgaySX.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ", "Thông báo");
                return;
            }
            if (nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo");
                return;
            }
            if (LaptopDAL.Tim(txtMaHH.Text) != null)
            {
                MessageBox.Show("Mã laptop không được trùng", "Thông Báo");
                return;
            }
            if(MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            
                var LT = new Laptop
                {
                    DonGia = Convert.ToDouble(txtDonGia.Text),
                    HinhAnh = txtHinhAnh.Text,
                    MaLaptop = txtMaHH.Text,
                    MaLoai = cboLoai.SelectedValue.ToString(),
                    NgaySX = dtpNgaySX.Value.Date,
                    SoLuong = Convert.ToInt32(nudSoLuong.Value),
                    TenLaptop = txtTenHH.Text

                };
                LaptopDAL.Them(LT);

                bsLaptop.DataSource = LaptopDAL.LietKe();
                MessageBox.Show("Thao tác thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Mã laptop đã tồn tại", "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                            String Malap = txtMaHH.Text;
                            LaptopDAL.Xoa(Malap);
                            bsLaptop.DataSource = LaptopDAL.LietKe();
                            MessageBox.Show("Thao tác thành công!!!");
                        
                    }
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "" || txtTenHH.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông báo");
                return;
            }
            if (dtpNgaySX.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ", "Thông báo");
                return;
            }
            if (nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo");
                return;
            }
            if (MaHH != txtMaHH.Text)
            {
                MessageBox.Show("Không được thay đổi mã loại", "Thông Báo");
                return;
            }
            try
            {
                var LT1 = new Laptop
                {

                    DonGia = Convert.ToDouble(txtDonGia.Text),
                    HinhAnh = txtHinhAnh.Text,
                    MaLaptop = txtMaHH.Text,
                    MaLoai = cboLoai.SelectedValue.ToString(),
                    NgaySX = dtpNgaySX.Value.Date,
                    SoLuong = Convert.ToInt32(nudSoLuong.Value),
                    TenLaptop = txtTenHH.Text
                };
                LaptopDAL.Sua(LT1);

                bsLaptop.DataSource = LaptopDAL.LietKe();
                MessageBox.Show("Thao tác thành công");

            }
            catch
            {
                MessageBox.Show("Mã Hàng Hóa Đã Trùng", "Lỗi");
            }
        }

        private void dgvDSHangHoa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDSHangHoa.SelectedCells.Count > 0)
            {
                var lt = bsLaptop.Current as Laptop;

                txtDonGia.Text = lt.DonGia.ToString();
                txtHinhAnh.Text = lt.HinhAnh;
                txtMaHH.Text = lt.MaLaptop;
                txtTenHH.Text = lt.TenLaptop;
                cboLoai.SelectedValue = lt.MaLoai;
                dtpNgaySX.Value = lt.NgaySX;
                nudSoLuong.Value = lt.SoLuong;
            }
        }

        private void dgvDSHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tabCN.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHH.Clear();
            txtTenHH.Clear();
            txtDonGia.Clear();
            txtHinhAnh.Clear();
            nudSoLuong.Value = 0;
            cboLoai.SelectedIndex = 0;
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaMatHang_TextChanged(object sender, EventArgs e)
        {
            bsLaptop.DataSource = LaptopDAL.LietKeTheoTen(txtMaMatHang.Text);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            double min = Double.Parse(txtGNN.Text);
            double max = Double.Parse(txtGLN.Text);
            bsLaptop.DataSource = LaptopDAL.LietKeTheoGia(min, max);
        }
    }
}
