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
            PutInPrison(thief);
            Console.WriteLine($"{thief.Name} has been imprisoned");
            }
            return false;
        }

        public bool PutInPrison(Thief thief)
        {
            int maxAttempts = PrisonGrid.GetLength(0) * PrisonGrid.GetLength(1);
            int attempts = 0;

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
    }
}
