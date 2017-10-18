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

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            //Take your line and use string.Split(",", line);
            //Or it's line.Split(",");

            //If your array.Length is less than 3, something went wrong
            //Log that and return null

            //grab the long from your array at index 0
            //grab the lat from your array at index 1
            //grab the name from your array at index 2

            //You're going to need to parse your string as a Decimal
            //which is similar to parse a string as an int
            
            //Then, return the instance of your TacoBell class
            //Since it conforms to ITrackable

            //DO not fail if one record parsing fails, return null

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