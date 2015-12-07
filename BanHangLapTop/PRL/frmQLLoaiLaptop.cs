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
    public partial class frmQLLoaiLaptop : Form
    {
        public frmQLLoaiLaptop()
        {
            InitializeComponent();
        }
        public String MaLT;

        private void frmQLLoaiLaptop_Load(object sender, EventArgs e)
        {

            bsLoai.DataSource = LoaiLaptopDAL.LietKe();
            dgvDSMaLoai.DataSource = bsLoai;
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsLoai.MoveFirst();
        }

        private void dgvDSMaLoai_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSMaLoai.SelectedCells.Count > 0)
            {

                var ML = bsLoai.Current as LoaiLaptop;

                txtMaLoai.Text = ML.MaLoai.ToString();
                txtTenLoai.Text = ML.TenLoai.ToString();
                MaLT = ML.MaLoai.ToString();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bsLoai.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsLoai.MoveNext();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsLoai.MoveLast();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "" ) 
            {
                MessageBox.Show("Không được để trống thông tin", "Thông Báo");
                    return;
            }
            if (LoaiLaptopDAL.Tim(txtMaLoai.Text) != null)
            {
                MessageBox.Show("Mã loại không được trùng", "Thông Báo");
                return;
            }

            if(MessageBox.Show("Bạn có muốn thêm sản phẩm không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var ML = new LoaiLaptop
                {
                    MaLoai = txtMaLoai.Text,
                    TenLoai = txtTenLoai.Text
                };
                LoaiLaptopDAL.Them(ML);

                bsLoai.DataSource = LoaiLaptopDAL.LietKe();
                MessageBox.Show("Bạn đã thêm thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Mã LapTop đã tồn tại", "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        String matl = txtMaLoai.Text;
                        LoaiLaptopDAL.Xoa(matl);
                        bsLoai.DataSource = LoaiLaptopDAL.LietKe();
                        MessageBox.Show("Bạn đã xóa thành công!!!");
                    }
                    catch
                    {
                        MessageBox.Show("Mã LapTop không tồn tại!!!");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin", "Thông Báo");
                return;
            }
            if (MaLT != txtMaLoai.Text)
            {
                MessageBox.Show("Không được thay đổi mã loại", "Thông Báo");
                return;
            }
            
                var ML = new LoaiLaptop
                {
                    MaLoai = txtMaLoai.Text,
                    TenLoai = txtTenLoai.Text
                };
                LoaiLaptopDAL.Sua(ML);

                bsLoai.DataSource = LoaiLaptopDAL.LietKe();
                MessageBox.Show("Bạn đã thao tác thành công");
            
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
        }
    }
}
