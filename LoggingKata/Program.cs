using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Logger.Info("Log initialized");

            var csvPath = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";
            Logger.Debug("Created csvPath variable: " + csvPath);

            var rows = File.ReadAllLines(csvPath);

            if (rows.Length == 0)
            {
                Logger.Error("Our csv file is missing or empty of content");
            }
            else if (rows.Length == 1)
            {
                Logger.Warn("Can't compare. There is only one element");
            }

            var parser = new TacoParser();
            Logger.Debug("Initialized our Parser");

            var locations = rows.Select(row => parser.Parse(row));

            ITrackable a = null;
            ITrackable b = null;
            double distance = 0;

            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.

            Logger.Info("Comparing all locations in CSV file");

            foreach (var locA in locations)
            {
                Logger.Debug("Checking the origin locations");

                var origin = new Coordinate
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };

                foreach (var locB in locations)
                {
                    Logger.Debug("Checking the origin to the destination locations");

                    var dest = new Coordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                    Logger.Debug("Getting distance in miles");

                    var nDist = GeoCalculator.GetDistance(origin, dest);

                    if (nDist > distance)
                    {
                        a = locA;
                        b = locB;
                        distance = nDist;
                    }
                }
            }

            if (a == null || b == null)
            {
                Logger.Error("Failed to find furthest locations");
                Console.WriteLine("Couldn't find the locations furthest apart");
                Console.ReadLine();
                return;
            }


            var logMessage =
                $"The two Taco Bells that are furtherst apart are: {a.Name} and {b.Name}. These two locations are: {distance} miles apart.";

            Logger.Info(logMessage);
            Console.WriteLine(logMessage);

            Console.ReadLine();
        }
    }
}