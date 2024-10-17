using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    // The base class for all people
    public class People
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Direction { get; set; }

        public People(string name)
        {
            Name = name;
            Direction = Random.Shared.Next(0,6);
        }
    }
    
    // The thief
    public class Thief : People
    {
        public List<Item> Loots { get; set; }
        public Thief(string name, List<Item> loots) : base(name)
        {
            Loots = loots;
        }
    }

    // The police
    public class Police : People
    {
        public List<Item> Confiscated { get; set; }
        public Police(string name, List<Item> confiscated) : base(name)
        {
            Confiscated = confiscated;
        }
    }

    // The citizen
    public class Citizen : People
    {
        public List<Item> Valuables { get; set; }
        public Citizen(string name, List<Item> valuables) : base(name)
        {
            Valuables = valuables;
        }
    }
}
