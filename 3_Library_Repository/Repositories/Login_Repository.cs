using _1_Library_Model.Models;
using _2_Library_Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Library_Repository.Repositories
{
    public class Login_Repository : Login_Interface
    {
        public SqlConnection Connect()
        {
            string constr = "data source=BHAVESH_MORE\\SQLEXPRESS; initial catalog=Library_Management_DB; user id=sa; password=Game@123; trustservercertificate=True;";
            SqlConnection con = new SqlConnection(constr);
            con.Close();
            con.Open();
            return con;
        }
        public DataTable GetLoginData(Login_Model model)
        {
            using (SqlConnection con = new SqlConnection("data source=BHAVESH_MORE\\SQLEXPRESS; initial catalog=Library_Management_DB; user id=sa; password=Game@123; trustservercertificate=True;")) // 4
            {
                SqlCommand cmd = new SqlCommand("Login_SP", con); // 5 "Login_sp"
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login_Email", model.Login_Email);
                cmd.Parameters.AddWithValue("@Login_Password", model.Login_Password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
