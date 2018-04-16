using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavingEarth
{
    class Advancement : Card
    {
        public string Minor { get; set; }
        public string Major { get; set; }
        public int Outcomes { get; set; }
        public float Price { get; set; }
    }
}
