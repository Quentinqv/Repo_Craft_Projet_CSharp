using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using HashLibrary;
using DatabaseLogin;

namespace ConnexionClass
{
    public class Connexion
    {
        public static string ToConnect(string pseudo, string mdp)
        {
            var con = Database.Connect();
            con.Open();
            string sql = "SELECT email, mdp FROM Compte WHERE pseudo='" + pseudo + "'";
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string sqlMdp = "";
            string sqlEmail = "";

            while (rdr.Read())
            {
                sqlEmail = (string)rdr.GetValue(0);
                sqlMdp = (string)rdr.GetValue(1);
            }

            if (sqlMdp == Hasher.HashString(mdp))
            {
                con.Close();
                HttpContext context = HttpContext.Current;
                context.Session["pseudo"] = pseudo;
                context.Session["email"] = sqlEmail;
                return ("Reussie");
            }

            con.Close();
            return ("Fin");
        }
    }
}