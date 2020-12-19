using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySql.Data;

namespace thi.Models
{
    public class Dbconnect
    {
        public static MySqlConnection GetSqlConnection()
        {
            string dbconn = ConfigurationManager.ConnectionStrings["CSDL"].ConnectionString;
            MySqlConnection my = new MySqlConnection(dbconn);
            return my;
        }
    }
}