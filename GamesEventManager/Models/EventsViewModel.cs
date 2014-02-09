using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesEventManager.DataLayer;

namespace GamesEventManager.Models
{
    public class EventsViewModel : Event
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string DistanceFromHome { get; set; }
        public string HoursFromHome { get; set; }

        public static List<EventsViewModel> GetEvents(string homeZipCode)
        {
            var eventViewModels = new List<EventsViewModel>();
            var events = EventService.GetFutureEvents().ToList();
            foreach (var gamesEvent in events)
            {
                var eventViewModel = new EventsViewModel
                {
                    Name = gamesEvent.Name,
                    Venue = gamesEvent.Venue,
                    Address = gamesEvent.Address,
                    EventDateTime = gamesEvent.EventDateTime,
                    EventWebsite = gamesEvent.EventWebsite
                };
                var distanceResponse = GoogleMaps.DistanceMatrix(homeZipCode, gamesEvent.Address);
                var geocodeResponse = GoogleMaps.GeoCodeAddress(gamesEvent.Address);
                eventViewModel.DistanceFromHome = distanceResponse.Rows.Select(r => r.Elements).FirstOrDefault().Select(d => d.Distance).FirstOrDefault().Text;
                eventViewModel.HoursFromHome = distanceResponse.Rows.Select(r => r.Elements).FirstOrDefault().Select(d => d.Duration).FirstOrDefault().Text;
                eventViewModel.Lat = geocodeResponse.Results.FirstOrDefault().Geometry.Location.Lat;
                eventViewModel.Lng = geocodeResponse.Results.FirstOrDefault().Geometry.Location.Lng;
                eventViewModels.Add(eventViewModel);
            }
            return eventViewModels;
        }
    }
}