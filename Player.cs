using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Player : Character
    {
        public int Gold;
        public int GoblinsKilled;
        public int TrollsKilled;
        public int OrcsKilled;
        public bool IsDone;
        public Player(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack)
        {
            Gold = 0;
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
