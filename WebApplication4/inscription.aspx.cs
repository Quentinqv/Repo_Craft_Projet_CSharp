using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using HashLibrary;
using DatabaseLogin;
using ConnexionClass;

namespace WebApplication4
{
    public partial class Inscription : System.Web.UI.Page
    {
        public static bool IsPost { get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["id"] != null)
            {
                Response.Redirect("index.aspx");
            }
            //MySqlDataReader rdr = cmd.ExecuteReader();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var con = Database.Connect();
            con.Open();

            //Session["Name"] = txtName.Text;
            string pseudo = pseudoForm.Value;
            string email = emailForm.Value;
            string password1 = Hasher.HashString(password1Form.Value);
            string password2 = Hasher.HashString(password2Form.Value);


            string sql = "SELECT COUNT(*) FROM Compte WHERE pseudo='"+pseudo+"'";
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            var pseudoSQL = 0;
            var emailSQL = 0;
            string erreurMessage = "";
            while (rdr.Read())
            { 
                pseudoSQL = (int)rdr.GetInt64(0);
            }
            rdr.Close();

            if(pseudoSQL != 1)
            {
                string sqlEMAIL = "SELECT COUNT(*) FROM Compte WHERE email='" + email + "'";
                var cmdEMAIL = new MySqlCommand(sqlEMAIL, con);
                MySqlDataReader rdrEMAIL = cmdEMAIL.ExecuteReader();
                while (rdrEMAIL.Read()) { emailSQL = (int)rdrEMAIL.GetInt64(0);}
                rdrEMAIL.Close();
                if (emailSQL != 1)
                {
                    if(password1 == password2)
                    {
                        string sqlInsertCompte = "INSERT INTO Compte(pseudo, mdp, email) values('"+pseudo+"', '"+password1+"', '"+email+"')";
                        var cmdInsertCompte = new MySqlCommand(sqlInsertCompte, con);
                        cmdInsertCompte.ExecuteNonQuery();
                        Connexion.ToConnect(pseudo, password1Form.Value);
                    }
                    else{ erreurMessage = "Les mots de passe ne correspondent pas."; }
                }
                else { erreurMessage = "L'adresse email est déjà prise."; }
            }
            else{ erreurMessage = "Le pseudo est déjà pris."; }

            con.Close();
            Response.Write(erreurMessage);
        }
    }
}