using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelPremium.Models.DataAbstraction.Implementation.AdoNet
{
    public class AdoNetHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        private readonly IConfiguration _config;
        private readonly ICategory _category;

        public AdoNetHotelRepository(IConfiguration config, ICategory category)
        {
            _config = config;
            _category = category;
        }
        public IEnumerable<HotelVM> Hotels
        {
            get
            {
                //var res = Hotels2;

                string conStr = _config.GetConnectionString("HotelPremiumDB");
                List<HotelVM> allHotels = new List<HotelVM>();

                string oldQuery = @"Select * from Hotels " +
                    "join Categories on Hotels.CategoryId = Categories.CategoryId";

                string query = @"select Hotels.Name, Hotels.Address, Hotels.HotelOfTheMonth, Hotels.ImageUrl, Hotels.LongDescription,
Hotels.AveragePricePerRoom, Hotels.IsFullyBooked, Hotels.ShortDescription,
Categories.Name as CategoryName, Categories.Description as CategoryDescription
from HotelPremium.dbo.Hotels 
join Categories on Hotels.CategoryId = Categories.CategoryId";

                using (SqlConnection sqlConnection = new SqlConnection(conStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    //FK constraint is just used to prevent actions that would destroy links between tables.

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        Hotel htl = new Hotel();

                        htl.Address = dataTable.Rows[i]["Address"].ToString();
                        htl.Name = dataTable.Rows[i]["Name"].ToString();
                        htl.ShortDescription = dataTable.Rows[i]["ShortDescription"].ToString();
                        htl.LongDescription = dataTable.Rows[i]["LongDescription"].ToString();
                        htl.HotelOfTheMonth = bool.Parse(dataTable.Rows[i]["HotelOfTheMonth"].ToString());
                        htl.IsFullyBooked = bool.Parse(dataTable.Rows[i]["IsFullyBooked"].ToString());
                        //hotelVM.Hotel.CategoryId = !int.TryParse(dataTable.Rows[i]["CategoryId"].ToString(), out _) ? 0 : int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
                        htl.AveragePricePerRoom = decimal.Parse(dataTable.Rows[i]["AveragePricePerRoom"].ToString());
                        htl.ImageUrl = dataTable.Rows[i]["ImageUrl"].ToString();
                        htl.Name = dataTable.Rows[i]["Categories.Name"].ToString();
                        htl.Category.Description = dataTable.Rows[i]["Categories.Description"].ToString();
                        htl.Hotel.Category.Name = dataTable.Rows[i]["Category"].ToString();


                        HotelVM hotelVM = new HotelVM();

                        hotelVM.Hotel.Address = dataTable.Rows[i]["Address"].ToString();
                        hotelVM.Hotel.Name = dataTable.Rows[i]["Name"].ToString();
                        hotelVM.Hotel.ShortDescription = dataTable.Rows[i]["ShortDescription"].ToString();
                        hotelVM.Hotel.LongDescription = dataTable.Rows[i]["LongDescription"].ToString();
                        hotelVM.Hotel.HotelOfTheMonth = bool.Parse(dataTable.Rows[i]["HotelOfTheMonth"].ToString());
                        hotelVM.Hotel.IsFullyBooked = bool.Parse(dataTable.Rows[i]["IsFullyBooked"].ToString());
                        //hotelVM.Hotel.CategoryId = !int.TryParse(dataTable.Rows[i]["CategoryId"].ToString(), out _) ? 0 : int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
                        hotelVM.Hotel.AveragePricePerRoom = decimal.Parse(dataTable.Rows[i]["AveragePricePerRoom"].ToString());
                        hotelVM.Hotel.ImageUrl = dataTable.Rows[i]["ImageUrl"].ToString();
                        hotelVM.Category.Name = dataTable.Rows[i]["Categories.Name"].ToString();
                        hotelVM.Category.Description = dataTable.Rows[i]["Categories.Description"].ToString();
                        hotelVM.Hotel.Category.Name = dataTable.Rows[i]["Category"].ToString();


                        allHotels.Add(hotelVM);
                    }
                }
                return allHotels;
            }
        }

        public IEnumerable<HotelVM> Hotels2
        {
            get
            {
                string conStr = _config.GetConnectionString("HotelPremiumDB");
                List<HotelVM> allHotels = new List<HotelVM>();

                string query = "Select * from Hotels";

                using (SqlConnection sqlConnection = new SqlConnection(conStr))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        HotelVM hotelVM = new HotelVM();

                        hotelVM.Hotel.HotelId = int.Parse(dataTable.Rows[i]["Id"].ToString());
                        hotelVM.Hotel.Address = dataTable.Rows[i]["Address"].ToString();
                        hotelVM.Hotel.Name = dataTable.Rows[i]["Name"].ToString();
                        hotelVM.Hotel.ShortDescription = dataTable.Rows[i]["ShortDescription"].ToString();
                        hotelVM.Hotel.LongDescription = dataTable.Rows[i]["LongDescription"].ToString();
                        hotelVM.Hotel.HotelOfTheMonth = bool.Parse(dataTable.Rows[i]["HotelOfTheMonth"].ToString());
                        hotelVM.Hotel.IsFullyBooked = bool.Parse(dataTable.Rows[i]["IsFullyBooked"].ToString());
                        hotelVM.Hotel.CategoryId = !int.TryParse(dataTable.Rows[i]["CategoryId"].ToString(), out _) ? 0 : int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
                        hotelVM.Hotel.AveragePricePerRoom = decimal.Parse(dataTable.Rows[i]["AveragePricePerRoom"].ToString());
                        hotelVM.Hotel.ImageUrl = dataTable.Rows[i]["ImageUrl"].ToString();
                        hotelVM.Category.Name = dataTable.Rows[i]["Category.Name"].ToString();
                        hotelVM.Category.Description = dataTable.Rows[i]["Description"].ToString();

                        allHotels.Add(hotelVM);
                    }
                }
                return allHotels;
            }
        }



        public HotelVM Get(int id)
        {
            return Hotels.FirstOrDefault(h => h.Hotel.HotelId == id);
        }

        public IEnumerable<HotelVM> GetHotelsOfTheMonth()
        {
            return Hotels.Where(hVM => hVM.Hotel.HotelOfTheMonth);
        }
    }
}
