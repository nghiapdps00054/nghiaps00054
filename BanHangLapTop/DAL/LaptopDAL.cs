using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
    public class LaptopDAL
    {
        public static void Them(Laptop entity)
        {
            String sql = "INSERT INTO Laptop(MaLaptop ,TenLaptop, MaLoai, DonGia , NgaySX, SoLuong, HinhAnh) VALUES(@MaLaptop, @TenLaptop, @MaLoai,@DonGia, @NgaySX, @SoLuong, @HinhAnh)";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            command.Parameters.AddWithValue("@TenLaptop", entity.TenLaptop);
            command.Parameters.AddWithValue("@MaLoai", entity.MaLoai);
            command.Parameters.AddWithValue("@DonGia", entity.DonGia);
            command.Parameters.AddWithValue("@NgaySX", entity.NgaySX);
            command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            command.Parameters.AddWithValue("@HinhAnh", entity.HinhAnh);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void Sua(Laptop entity)
        {
            String sql = "UPDATE Laptop SET TenLaptop=@TenLaptop, MaLoai=@MaLoai, NgaySX=@NgaySX,DonGia = @DonGia, SoLuong=@SoLuong, HinhAnh=@HinhAnh WHERE MaLaptop=@MaLaptop";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            command.Parameters.AddWithValue("@TenLaptop", entity.TenLaptop);
            command.Parameters.AddWithValue("@MaLoai", entity.MaLoai);
            command.Parameters.AddWithValue("@DonGia", entity.DonGia);
            command.Parameters.AddWithValue("@NgaySX", entity.NgaySX);
            command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            command.Parameters.AddWithValue("@HinhAnh", entity.HinhAnh);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void Xoa(String MaLaptop)
        {
            String sql = "DELETE FROM Laptop WHERE MaLaptop=@MaLaptop";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaLaptop", MaLaptop);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static Laptop Tim(String MaLaptop)
        {
            String sql = "SELECT * FROM Laptop WHERE MaLaptop=@MaLaptop";

            SqlCommand command = new SqlCommand(sql, DB.Connection);
            command.Parameters.AddWithValue("@MaLaptop", MaLaptop);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                var lap = new Laptop
                {
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    TenLaptop = Convert.ToString(Reader["TenLaptop"]),
                    MaLoai = Convert.ToString(Reader["MaLoai"]),
                    DonGia = Convert.ToDouble(Reader["DonGia"]),
                    NgaySX = Convert.ToDateTime(Reader["NgaySX"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    HinhAnh = Convert.ToString(Reader["HinhAnh"]),
                };
                return lap;
            }
            command.Connection.Close();
            return null;
        }

        public static List<Laptop> LietKe()
        {
            String sql = "SELECT * FROM Laptop";
            var dslap = TimTheoSql(sql);

            return dslap;
        }

        public static List<Laptop> TimTheoSql(String sql)
        {
            SqlCommand command = new SqlCommand(sql, DB.Connection);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            var dslaptop = new List<Laptop>();
            while (Reader.Read())
            {
                var LapTop = new Laptop
                {
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    TenLaptop = Convert.ToString(Reader["TenLaptop"]),
                    MaLoai = Convert.ToString(Reader["MaLoai"]),
                    DonGia = Convert.ToDouble(Reader["DonGia"]),
                    NgaySX = Convert.ToDateTime(Reader["NgaySX"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    HinhAnh = Convert.ToString(Reader["HinhAnh"]),
                };
                dslaptop.Add(LapTop);
            }
            command.Connection.Close();
            return dslaptop;
        }
        public static List<Laptop> LietKeTheoTen(String TenLaptop)
        {
            String sql = "SELECT * FROM LapTop WHERE TenLaptop LIKE '%" + TenLaptop + "%'";
            var LT = TimTheoSql(sql);

            return LT;
        }
        public static List<Laptop> LietKeTheoGia(double min, double max)
        {
            String sql = "SELECT * FROM Laptop WHERE DonGia BETWEEN " + min + " AND " + max;
            var DSlap = TimTheoSql(sql);
            return DSlap;
        }
    }
}
