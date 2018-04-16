using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Supply : Card
    {
        public int Mass { get; set; }
        public int Price { get; set; }

        public static void SetSupplies(XmlDocument CardsXml, List<Supply> supplies)
        {
            XmlNodeList xnlSupplies = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Supplies']");
            foreach (XmlNode node in xnlSupplies)
            {
                Supply supply = new Supply();
                supply.Name = node.Attributes["name"].Value;
                supply.Mass = Convert.ToInt16(node.Attributes["mass"].Value);
                supply.Price = Convert.ToInt16(node.Attributes["price"].Value);
                supply.Image = node.Attributes["image"].Value;
                supplies.Add(supply);
            }
        }
    }
}
