using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication4
{
    public partial class Index : System.Web.UI.Page
    {
        public object date;
		public string Output;
		
		protected void Page_Load(object sender, EventArgs e)
        {


			
			var con = new MySqlConnection(cs);
			con.Open();
			string sql = "SELECT * FROM Poste";
			var cmd = new MySqlCommand(sql, con);
			MySqlDataReader rdr = cmd.ExecuteReader();

			while (rdr.Read())
			{
				Output = Output + rdr.GetValue(0) + " - " + rdr.GetValue(1) + "</br>";
			}
			con.Close();
			Response.Write(Output);
			

			this.date = DateTime.Now;

		}
	}
}