using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace bt_qlsach.Models
{
    public class DBConnect
    {
        string strcon;
        public DBConnect()
        {
            strcon = ConfigurationManager.ConnectionStrings["KETNOI"].ConnectionString;
        }
        public static SqlConnection getConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["KETNOI"].ConnectionString);
        }
    }
}