using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHangLapTop.BLL;
using System.Data.SqlClient;

namespace BanHangLapTop.DAL
{
   public class LoaiKHDAL
    {
       public static void Them(LoaiKH entity)
        {
            String sql = "INSERT INTO LoaiKhachHang(MaLoaiKH, TenLoaiKH, MucGiam) VALUES(@MaLoaiKH, @TenLoaiKH, @MucGiam)";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoaiKH", entity.MaLoaiKH);
            Command.Parameters.AddWithValue("@TenLoaiKH", entity.TenLoaiKH);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
       public static void Sua(LoaiKH entity)
        {
            String sql = "UPDATE LoaiKhachHang SET TenLoaiKH = @TenLoaiKH WHERE MaLoaiKH = @MaLoaiKH";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoaiKH", entity.MaLoaiKH);
            Command.Parameters.AddWithValue("@TenLoaiKH", entity.TenLoaiKH);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static void Xoa(String MaLoaiKH)
        {
            String sql = "DELETE FROM LoaiKhachHang WHERE MaLoaiKH = @MaLoaiKH";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);
            Command.Parameters.AddWithValue("@MaLoaiKH", MaLoaiKH);

            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        public static LoaiKH Tim(String MaLoaiKH)
        {
            String sql = "SELECT * FROM LoaiKhachHang WHERE MaLoaiKH = @MaLoaiKH";
            SqlCommand Command = new SqlCommand(sql, DB.Connection);

            Command.Parameters.AddWithValue("@MaLoaiKH", MaLoaiKH);

            Command.Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                var LoaiKH = new LoaiKH
                {
                    MaLoaiKH = Convert.ToString(Reader["MaLoaiKH"]),
                    TenLoaiKH = Convert.ToString(Reader["TenLoaiKH"]),

                };
                return LoaiKH;
            }
            Command.Connection.Close();
            return null;
        }
        public static List<LoaiKH> LietKe()
        {
            String sql = "SELECT * FROM LoaiKhachHang";
            var DSLoaiKH = TimTheoSql(sql);
            return DSLoaiKH;
        }

        public static List<LoaiKH> TimTheoSql(String sql)
        {
            SqlCommand command = new SqlCommand(sql, DB.Connection);

            command.Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            var DSLoaiKH = new List<LoaiKH>();
            while (Reader.Read())
            {
                var LoaiKH = new LoaiKH
                {
                    MaLoaiKH = Convert.ToString(Reader["MaLoaiKH"]),
                    TenLoaiKH = Convert.ToString(Reader["TenLoaiKH"])

                };
                DSLoaiKH.Add(LoaiKH);
            }
            command.Connection.Close();
            return DSLoaiKH;
        }
    }
}
