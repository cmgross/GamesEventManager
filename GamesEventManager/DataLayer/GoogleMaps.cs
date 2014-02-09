using System.Net;
using ServiceStack.Text;

namespace GamesEventManager.DataLayer
{
    public static class GoogleMaps
    {
        public static GeoCodingResponse.GeoResponse GeoCodeAddress(string address)
        {
            var url = string.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", address.Replace(" ", "+"));
            var result = new WebClient().DownloadString(url);
            var geoResponse = JsonSerializer.DeserializeFromString<GeoCodingResponse.GeoResponse>(result);
            return geoResponse;
        }

        public static DistanceMatrixResponse.DistanceResponse DistanceMatrix(string originZipCode, string destinationAddress)
        {
            var formattedAddress = destinationAddress.Replace(" ", "+");
            var url = "http://maps.googleapis.com/maps/api/distancematrix/json?origins=" + originZipCode +
                      "&destinations=" + formattedAddress + "&units=imperial&sensor=false";
            var result = new WebClient().DownloadString(url);
            var distanceResponse = JsonSerializer.DeserializeFromString<DistanceMatrixResponse.DistanceResponse>(result);
            return distanceResponse;
        }
    }
}