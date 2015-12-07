using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using BanHangLapTop.DAL;

namespace BanHangLapTop
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            {
                if (!File.Exists("Pass.txt"))
                {
                    FileStream fs;
                    fs = new FileStream("Pass.txt", FileMode.Create);
                    StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

                    sWriter.WriteLine();
                    sWriter.Flush();
                    fs.Close();
                }
                string[] lines = File.ReadAllLines("Pass.txt");
                if (lines[lines.Length - 1] == "1")
                {
                    txtMatKhau.Text = lines[lines.Length - 3];
                    txtTenDangNhap.Text = lines[lines.Length - 2];
                    chkNMK.Checked = true;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult TH = MessageBox.Show("Bạn chắc chắn muốn thóat khỏi ứng dụng ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TH == DialogResult.Yes)

                Application.Exit();
        }

        public static bool VaiTro { get; set; }
        public static string MaNV { get; set; }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Pass.txt", FileMode.Append);
            StreamWriter writeFile = new StreamWriter(fs, Encoding.UTF8);
            if (chkNMK.Checked == true)
            {
                writeFile.WriteLine(txtMatKhau.Text);
                writeFile.WriteLine(txtTenDangNhap.Text);
                writeFile.WriteLine("1");
                writeFile.Flush();
            }
            else writeFile.WriteLine("0");
            writeFile.Close();
            {
                if (txtMatKhau.Text == "")
                {
                    MessageBox.Show("Chưa nhập mật khẩu", "Thông Báo");
                    return;
                }
                if (txtTenDangNhap.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên đăng nhập", "Thông Báo");
                    return;
                }
                String Sql = "Select * From NhanVien Where  TaiKhoan=@TaiKhoan And MatKhau=@MatKhau";
                SqlCommand command = new SqlCommand(Sql, DB.Connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@TaiKhoan", txtTenDangNhap.Text);
                command.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MaNV = Convert.ToString(reader["MaNhanVien"]);
                    VaiTro = Convert.ToBoolean(reader["VaiTro"]);
                    MessageBox.Show("Chúc mừng ! bạn đã đăng nhập thành công", "Thông Báo");
                    this.Visible = false;
                    
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                command.Connection.Close();
            }
            this.Visible = false;
            frmChinh a = new frmChinh();
            a.ShowDialog();
        }
    }
}
