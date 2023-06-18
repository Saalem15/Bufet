using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Potion : Equipment
    {
        private int healthRegen { get; set; }
        public Potion(string name, int hr, int price)
        {
            healthRegen = hr;
            Name = name;
            Price = price;
        }

    }
}
