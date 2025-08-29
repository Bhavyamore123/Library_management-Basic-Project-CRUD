using _1_Library_Model.Models;
using _2_Library_Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Library_Repository.Repositories
{
    public class Library_Book_Repository : Library_Book_Interface
    {
       public SqlConnection Connect()
       {
            var constr = "data source=BHAVESH_MORE\\SQLEXPRESS; initial catalog=Library_Management_DB; user id=sa; password=Game@123; trustservercertificate=True;";
            SqlConnection con = new SqlConnection(constr);
            con.Close();
            con.Open();
            
            return con;
       }

       public int PostData(Library_Book_Model model)
        {
            SqlConnection con = Connect();
            SqlCommand cmd = new SqlCommand();
            int serverresponce = 0;
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "Sp_Book_Management";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (model.BookId == 0)
                {
                    cmd.Parameters.AddWithValue("@flag", 'I');
                    serverresponce = 1;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@flag", 'U');
                    serverresponce = 2;
                }
                cmd.Parameters.AddWithValue("@BookId", model.BookId);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Author", model.Author);
                cmd.Parameters.AddWithValue("@ISBN", model.ISBN);
                cmd.Parameters.AddWithValue("@PublishDate", model.PublishDate);
                cmd.Parameters.AddWithValue("@Category", model.Category);
                
                cmd.ExecuteNonQuery();
            }
            catch
            {
                serverresponce = 3;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                
            }
            return serverresponce;

       }
        public DataTable GetLibraryData()
        {
            string Constr = "select * from Book";
            SqlCommand cmd = new SqlCommand(Constr, Connect());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       

        public DataTable LibraryBookViewEdit(int ID)
        {
            string Constr = "SELECT * from Book where BookId=" +ID;
            SqlCommand cmd = new SqlCommand(Constr, Connect());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
           
        }
        public void LibraryBookViewDelete(int ID)
        {
            string Constr = "Delete from Book where BookId=" + ID;
            SqlCommand cmd = new SqlCommand(Constr, Connect());

            cmd.ExecuteNonQuery();
        }




       
    }
}
