using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        public static void CityGrid()
        {
            {
                int[,] cityGrid = new int[33, 70];

                cityGrid[0, 0] = 1;
       //       previousValue = 0;

                for (int row = 0; row < cityGrid.GetLength(0); row++)
                {
                    for (int col = 0; col < cityGrid.GetLength(1); col++)
                    {

                        //if (row == 0 && col == 0)
                        //{
                        //}
                        //else
                        //{
                        //    if (col == 0)
                        //    {
                        //        previousValue = cityGrid[row - 1, 7];
                        //    }
                        //    else
                        //    {
                        //        previousValue = cityGrid[row, col - 1];
                        //    }
                        //}
                        //if (previousValue == 0)
                        //{
                        //    cityGrid[row, col] = 1;
                        //}
                        //else
                        //{
                        //    cityGrid[row, col] = previousValue * 2;
                        //}


                        Console.Write(cityGrid[row, col] + " ");

                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
