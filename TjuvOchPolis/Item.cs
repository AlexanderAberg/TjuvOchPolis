using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Item
    {
        public string Wallet { get; set; }
        public string Keys { get; set; }
        public string Mobile { get; set; }
        public string Watch { get; set; }

        public Item(string wallet, string keys, string mobile, string watch)
        {
            Wallet = wallet;
            Keys = keys;
            Mobile = mobile;
            Watch = watch;
        }
    }
}
