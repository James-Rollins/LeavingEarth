using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Rocket : Card
    {
        public int Mass { get; set; }
        public int Thrust { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
        public int Outcomes { get; set; }

        public static void SetRockets(XmlDocument CardsXml, List<Rocket> rockets)
        {
            XmlNodeList xnlRockets = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Rocket']");
            foreach (XmlNode node in xnlRockets)
            {
                Rocket rocket = new Rocket();
                rocket.Name = node.Attributes["name"].Value;
                rocket.Thrust = Convert.ToInt16(node.Attributes["thrust"].Value);
                rocket.Mass = Convert.ToInt16(node.Attributes["mass"].Value);
                rocket.Price = Convert.ToInt16(node.Attributes["price"].Value);
                rocket.Time = Convert.ToInt16(node.Attributes["time"].Value);
                rocket.Image = node.Attributes["image"].Value;
                rockets.Add(rocket);
            }
        }
    }
}
