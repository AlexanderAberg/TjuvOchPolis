using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class City
    {
        public static int[,] cityGrid;
        public static List<People> people;
        public static Random random = new Random();

        public static void CityGrid()
        {
            cityGrid = new int[33, 70];
            people = new List<People>();
            CreatePerson();

            while (true)
            {
                DisplayGrid();
                MovePerson();
                System.Threading.Thread.Sleep(500);
                Console.Clear(); 
            }
        }

        // Create people in the city
        public static void CreatePerson()
        {
            for (int i = 0; i < 7; i++)
            {
                Police police = new Police($"Police{i}", new List<Item>(), new List<Item>());
                PutPerson(police, 7);
            }

            for (int i = 0; i < 15; i++)
            {
                Thief thief = new Thief($"Thief{i}", new List<Item>(), new List<Item>());
                PutPerson(thief, 15);
            }

            for (int i = 0; i < 30; i++)
            {
                Citizen citizen = new Citizen($"Citizen{i}", new List<Item>(), new List<Item>());
                PutPerson(citizen, 30);
            }
        }

        // Put people in the city
        public static void PutPerson(People person, int personValue)
        {
            int row, col;
            do
            {
                row = random.Next(cityGrid.GetLength(0));
                col = random.Next(cityGrid.GetLength(1));
            } 
            while (cityGrid[row, col] != 0);

            cityGrid[row, col] = personValue;
            person.Row = row;
            person.Col = col;
            people.Add(person);
        }

        public static void MovePerson()
        {
            foreach (var person in people)
            {
                MovePerson(person);
            }
        }

        // Movement directions for people
        public static void MovePerson(People person)
        {
            cityGrid[person.Row, person.Col] = 0;

            int direction = random.Next(4);
            switch (direction)
            {
                case 0: if (person.Row > 0) person.Row--; break; // Move up
                case 1: if (person.Row < cityGrid.GetLength(0) - 1) person.Row++; break; // Move down
                case 2: if (person.Col > 0) person.Col--; break; // Move left
                case 3: if (person.Col < cityGrid.GetLength(1) - 1) person.Col++; break; // Move right
                case 4: if (person.Row > 0 && person.Col > 0)
                    {
                        person.Col--;
                        person.Row--;
                    }
                    break;
                case 5:
                    if (person.Row < cityGrid.GetLength(0) - 1 && person.Col > 0)
                    {
                        person.Col--;
                        person.Row++;
                    }
                    break;
            }

  
            cityGrid[person.Row, person.Col] = person is Thief ? 2 : (person is Police ? 1 : 3);
        }

      

        public static void DisplayGrid()
        {
            for (int row = 0; row < cityGrid.GetLength(0); row++)
            {
                for (int col = 0; col < cityGrid.GetLength(1); col++)
                {
                    switch (cityGrid[row, col])
                    {
                        case 0: Console.Write(". "); break; // The part of the city
                        case 1: Console.Write("P "); break; // Police
                        case 2: Console.Write("T "); break; // Thief
                        case 3: Console.Write("C "); break; // Citizen
                        default: Console.Write("? "); break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
