using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Location : Card
    {
        public float Incapacitation { get; set; }
        public string Unknown { get; set; }
        public int Payment { get; set; }
        public List<Maneuver> Manuevers = new List<Maneuver>();


        public static void SetLocations(XmlDocument CardsXml, List<Location> locations)
        {
            // Add location cards that are not multiples. Some locations will be selected randomly for setup
            XmlNodeList xnlLocations = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Location' and @multiple != 'yes']");

            // Set the properties for each card selected
            foreach (XmlNode node in xnlLocations)
            {
                Location location = new Location();
                location.Name = node.Attributes["name"].Value;
                location.Unknown = node.Attributes["unknown"].Value;
                location.Payment = Convert.ToInt16(node.Attributes["payment"].Value);
                location.Incapacitation = Convert.ToSingle(node.Attributes["incapacitation"].Value);
                location.Image = node.Attributes["image"].Value;
                XmlNodeList xnlManeuvers = node.SelectNodes(@"Maneuver");
                foreach (XmlNode mannode in xnlManeuvers)
                {
                    Maneuver maneuver = new Maneuver();
                    maneuver.Location = mannode.Attributes["location"].Value;
                    maneuver.Difficulty = Convert.ToInt16(mannode.Attributes["difficulty"].Value);
                    maneuver.Time = Convert.ToInt16(mannode.Attributes["time"].Value);
                    maneuver.Hazard = mannode.Attributes["hazard"].Value;
                    maneuver.Requirement = mannode.Attributes["requirement"].Value;
                    maneuver.Atmosphere = mannode.Attributes["atmosphere"].Value;
                    location.Manuevers.Add(maneuver);
                }
                
                locations.Add(location);
            }
            // Create a random number
            Random Rdm = new Random();

            // Method call selects location cards with multiple instances and randomizes them
            string[] MultiLocationCards = new string[7] { "Suborbital", "Moon", "Venus", "Ceres", "Phobos", "Mars", "Mercury" };
            foreach (var card in MultiLocationCards)
            {
                SelectRandomCard(CardsXml, locations, Rdm, card);
            }

        }

        /*  SelectRandomCard selects locations randomly for those location cards that require an unseen shuffle
         
             */


        private static void SelectRandomCard(XmlDocument cardsxml, List<Location> location, Random rdm, string cardname)
        {
            int CardCount = cardsxml.SelectNodes(@"/Cards/Card[@type = 'Location' and @name = '" + cardname + "']").Count;
            int CardSelect = rdm.Next(1, CardCount);
            XmlNodeList Cards = cardsxml.SelectNodes(@"/Cards/Card[@name = '" + cardname + "']");
            Location crd = new Location();
            crd.Name = Cards[CardSelect].Attributes["name"].Value;
            crd.Unknown = Cards[CardSelect].Attributes["unknown"].Value;
            crd.Payment = Convert.ToInt16(Cards[CardSelect].Attributes["payment"].Value);
            crd.Incapacitation = Convert.ToSingle(Cards[CardSelect].Attributes["incapacitation"].Value);
            crd.Image = Cards[CardSelect].Attributes["image"].Value;
            XmlNodeList xnlManeuvers = Cards[CardSelect].SelectNodes(@"Maneuver");
            foreach (XmlNode mannode in xnlManeuvers)
            {
                Maneuver maneuver = new Maneuver();
                maneuver.Location = mannode.Attributes["location"].Value;
                maneuver.Difficulty = Convert.ToInt16(mannode.Attributes["difficulty"].Value);
                maneuver.Time = Convert.ToInt16(mannode.Attributes["time"].Value);
                maneuver.Hazard = mannode.Attributes["hazard"].Value;
                maneuver.Requirement = mannode.Attributes["requirement"].Value;
                maneuver.Atmosphere = mannode.Attributes["atmosphere"].Value;
                crd.Manuevers.Add(maneuver);
            }
            location.Add(crd);
        }
    }
}
