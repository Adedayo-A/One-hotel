﻿using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class NHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public Hotel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            throw new NotImplementedException();
        }
    }
}