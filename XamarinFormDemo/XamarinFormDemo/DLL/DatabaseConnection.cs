using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using XamarinFormDemo.BLL;
using XamarinFormDemo.Model;

namespace XamarinFormDemo.DLL
{
    public class DatabaseConnection
    {
        private const string GET_USERS = "SELECT * FROM [dbo].[Felhasznalok]";

        private const string INSERT_USER =
            "INSERT INTO [dbo].[Felhasznalok]" +
            "([Email],[Name],[Age]) " +
            "VALUES(" +
            "@Email,@Name,@Age);";

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(GlobalVariableContainer.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(GET_USERS, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Age = reader.GetInt32(reader.GetOrdinal("Age"))
                                });
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GlobalVariableContainer.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(INSERT_USER, conn);

                    cmd.Parameters.Add(
                        new SqlParameter("@Name", user.Name)
                        {
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                     );
                    cmd.Parameters.Add(
                        new SqlParameter("@Email", user.Email)
                        {
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        }
                     );
                    cmd.Parameters.Add(
                        new SqlParameter("@Age", user.Age)
                        {
                            SqlDbType = System.Data.SqlDbType.Int
                        }
                     );

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
