using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Prison
    {
        public List<Thief> Prisoners { get; set; }
        public int[,] PrisonGrid { get; set; }

        public Prison()
        {
            Prisoners = new List<Thief>();
            PrisonGrid = new int[10, 10];
        }

        public bool AddToPrison(Thief thief)
        {
            if (PutInPrison(thief))
            {
                Prisoners.Add(thief);
                Console.WriteLine($"{thief.Name} has been imprisoned");
                return true;
            }
            return false;
        }

        public bool PutInPrison(Thief thief)
        {
            int maxAttempts = PrisonGrid.GetLength(0) * PrisonGrid.GetLength(1);
            int attempts = 0;
            // To make sure that thief will be denied prison slot if there is more thieves than size of prison
            while (attempts < maxAttempts)
            {
                int row = City.random.Next(PrisonGrid.GetLength(0));
                int col = City.random.Next(PrisonGrid.GetLength(1));

                if (PrisonGrid[row, col] == 0)
                {
                    PrisonGrid[row, col] = 1;
                    thief.Row = row;
                    thief.Col = col;
                    return true;
                }

                attempts++;
            }
            Console.WriteLine("Prison is full. Cannot add more thieves.");
            return false;
        }



        public void MovePrisoner()
        {
            foreach (Thief prisoner in Prisoners)
            {
                MovePrisoner(prisoner, this);
            }
        }


        // Movement direction for prisoner
        public void MovePrisoner(Thief prisoner, Prison prison)
        {
            prison.PrisonGrid[prisoner.Row, prisoner.Col] = 0;

            switch (prisoner.Direction)
            {
                case 0:
                    if (prisoner.Row > 0)
                    {
                        prisoner.Row--;
                        if (prisoner.Row == 0)
                        {
                            prisoner.Row = prison.PrisonGrid.GetLength(0) - 1;
                        }
                    }
                    break;
                case 1:
                    if (prisoner.Row < prison.PrisonGrid.GetLength(0) - 1)
                    {
                        prisoner.Row++;
                        if (prisoner.Row == prison.PrisonGrid.GetLength(0) - 1)
                        {
                            prisoner.Row = 0;
                        }
                    }
                    break;
                case 2:
                    if (prisoner.Col > 0)
                    {
                        prisoner.Col--;
                        if (prisoner.Col == 0)
                        {
                            prisoner.Col = prison.PrisonGrid.GetLength(1) - 1;
                        }
                    }
                    break;
                case 3:
                    if (prisoner.Col < prison.PrisonGrid.GetLength(1) - 1)
                    {
                        prisoner.Col++;
                        if (prisoner.Col == prison.PrisonGrid.GetLength(1) - 1)
                        {
                            prisoner.Col = 0;
                        }
                    }
                    break;
                case 4:
                    if (prisoner.Row > 0 && prisoner.Col > 0)
                    {
                        prisoner.Col--;
                        prisoner.Row--;
                        {
                            if (prisoner.Row == 0)
                            {
                                prisoner.Row = prison.PrisonGrid.GetLength(0) - 1;
                            }
                            if (prisoner.Col == 0)
                            {
                                prisoner.Col = prison.PrisonGrid.GetLength(1) - 1;
                            }
                        }
                    }
                    break;
                case 5:
                    if (prisoner.Row < prison.PrisonGrid.GetLength(0) - 1 && prisoner.Col > 0)
                    {
                        prisoner.Col--;
                        prisoner.Row++;
                        {
                            if (prisoner.Row == prison.PrisonGrid.GetLength(0) - 1)
                            {
                                prisoner.Row = 0;
                            }
                            if (prisoner.Col == prison.PrisonGrid.GetLength(1) - 1)
                            {
                                prisoner.Col = 0;
                            }
                        }
                    }
                    break;
            }

            PrisonGrid[prisoner.Row, prisoner.Col] = 1;
        }
    }
}
