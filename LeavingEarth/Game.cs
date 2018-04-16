using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace LeavingEarth
{
    class Game
    {
        // Properties
        public int Year { get; set; }
        List<Rocket> Rockets = new List<Rocket>();
        List<Supply> Supplies = new List<Supply>();
        List<Sample> Samples = new List<Sample>();
        List<Capsule> Capsules = new List<Capsule>();
        List<Astronaut> Astronauts = new List<Astronaut>();
        List<Location> Locations = new List<Location>();
        List<Mission> Missions = new List<Mission>();

        public void Turn(Player player)
        {
           
        }
        public void EndTurn()
        {
            // Increments the year by one at the end of the turn
            Year++;
        }



        public void SetUp(string difficulty)
        {
            // Sets the beginning year
            Year = 1956;
           
            // Creates an XML Document from the Cards.xml file
            XmlDocument CardsXml = new XmlDocument();
            CardsXml.Load(@"../../Cards.xml");

            // Instanciates cards for a new game.
            Rocket.SetRockets(CardsXml, Rockets);
            Supply.SetSupplies(CardsXml, Supplies);
            Sample.SetSamples(CardsXml, Samples);
            Capsule.SetCapsules(CardsXml, Capsules);
            Astronaut.SetAstronauts(CardsXml, Astronauts);
            Location.SetLocations(CardsXml, Locations);
            Radiation.SetRadiationLevel(CardsXml);
            Mission.SetMissions(CardsXml, Missions, difficulty);
            
            // Set mission cards

        }

        public List<string> MissionSources()
        {
            List<string> sources = new List<string>();
           foreach (Mission mission in Missions)
            {
                sources.Add(mission.Image);
            }
            return sources;
        }
        
       

     
    }
}
