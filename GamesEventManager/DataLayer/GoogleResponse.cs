namespace GamesEventManager.DataLayer
{
    public class GeoCodingResponse
    {
        public class GeoLocation
        {
            public decimal Lat { get; set; }
            public decimal Lng { get; set; }
        }

        public class GeoGeometry
        {
            public GeoLocation Location { get; set; }
        }

        public class GeoResult
        {
            public GeoGeometry Geometry { get; set; }
        }

        public class GeoResponse
        {
            public string Status { get; set; }
            public GeoResult[] Results { get; set; }
        }
}


    public class DistanceMatrixResponse
    {
        public class DistanceDuration
        {
            public string Text { get; set; }
        }

        public class DistanceDistance
        {
            public string Text { get; set; }
        }
        public class DistanceElement
        {
            public DistanceDuration Duration { get; set; }
            public DistanceDistance Distance { get; set; }
            
        }
        public class DistanceRows
        {
            public DistanceElement[] Elements{ get; set; }
        }
        public class DistanceResponse
        {
            public string Status { get; set; }
            public DistanceRows[] Rows { get; set; }
        }
    } 
}