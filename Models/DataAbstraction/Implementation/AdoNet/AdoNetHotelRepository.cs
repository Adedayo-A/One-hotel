using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelPremium.Models.DataAbstraction.Implementation.AdoNet
{
    public class AdoNetHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        private readonly IConfiguration _config;

        public AdoNetHotelRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Hotel> Hotels
        {
            get
            {
                string? conStr = _config.GetConnectionString("HotelPremiumDB");

                List<Hotel> allHotels = new List<Hotel>();

                //Why didn't we use this?
                //string? oldQuery = @"Select * from Hotels " +
                //    "join Categories on Hotels.CategoryId = Categories.CategoryId";

                string query = @"select Hotels.Name, Hotels.Address, Hotels.HotelOfTheMonth, Hotels.ImageUrl, Hotels.LongDescription,
Hotels.AveragePricePerRoom, Hotels.IsFullyBooked, Hotels.ShortDescription, Hotels.HotelId,
Categories.Name as CategoryName, Categories.Description as CategoryDescription
from HotelPremium.dbo.Hotels 
join Categories on Hotels.CategoryId = Categories.CategoryId";
                //FK constraint is just used to prevent actions that would destroy links between tables.

                var dataTable = GetDataFromDataSource(conStr, query);

                if(dataTable.Rows.Count == 0) 
                {
                    return allHotels;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var hotl = Populate(dataTable, i);

                    allHotels.Add(hotl);
                }
                return allHotels;
            }
        }

        public Hotel? Get(int id)
        {

            string? conStr = _config.GetConnectionString("HotelPremiumDB");

            string query = @$"Select Hotels.Name, Hotels.Address, Hotels.HotelOfTheMonth, Hotels.ImageUrl, Hotels.LongDescription,
Hotels.AveragePricePerRoom, Hotels.IsFullyBooked, Hotels.ShortDescription, Hotels.HotelId,
Categories.Name as CategoryName, Categories.Description as CategoryDescription
from HotelPremium.dbo.Hotels 
join Categories on Hotels.CategoryId = Categories.CategoryId 
where Hotels.HotelId = {id}";

            var dTable = GetDataFromDataSource(conStr, query);

            if (dTable.Rows.Count == 0)
            {
                return null;
            }

            var res = Populate(dTable, 0);

            return res;
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            string? conStr = _config.GetConnectionString("HotelPremiumDB");
            List<Hotel> allHotels = new List<Hotel>();

            string query = @$"select Hotels.Name, Hotels.Address, Hotels.HotelOfTheMonth, Hotels.ImageUrl, Hotels.LongDescription,
Hotels.AveragePricePerRoom, Hotels.IsFullyBooked, Hotels.ShortDescription, Hotels.HotelId,
Categories.Name as CategoryName, Categories.Description as CategoryDescription
from HotelPremium.dbo.Hotels 
join Categories on Hotels.CategoryId = Categories.CategoryId 
where Hotels.HotelOfTheMonth = 1";

            var dTable = GetDataFromDataSource(conStr, query);

            if(dTable.Rows.Count == 0)
            {
                return allHotels;
            }

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                var hotl = Populate(dTable, i);

                allHotels.Add(hotl);
            }
            return allHotels;
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

        private Hotel Populate(DataTable dataTable, int row)
        {
            var hotel = new Hotel();

            hotel.Address = dataTable.Rows[row]["Address"].ToString();
            hotel.Name = dataTable.Rows[row]["Name"].ToString();
            hotel.ShortDescription = dataTable.Rows[row]["ShortDescription"].ToString();
            hotel.LongDescription = dataTable.Rows[row]["LongDescription"].ToString();
            hotel.HotelOfTheMonth = bool.Parse(dataTable.Rows[row]["HotelOfTheMonth"].ToString());
            hotel.IsFullyBooked = bool.Parse(dataTable.Rows[row]["IsFullyBooked"].ToString());
            //hotelVM.Hotel.CategoryId = !int.TryParse(dataTable.Rows[i]["CategoryId"].ToString(), out _) ? 0 : int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
            hotel.AveragePricePerRoom = decimal.Parse(dataTable.Rows[row]["AveragePricePerRoom"].ToString());
            hotel.ImageUrl = dataTable.Rows[row]["ImageUrl"].ToString();
            hotel.HotelId = int.Parse(dataTable.Rows[row]["HotelId"].ToString());
            hotel.Category.Description = dataTable.Rows[row]["CategoryDescription"].ToString();
            hotel.Category.Name = dataTable.Rows[row]["CategoryName"].ToString();

            return hotel;
        }
    }
}
