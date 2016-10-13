using System.Collections.Generic;

namespace Day9.Model
{
    public class RoutePlan
    {
        public IList<string> Waypoints {get; set;}

        public int TotalLength { get; set; }
    }
}