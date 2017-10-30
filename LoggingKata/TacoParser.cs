using System;
using System.Collections;
using System.Collections.Generic;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        public TacoParser()
        {

        }

        public enum Location
        {
            Longitude,
            Latitude
        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                Logger.Error("Must have at least 3 elements to parse into ITrackable");
                return null;
            }

            var lonStr = cells[0];
            var latStr = cells[1];
            var name = cells[2];

            double lon = 0;
            double lat = 0;

            Logger.Info("Parsed lon and lat strings into doubles");
            double.TryParse(lonStr, out lon);
            double.TryParse(latStr, out lat);

            var point = new Point()
            {
                Latitude = 0,
                Longitude = 0
            };

            var tacoBell = new TacoBell();
            tacoBell.Name = "";
            tacoBell.Location = point;

            return tacoBell;
        }
    }
}