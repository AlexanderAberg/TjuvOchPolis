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
        public List<Item> Loots { get; set; }
        public Thief(string name, List<Item> items, List<Item> loots) : base(name, items)
        {
            Loots = loots;
        }
    }

    public class Police : People
    {
        public List<Item> Evidences { get; set; }
        public Police(string name, List<Item> items, List<Item> evidences) : base(name, items)
        {
            Evidences = evidences;
        }
    }

    public class Citizen : People
    {
        public List<Item> Valuables { get; set; }
        public Citizen(string name, List<Item> items, List<Item> valuables) : base(name, items)
        {
            Valuables = valuables;
        }
    }
}
