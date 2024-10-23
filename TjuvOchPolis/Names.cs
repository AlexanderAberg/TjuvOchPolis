using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Names
    {
        public static string GetRandomName()
        {
            string[] names =
            {
                    "Adnan", "Agata", "Alexander", "Ariana" , "Arvid", "Emelie","Ermias", "Ilayda",
                    "Jonathan", "Gabriel", "Hanna", "Joel", "Kevin", "Max", "Mesgun", "Niklas", "Rabar", 
                    "Robin", "Sabina", "Sabrina", "Sam", "Suleman", "Toba", "William", "Zakaria", "Zahra"
                };
            return names[City.random.Next(names.Length)];
        }
    }
}
