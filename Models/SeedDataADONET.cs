using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlTypes;

namespace HotelPremium.Models
{
    public class SeedDataADONET
    {
        public static void SeedData(IConfiguration config) 
        {
           string query =
                @"
                IF OBJECT_ID('dbo.Hotels') IS NOT NULL AND OBJECT_ID('dbo.Categories') IS NOT NULL 
AND OBJECT_ID('dbo.Users') IS NOT NULL
                BEGIN
                PRINT OBJECT_ID('dbo.Hotels')
                END;

                ELSE
                BEGIN

                CREATE TABLE dbo.Categories
                (
                    CategoryId int identity(1,1) PRIMARY KEY NOT NULL,
                    Name nvarchar(50),
                    Description nvarchar(100)
                );

                CREATE TABLE dbo.Hotels
                (
                    HotelId int identity(1,1) PRIMARY KEY NOT NULL,
                    Name nvarchar(50),
                    ShortDescription nvarchar(50),
                    LongDescription text,
                    ImageUrl nvarchar(500),
                    IsFullyBooked bit,
                    HotelOfTheMonth bit,
                    Address nvarchar(500),
                    AveragePricePerRoom decimal(18,2),
                    CategoryId int NULL 
                    FOREIGN KEY REFERENCES Categories(CategoryId)
                );

                CREATE TABLE dbo.Users
                (
                    Email nvarchar(50) PRIMARY KEY NOT NULL,
                    FirstName nvarchar(50),
                    LastName nvarchar(50),
                    Password text,
                    Phone nvarchar(50),
                    Address nvarchar(500)
                );

                INSERT INTO dbo.Categories
                (Name, Description)
                VALUES
                ('First Class', 'Hotels ranked ***** with Premium facilities'),
                ('Second Class', 'Hotels ranked **** with Great facilities'),
                ('Third Class', 'Hotels ranked *** with Good enough facilities');

                INSERT INTO dbo.Hotels
                (Name, AveragePricePerRoom, ShortDescription, LongDescription, CategoryId, ImageUrl, IsFullyBooked, HotelOfTheMonth, Address)
                VALUES
                ('Benchmark', 50, 'Very appealing', 'A serene environment with beaches and Balcony Sky view', 1, 
'https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg', 0, 1, 'Lisbon, Portugal'),

                ('ParisOne', 60, 'Experience of a lifetime', 'A serene environment with a mini beach and Balcony Sky view', 1, 
'https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg', 0, 1, 'Paris, France'),

                ('Sheraton', 55, 'Highly Rated', 'A serene environment with a nice view of the commercial Lagos', 1, 
'https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg', 0, 1, 'Lagos, Nigeria'),

                ('Family Plus', 30, 'Very Cozy and Lovely', 'It provides great comfort and it is a family choice', 2, 
'https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221399/download2.jpg', 0, 0, 'Seychelles'),

                ('Perfect Eyes', 25, 'Tourists choice', 'A perfect feeling of home', 3, 
'https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg', 0, 0, 'Mexico')
                                
                END;
                "
            ;

            string conStr = config.GetConnectionString("HotelPremiumDB");

            CreateCommand(query, conStr);
        }

        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
        }

        private static void CreateCommand2(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private static bool CheckDBExist(string databaseName) 
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {

                SqlConnection tmpConn = new SqlConnection("server=(localdb)\\mssqllocaldb;Trusted_Connection=yes");

                 sqlCreateDBQuery = string.Format(@"SELECT database_id FROM sys.databases WHERE Name 
        = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;    

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        result = (databaseID > 0);

                        if(!result == true)
                        {
                            sqlCreateDBQuery = string.Format(@"Create Database '{0}'", databaseName);

                            sqlCmd.ExecuteScalar();
                        }

                        tmpConn.Close();


                    }
                }
            } 
            catch (Exception ex)
            {
                result = false;
            }

             return result;
        }

    }
}
