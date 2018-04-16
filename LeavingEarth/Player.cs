using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavingEarth
{
    class Player
    {
        public int Score { get; set; }
        public int Funding { get; set; }

        public void Setup()
        {
            Score = 0;
            Funding = 25;
        }

        public void EndTurn()
        {
            Score++;
            Funding--;
        }

    }
}
