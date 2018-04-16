using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Radiation : Card
    {
        public int Level { get; set; }

        public static void SetRadiationLevel(XmlDocument CardsXml)
        {
            Random Rdm = new Random();
            int Card = Rdm.Next(1, 3);
            Radiation radiation = new Radiation();
            XmlNodeList xnlRadiation = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Radiation']");

            radiation.Level = Convert.ToInt16(xnlRadiation[Card].Attributes["level"].Value);
            radiation.Image = xnlRadiation[Card].Attributes["image"].Value;
        }
    }
}
