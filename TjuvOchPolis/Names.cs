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
                    "Jonathan", "Gabriel", "Hanna", "Joel", "Kevin", "Max", "Mesgun", "Niklas", "Neo", "Rabar", 
                    "Robin", "Sabina", "Sabrina", "Sam", "Suleman", "Taha", "Toba", "William", "Yusuf", "Zakaria", "Zahra"
                };
            return names[City.random.Next(names.Length)];
        }
    }
}
