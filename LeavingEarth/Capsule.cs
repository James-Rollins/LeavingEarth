using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Capsule : Card
    {
        public int Mass { get; set; }
        public int Price { get; set; }
        public int Rads { get; set; }
        public int Payload { get; set; }

        public static void SetCapsules(XmlDocument CardsXml, List<Capsule> capsules)
        {
            XmlNodeList xnlCapsules = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Capsule']");
            foreach (XmlNode node in xnlCapsules)
            {
                Capsule capsule = new Capsule();
                capsule.Name = node.Attributes["name"].Value;
                capsule.Rads = Convert.ToInt16(node.Attributes["rads"].Value);
                capsule.Mass = Convert.ToInt16(node.Attributes["mass"].Value);
                capsule.Price = Convert.ToInt16(node.Attributes["price"].Value);
                capsule.Payload = Convert.ToInt16(node.Attributes["payload"].Value);
                capsule.Image = node.Attributes["image"].Value;
                capsules.Add(capsule);
            }
        }
    }
}
