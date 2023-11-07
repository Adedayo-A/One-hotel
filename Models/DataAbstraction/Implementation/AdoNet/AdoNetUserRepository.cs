using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelPremium.Models.DataAbstraction.Implementation.AdoNet
{
    public class AdoNetUserRepository : IAuthentication
    {
        private readonly IConfiguration _configuration;
        public AdoNetUserRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public IEnumerable<User> Users
        {
            get
            {
                string? conStr = _configuration.GetConnectionString("HotelPremiumDB");

                List<User> allUsers = new List<User>();
                string query = @"Select * from Users";

                var dTable = GetDataFromDataSource(conStr, query);

                if(dTable.Rows.Count == 0) 
                {
                    return allUsers;
                }

                for(int i = 0; i < dTable.Rows.Count; i++)
                {
                    var user = Populate(dTable, i);

                    allUsers.Add(user);
                }

                return allUsers;

            }
        }

        public User? GetUser(string email)
        {
            string? conStr = _configuration.GetConnectionString("HotelPremiumDB");
            string query = @$"Select * from Users where email = '{email}'";

            var dTable = GetDataFromDataSource(conStr, query);

            if(dTable.Rows.Count == 0)
            {
                return null;
            }

            var user = Populate(dTable, 0);

            return user;
        }

        public User Login(string email, string password)
        {
            string? conStr = _configuration.GetConnectionString("HotelPremiumDB");
            password = PasswordHash.HashPassword(password);

            string query = @$"Select * from Users where email = '{email}' and password like '{password}'";

            var dTable = GetDataFromDataSource(conStr, query);

            if (dTable.Rows.Count == 0)
            {
                return null;
            }

            var user = Populate(dTable, 0);

            return user;
        }

        public void Signup(User user)
        {
            user.Password = PasswordHash.HashPassword(user.Password);
            string? conStr = _configuration.GetConnectionString("HotelPremiumDB");

            string query = @$"Insert into Users
                              (FirstName, LastName, Password, Email, Phone, Address)
                            Values
                            (@param1, @param2, @param3, @param4, @param5, @param6)";

            string query2 = @$"Insert into Users
                              (FirstName, LastName, Password, Email, Phone, Address)
                            Values
                            ('{user.FirstName}', '{user.LastName}', '{user.Password}', '{user.Email}', '{user.Phone}', '{user.Address}')";


            //InsertToDataSource(conStr, query, user);

            InsertToDataSource(conStr, query2);
        }

        private DataTable GetDataFromDataSource(string conString, string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {

                }
            }
            return dataTable;
        }

        private User Populate(DataTable dataTable, int row)
        {
            var user = new User();

            user.Address = dataTable.Rows[row]["Address"].ToString();
            user.FirstName = dataTable.Rows[row]["FirstName"].ToString();
            user.LastName = dataTable.Rows[row]["LastName"].ToString();
            user.Phone = dataTable.Rows[row]["Phone"].ToString();
            user.Email = dataTable.Rows[row]["Email"].ToString();
            user.Password = dataTable.Rows[row]["Password"].ToString();

            return user;
        }

        private void InsertToDataSource(string conString, string query, User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();

                try
                {
                    SqlCommand command = sqlConnection.CreateCommand();

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@param1", user.FirstName);
                    command.Parameters.AddWithValue("@param2", user.LastName);
                    command.Parameters.AddWithValue("@param3", user.Password);
                    command.Parameters.AddWithValue("@param4", user.Email);
                    command.Parameters.AddWithValue("@param5", user.Phone);
                    command.Parameters.AddWithValue("@param6", user.Address);


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void InsertToDataSource(string conString, string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
