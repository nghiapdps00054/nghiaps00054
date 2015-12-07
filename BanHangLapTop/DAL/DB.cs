using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace BanHangLapTop.DAL
{
   public class DB
    {
       public static SqlConnection Connection
       {
           get
           {
               String ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
               var connection = new SqlConnection(ConnectionString);
               return connection;
           }
       }
    }
}
