using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavingEarth
{
    class Maneuver : Location
    {
        public string Location { get; set; }
        public int Difficulty { get; set; }
        public int Time { get; set; }
        public string Requirement { get; set; }
        public string Hazard { get; set; }
        public string Atmosphere { get; set; }

    }
}
