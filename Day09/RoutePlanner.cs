using System;
using Day9.Model;
using System.Linq;
using System.Collections.Generic;

namespace Day9
{
    public class RoutePlanner
    {
        private IList<WayPoint> wayPoints;

        public RoutePlanner(string[] routesInput)
        {
            // Parse line and put into models
            this.wayPoints = routesInput
                .Select(x => x.Split(new [] { ' '}))
                .Select(x => new WayPoint
                {
                    Waypoints = new List<string>(){x[0], x[2]},
                    Length = Int32.Parse(x[4])
                })
                .ToList();
        }

        public IList<RoutePlan> GetPlans()
        {
            // Get a list of all unique destinations
            var destinations = wayPoints
                .SelectMany(x => x.Waypoints)
                .Distinct()
                .ToList();

            // Start recursive call for calulating all possible routes
            return CalculateRoutes(null, destinations, new List<string>());
        }

        private List<RoutePlan> CalculateRoutes(string startDestination, IList<string> remainingDestinations, IList<string> usedDestinations)
        {
            // The resulting routes from this particular call which will be aggreated
            List<RoutePlan> result = new List<RoutePlan>();

            // Create local copies of lists
            List<string> copyRemainingDst = new List<string>();
            List<string> copyUsedDst = new List<string>();
            copyRemainingDst.AddRange(remainingDestinations);
            copyUsedDst.AddRange(usedDestinations);

            // If this is the first iteration set start destination
            if(startDestination != null)
            {
                copyUsedDst.Add(startDestination);
                copyRemainingDst.Remove(startDestination);
            }

            // Determine if we have arrived at our final destination
            if(copyRemainingDst.Count > 0)
            {
                // Iterate through all remaining destinations
                foreach(var place in copyRemainingDst)
                {
                    // Add aggreated list for this particular route
                    result.AddRange(CalculateRoutes(place, copyRemainingDst, copyUsedDst));
                }
            } else {
                // We have finally arrived at the final destination
                // Lets calculate the plan and return it
                result.Add(EndPoint(copyUsedDst));
            }

            return result;
        }

        private RoutePlan EndPoint(IList<string> route)
        {
            // Calculate the length of the route
            int routeLength = 0;
            for(int x = 0; x < route.Count - 1; ++x)
            {
                routeLength += wayPoints.Single(y => y.Waypoints.Contains(route[x]) && y.Waypoints.Contains(route[x+1])).Length;
            }

            // Create plan DTO including the route and length
            return new RoutePlan
            {
                Waypoints = route,
                TotalLength = routeLength
            };
        }
    }
}