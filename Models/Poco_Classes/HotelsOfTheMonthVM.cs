﻿namespace HotelPremium.Models.Poco_Classes
{
    public class HotelsOfTheMonthVM
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public string MostSatisfactoryComment { get; set; }
    }
}
