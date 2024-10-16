using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class People
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public People(string name, List<Item>items)
        {
            Name = name;
            Items = items;
        }
    }

    public class Thief : People
    {
        public List<Loot> Loots { get; set; }
        public Thief(string name, List<Item> items, List<Loot> loots) : base(name, items)
        {
            Loots = loots;
        }
    }

    public class Police : People
    {
        public List<Evidence> Evidences { get; set; }
        public Police(string name, List<Item> items, List<Evidence> evidences) : base(name, items)
        {
            Evidences = evidences;
        }
    }

    public class Citizen : People
    {
        public List<Valuable> Valuables { get; set; }
        public Citizen(string name, List<Item> items, List<Valuable> valuables) : base(name, items)
        {
            Valuables = valuables;
        }
    }
}
