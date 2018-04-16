using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeavingEarth
{
    class Mission : Card
    {
        public string Requirement { get; set; }
        public string Location { get; set; }
        public int Points { get; set; }
        public int Time { get; set; }
        public string Diffculty { get; set; }

        public static void SetMissions(XmlDocument CardsXml, List<Mission> missions, string difficulty)
        {

            int[] Indices;
            Indices = SetMissionIndices(difficulty);
            XmlNodeList xnlMissions = CardsXml.SelectNodes(@"/Cards/Card[@type = 'Mission']");
            foreach (int node in Indices)
            {
                Mission mission = new Mission();
                mission.Requirement = xnlMissions[node].Attributes["requirement"].Value;
                mission.Image = xnlMissions[node].Attributes["image"].Value;
                mission.Location = xnlMissions[node].Attributes["location"].Value;
                mission.Points = Convert.ToInt16(xnlMissions[node].Attributes["points"].Value);
                mission.Time = Convert.ToInt16(xnlMissions[node].Attributes["time"].Value);
                mission.Diffculty = xnlMissions[node].Attributes["location"].Value;
                missions.Add(mission);
            }
            
        }

        private static int[] SetMissionIndices(string diff)
        {
            int RemoveNumber;
            int[] indices;
            int[] indicesEasy = { 1, 2, 3, 4, 5, 6};
            int[] indicesMedium = { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[] indicesHard = { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            int EasyNumber = 0;
            int MediumNumber = 0;
            int HardNumber = 0;
            
            Random Rdm = new Random();
            if (diff == "System.Windows.Controls.Button: Easy")
            {
                RemoveNumber = Rdm.Next(0, 5);
                indicesEasy = indicesEasy.Where((source, index) => index != RemoveNumber).ToArray();
                indicesMedium = indicesMedium.Where((source, index) => index < 0 && index > 9).ToArray();
                indicesHard = indicesHard.Where((source, index) => index < 0 && index > 9).ToArray();
            }
            else if (diff == "System.Windows.Controls.Button: Normal")
            { 
                EasyNumber = 2;
                indicesEasy = RemoveRandom(EasyNumber, indicesEasy);
                MediumNumber = 8;
                indicesMedium = RemoveRandom(MediumNumber, indicesMedium);
                HardNumber = 10;
                indicesHard = RemoveRandom(HardNumber, indicesHard);
            }
            else if (diff == "System.Windows.Controls.Button: Hard")
            {
                EasyNumber = 3;
                indicesEasy = RemoveRandom(EasyNumber, indicesEasy);
                MediumNumber = 7;
                indicesMedium = RemoveRandom(MediumNumber, indicesMedium);
                HardNumber = 8;
                indicesHard = RemoveRandom(HardNumber, indicesHard);
            }
            else
            {
                EasyNumber = 5;
                indicesEasy = RemoveRandom(EasyNumber, indicesEasy);
                MediumNumber = 6;
                indicesMedium = RemoveRandom(MediumNumber, indicesMedium);
                HardNumber = 6;
                indicesHard = RemoveRandom(HardNumber, indicesHard);
            }
            indices = indicesEasy.Concat(indicesMedium).Concat(indicesHard).ToArray();
            return indices;
        }

        private static int[] RemoveRandom(int NumberToRemove, int[] indices)
        {
            int length;
            Random Rdm = new Random();
            int remove;
            for (int i = 0; i < NumberToRemove; i++)
            {
                length = indices.Length;
                remove = Rdm.Next(0, length - 1);
                indices = indices.Where((source, index) => index != remove).ToArray();
            }
            return indices;
        }
    }


}
