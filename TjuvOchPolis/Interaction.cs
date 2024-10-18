using System;
using System.Collections.Generic;
using System.Linq;
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
                        if (City.people[i] is Thief thief && City.people[j] is Citizen citizen)
                        {
                            ThiefCitizen(thief, citizen);
                        }
                        else if (City.people[i] is Thief thief2 && City.people[j] is Police police)
                        {
                            ThiefPolice(thief2, police);
                        }
                        else if (City.people[i] is Citizen citizen2 && City.people[j] is Police police2)
                        {
                            CitizenPolice(citizen2, police2);
                        }


                    }
                }
            }
        }
        public void ThiefCitizen(Thief thief, Citizen citizen)
        {
            if (citizen.Valuables.Count > 0)
            {
                thief.Loots.Add(citizen.Valuables[0]);
                citizen.Valuables.RemoveAt(0);
                Console.WriteLine("Thief steals from citizen");
                Console.WriteLine($"{thief} +  steals from  {citizen}");
                Console.ReadLine();
            }
        }

        public void ThiefPolice(Thief thief, Police police)
        {
            if (thief.Loots.Count > 0)
            {
                Console.WriteLine("Police arrests thief");
                police.Confiscated.Add(thief.Loots[0]);
                thief.Loots.RemoveAt(0);
                Console.WriteLine($"{police} arrests {thief}");
                Console.ReadLine();
            }
        }

        public void CitizenPolice(Citizen citizen, Police police)
        {
            Console.WriteLine("Citizen and police greet each other");
            Console.WriteLine($"{citizen}: Hello! {police}: Nice day isn't it?");
            Console.WriteLine($"{police}: Yes it is, have a nice day and stay safe {citizen}");
            Console.ReadLine();

        }
    }
}