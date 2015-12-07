using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class ChiTietHDXuatDAL
    {
        public static void Them(ChiTietHDXuat entity)
        {
            String sql = "INSERT INTO ChiTietHDXuat(MaHDXuat, MaLaptop, SoLuong, DonGia) VALUES( @MaHDXuat, @MaLaptop, @SoLuong, @DonGia)";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDXuat", entity.MaHDXuat);
            Command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            Command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            Command.Parameters.AddWithValue("@DonGia", entity.DonGia);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Sua(ChiTietHDXuat entity)
        {
            String sql = "UPDATE ChiTietHDXuat SET  MaLaptop=@MaLaptop, SoLuong=@SoLuong, DonGia=@DonGia WHERE MaHDXuat=@MaHDXuat";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDNhap", entity.MaHDXuat);
            Command.Parameters.AddWithValue("@MaLaptop", entity.MaLaptop);
            Command.Parameters.AddWithValue("@SoLuong", entity.SoLuong);
            Command.Parameters.AddWithValue("@DonGia", entity.DonGia);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }

        public static void Xoa(String MaHDXuat)
        {
            String sql = "DELETE FROM ChiTietHDXuat WHERE MaHDXuat=@MaHDXuat";

            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaHDXuat", MaHDXuat);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static ChiTietHDXuat Tim(String MaHDXuat)
        {
            String sql = "SELECT * FROM ChiTietHDXuat WHERE MaHDXuat = @MaHDXuat";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaHDXuat", MaHDXuat);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var CTHDXuat = new ChiTietHDXuat
                {
                    MaHDXuat = Convert.ToString(Reader["MaHDXuat"]),
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    DonGia = Convert.ToDouble(Reader["DonGia"])

                };
                return CTHDXuat;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<ChiTietHDXuat> LietKe()
        {
            String sql = "SELECT * FROM ChiTietHDXuat";
            var DSHD = TimTheoSql(sql);
            return DSHD;
        }

        public static List<ChiTietHDXuat> TimTheoSql(String sql)
        {
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            var DSHDXuat = new List<ChiTietHDXuat>();
            while (Reader.Read())
            {
                var HDXuat = new ChiTietHDXuat
                {
                    MaHDXuat = Convert.ToString(Reader["MaHDXuat"]),
                    MaLaptop = Convert.ToString(Reader["MaLaptop"]),
                    SoLuong = Convert.ToInt32(Reader["SoLuong"]),
                    DonGia = Convert.ToDouble(Reader["DonGia"])

                };
                DSHDXuat.Add(HDXuat);
            }
            Command.Connection.Close();
            return DSHDXuat;
        }
    }
}
