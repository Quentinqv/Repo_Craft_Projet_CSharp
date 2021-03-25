using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using HashLibrary;

namespace WebApplication4
{
    public partial class Inscription : System.Web.UI.Page
    {
        public static bool IsPost { get; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //MySqlDataReader rdr = cmd.ExecuteReader();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            var con = new MySqlConnection(cs);
            con.Open();





            //Session["Name"] = txtName.Text;
            string pseudo = pseudoForm.Value;
            string email = emailForm.Value;
            string password1 = Hasher.HashString(password1Form.Value);
            string password2 = Hasher.HashString(password2Form.Value);

            //Response.Write(password1);
            Response.Write(pseudo);
            Response.Write(email);
            Response.Write(password1);
            Response.Write(password2);

            string sql = "INSERT INTO Compte(pseudo, mdp, email, date_nais, avatar, tel, date_inscription) values('"+pseudo+"', '"+password1+"', '"+email+"', '2021-03-25', 'defaut.png', '060600516', '2021-03-25')";
            var cmd = new MySqlCommand(sql, con);
            /*cmd.Parameters.AddWithValue("@pseudo", pseudo);
            cmd.Parameters.AddWithValue("@mdp", password1);
            cmd.Parameters.AddWithValue("@email", email);*/
            /*cmd.Prepare();*/
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}