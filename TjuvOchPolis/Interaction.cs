using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TjuvOchPolis;

namespace TjuvOchPolis
{
    public class Interaction
    {
        public void InteractionBetweenPeople()
        {
            for (int i = 0; i < City.people.Count; i++)
            {
                for (int j = 0; j < City.people.Count; j++)
                {
                    if (City.people[i].Row == City.people[j].Row && City.people[i].Col == City.people[j].Col)
                    {
                        HandleInteraction(City.people[i], City.people[j]);
                    }
                }
            }
        }

        public void HandleInteraction(People person1, People person2)
        {
            if (person1 is Thief thief && person2 is Citizen citizen)
            {
                ThiefCitizen(thief, citizen);
            }
            else if (person1 is Thief thief2 && person2 is Police police)
            {
                ThiefPolice(thief2, police);
            }
            else if (person1 is Citizen citizen2 && person2 is Police police2)
            {
                CitizenPolice(citizen2, police2);
            }
        }


                 
        public void ThiefCitizen(Thief thief, Citizen citizen)
        {
            int crimes = 0;


            if (citizen.Valuables.Count > 0)
            {
                crimes++;
                //List<Item> stolenLoot = new List<Item>();

                int randomIndex = City.random.Next(citizen.Valuables.Count);
                Item stolenLoot = citizen.Valuables[randomIndex];
                citizen.Valuables.RemoveAt(randomIndex);
                thief.Loots.Add(stolenLoot);
                Console.WriteLine($"{thief} steals {stolenLoot.GetType().Name} from {citizen}:");
                foreach (var property in typeof(Item).GetProperties())
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(stolenLoot)}");
                }
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine($"{thief} tries to steal from {citizen}, but {citizen} has nothing of value.");
                Console.ReadLine();
                Console.Clear();
                Thread.Sleep(500);
            }
        }

        public void ThiefPolice(Thief thief, Police police)
        {
            int crimes = 0;
            while (thief.Loots.Count > 0 && crimes < 4)
            {
                crimes++;
                List<Item> confiscatedItem = new List<Item>();
            }
            if (thief.Loots.Count > 0)
            {
                Item confiscatedItem = thief.Loots[0];
                thief.Loots.RemoveAt(0);
                police.Confiscated.Add(confiscatedItem);
                Console.WriteLine($"{police} arrests {thief}");
                Console.WriteLine($"The {police} confiscated {confiscatedItem.GetType()} from the {thief}");
                Console.ReadLine();
                Thread.Sleep(500);
                Console.Clear();
            }
        }

        public void CitizenPolice(Citizen citizen, Police police)
        {
            Console.WriteLine("{Citizen} and {police} greet each other");
            Console.WriteLine($"{citizen}: Hello! {police} Nice day isn't it?");
            Console.WriteLine($"{police}: Yes it is, have a nice day and stay safe {citizen}");
            Console.ReadLine();
            Console.Clear();
            Thread.Sleep(500);
        }
    }
}