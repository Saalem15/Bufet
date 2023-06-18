using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Weapon : Equipment
    {
        public int AttackBoost { get; set; }
        public Weapon(string name, int ab, int price)
        {
            Name = name;
            AttackBoost = ab;
            Price = price;
        }
    }
}
