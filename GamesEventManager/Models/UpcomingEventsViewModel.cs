using System.Collections.Generic;
using System.Linq;
using GamesEventManager.DataLayer;

namespace GamesEventManager.Models
{
    public class UpcomingEventsViewModel
    {
        public string HomeZipCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public bool Valid { get; set; }
        public List<EventsViewModel> Events { get; set; }


        public UpcomingEventsViewModel(string zipCode)
        {
            HomeZipCode = zipCode;
            GeoCodingResponse.GeoResponse response = GoogleMaps.GeoCodeAddress(zipCode);
            Valid = (response.Status == "OK");
            if (!Valid) return;
            Lat = response.Results.FirstOrDefault().Geometry.Location.Lat;
            Lng = response.Results.FirstOrDefault().Geometry.Location.Lng;
            Events = EventsViewModel.GetEvents(HomeZipCode).OrderBy(d => d.EventDateTime).ToList();
        }
    }
}