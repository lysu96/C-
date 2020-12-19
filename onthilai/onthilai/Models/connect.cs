using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace onthilai.Models
{
    public class connect
    {
        string conn;
        public connect()
        {
            conn = ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString;
        }
        public static SqlConnection getSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString);
        }
    }
}