using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelPremium.Models.DataAbstraction.Implementation.AdoNet
{
    public class AdoNetCategoryRepository : ICategory
    {
        private readonly IConfiguration _config;

        private string ConString
        { 
            get
            {
                var conStr = _config.GetConnectionString("HotelPremiumDB");

                return conStr;
            }
        }

        public AdoNetCategoryRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Category> GetAll
        {
            get
            {

                List<Category> categories = new List<Category>();

                string query = @"select * from Categories";
                
                var dataTable = GetDataFromDataSource(ConString, query);

                for(int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var category = Populate(dataTable, i);
                    categories.Add(category);
                }

                return categories;
            }
        }

        public Category GetCategory(int id)
        {
            string query = string.Format(@"select * from categories where categoryId = {0}", id);

            var dataTable = GetDataFromDataSource(ConString, query);

            var category = Populate(dataTable, 0);

            return category;
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

        private Category Populate(DataTable datatable, int row)
        {
            var category = new Category();

            category.CategoryId = int.Parse(datatable.Rows[row]["CategoryId"].ToString());
            category.Name = datatable.Rows[row]["Name"].ToString();
            category.Description = datatable.Rows[row]["Description"].ToString();
            

            return category;
        }

    }
}
