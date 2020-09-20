using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ConnectToDatabase
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Lab Work\Semester 5\VP_Lab\SemesterProject_V_0.1\DataAccessLayer\UsersData.mdf;Integrated Security=True";
        SqlConnection connection;

        public ConnectToDatabase()
        {
            connection = new SqlConnection(connectionString);
        }

        public int executeNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();
            return x;
        }

        public SqlDataReader executeReader(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            //connection.Close();

            return reader;
        }

    }
}
