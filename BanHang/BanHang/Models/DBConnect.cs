using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class DBConnect
    {
        public static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        }
    }
}