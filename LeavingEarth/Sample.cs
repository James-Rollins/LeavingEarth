using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Sample : Card
    {
        public int Mass { get; set; }

        public static void SetSamples(XmlDocument CardsXml, List<Sample> samples)
        {
            XmlNodeList xnlSamples = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Samples']");
            foreach (XmlNode node in xnlSamples)
            {
                Sample sample = new Sample();
                sample.Name = node.Attributes["name"].Value;
                sample.Mass = Convert.ToInt16(node.Attributes["mass"].Value);
                sample.Image = node.Attributes["image"].Value;
                samples.Add(sample);
            }
        }
    }
}
