using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DatabaseLogin
{
    public static class Database
    {

        public static MySqlConnection Connect()
        {
            string cs = @"";
            var con = new MySqlConnection(cs);
            return (con);
        }
    }
}