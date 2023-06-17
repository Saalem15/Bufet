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

        public void EquipArmor(Armor armor)
        {
            Armor = armor;
            // Zwiększamy zdrowie o wartość zbroi
            Health = BaseHealth + armor.HealthBoost;
        }

        public void EquipWeapon(Weapon weapon)
        {
            Weapon = weapon;
            // Zwiększamy atak o wartość broni
            Attack = BaseAttack + weapon.AttackBoost;
        }
    }

}
