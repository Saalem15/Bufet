using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Armor : Equipment
    {
        public int HealthBoost { get; set; }
        public Armor(string name, int hb, int price)
        {
            Name = name;
            HealthBoost = hb;
            Price = price;
        }
    }
}
