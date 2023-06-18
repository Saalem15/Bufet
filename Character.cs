using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Character
    {
        public string Name { get; set; }
        public int BaseHealth { get; set; }
        public int BaseAttack { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }

        public Character(string name, int baseHealth, int baseAttack)
        {
            Name = name;
            BaseHealth = baseHealth;
            BaseAttack = baseAttack;
            Health = baseHealth;
            Attack = baseAttack;
        }


    }

}
