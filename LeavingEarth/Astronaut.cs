using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Astronaut : Card
    {
        public int Price { get; set; }
        public string Skill { get; set; }

        public static void SetAstronauts(XmlDocument CardsXml, List<Astronaut> astronauts)
        {
            XmlNodeList xnlAstronauts = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Astronaut']");
            foreach (XmlNode node in xnlAstronauts)
            {
                Astronaut astronaut = new Astronaut();
                astronaut.Name = node.Attributes["name"].Value;
                astronaut.Price = Convert.ToInt16(node.Attributes["price"].Value);
                astronaut.Skill = node.Attributes["skill"].Value;
                astronaut.Image = node.Attributes["image"].Value;
                astronauts.Add(astronaut);
            }
        }
    }
}
