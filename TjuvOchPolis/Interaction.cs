﻿using System;
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

        // Calculation of crimes and solved crimes
        public static int Crimes { get; set; } = 0;
        public static int CrimesSolved { get; set; } = 0;
        // Interaction between people
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


        // Make sure interaction is handled correctly
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


        // The violent interaction between the thief and the citizen        
        public void ThiefCitizen(Thief thief, Citizen citizen)
        {
            int Crimes = 0;


            if (citizen.Valuables.Count > 0)
            {
                Interaction.Crimes++;

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
                Thread.Sleep(1200);
                Console.SetCursorPosition(0, 48);
            }
            else
            {
                Console.WriteLine($"{thief} tries to steal from {citizen}, but {citizen} has nothing of value.");
                Thread.Sleep(1200);
                Console.SetCursorPosition(0, 48);
            }
        }


        // The hostile interaction between the thief and the police
        public void ThiefPolice(Thief thief, Police police)
        {
            int CrimesSolved = 0;
            if (thief.Loots.Count > 0 )
            {
                Interaction.CrimesSolved++;

                Console.WriteLine($"{police} arrests {thief}");
                Console.WriteLine($"The {police} confiscated these valuables from the {thief}");
                foreach (Item confiscatedItem in thief.Loots)
                {
                    police.Confiscated.Add(confiscatedItem);
                    Console.WriteLine($"{confiscatedItem.GetType().Name}: {confiscatedItem.Name}");
                }
                thief.Loots.Clear();
                if (City.prison.AddToPrison(thief))
                {
                    City.cityGrid[thief.Row, thief.Col] = 0;
                    City.people.Remove(thief);
                }
                else
                {
                    Console.WriteLine($"Failed to imprison {thief.Name}");
                }
                Console.WriteLine();
                Thread.Sleep(1200);
                Console.SetCursorPosition(0, 48);
            }
            else
            {
                Console.WriteLine($"{police} investigates {thief}");
                Console.WriteLine($"{thief} has done nothing wrong, so {police} is letting the {thief} continue with its day");
                Thread.Sleep(1200);
                Console.SetCursorPosition(0, 48);
            }
        }

        // The friendly interaction between the citizen and the police
        public void CitizenPolice(Citizen citizen, Police police)
        {
            Console.WriteLine($"{citizen} and {police} greet each other");
            Console.WriteLine($"{citizen}: Hello! {police} Nice day isn't it?");
            Console.WriteLine($"{police}: Yes it is, have a nice day and stay safe {citizen}");
            Thread.Sleep(1200);
            Console.SetCursorPosition(0, 48);
        }
    }
}