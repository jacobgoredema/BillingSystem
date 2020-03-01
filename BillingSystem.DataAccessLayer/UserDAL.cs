using BillingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.DataAccessLayer
{
    public class UserDAL
    {
        static string myConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        // select data from database
        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(myConnectionString);
            DataTable dataTable = new DataTable();

            try
            {
                string sql = "SELECT * FROM user";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        // insert data into database
        public bool Insert(UsersBL user)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(myConnectionString);

            try
            {
                string sql = "INSERT INTO user(firstName, lastName, email, password,contact,address, gender,userType,dateAdded, addedBy) VALUES(@FirstName, @LastName,@Email,@Password,@Contact,@Address,@Gender,@UserType,@DateAdded,@AddedBy)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.FirstName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Contact,", user.Contact);
                command.Parameters.AddWithValue("@Address,", user.Address);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@UserType", user.UserType);
                command.Parameters.AddWithValue("@DateAdded", user.DateAdded);
                command.Parameters.AddWithValue("@AddedBy", user.AddedBy);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows>0)
                {

                    isSuccess = true;
                }
                else
                {

                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Update(UsersBL user)
        {

        }




    }
}
