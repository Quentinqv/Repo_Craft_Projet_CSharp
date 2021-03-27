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
            string sql = "SELECT email, mdp, id_cpt FROM Compte WHERE pseudo='" + pseudo + "'";
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string sqlMdp = "";
            string sqlEmail = "";
            string sqlId = "";

            while (rdr.Read())
            {
                sqlEmail = (string)rdr.GetValue(0);
                sqlMdp = (string)rdr.GetValue(1);
                sqlId = Convert.ToString(rdr.GetValue(2));
            }

            if (sqlMdp == Hasher.HashString(mdp))
            {
                con.Close();
                HttpContext context = HttpContext.Current;
                context.Session["pseudo"] = pseudo;
                context.Session["email"] = sqlEmail;
                context.Session["id"] = sqlId;


                string path = HttpContext.Current.Request.Url.AbsolutePath;
                if (path.Contains("inscription"))
                {
                    HttpContext.Current.Response.Redirect("index.aspx");
                }
                return ("Reussie");
            }

            con.Close();
            return ("Fin");
        }
    }
}