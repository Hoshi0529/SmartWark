using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalk
{
    internal class Geo_setup
    {
        Location location2;
        double nowlatitude;
        double nowlongitude;
        double beforlatitude;
        double beforlongitude;
        private Timer _timer;
        //現在の位置情報を取得する
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public Double Geo()
        {
            location2 = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location2 != null)
            {
                beforlatitude = nowlatitude;
                beforlongitude = nowlongitude;
                Console.WriteLine($"Latitude: {location2.Latitude}, Longitude: {location2.Longitude}, Altitude: {location2.Altitude}");
                nowlatitude = (location2.Latitude);
                nowlongitude = (location2.Longitude);

            }

            return Geo();
        }

    }
}
