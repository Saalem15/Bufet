using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class ShopState : IGameState
    {
        private StateMachine stateMachine;
        private List<Armor> armors;
        private List<Weapon> weapons;

        public ShopState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

            armors = new List<Armor>
        {
            new Armor("Lekka zbroja", 100, 50),
            new Armor("Średnia zbroja", 200, 100),
            new Armor("Ciężka zbroja", 300, 150)
        };

            weapons = new List<Weapon>
        {
            new Weapon("Miecz", 100, 50),
            new Weapon("Topór", 200, 100),
            new Weapon("Miecz dwuręczny", 300, 150)
        };
        }

        public bool Process()
        {
            Console.WriteLine("Witaj w sklepie!");
            Console.WriteLine("1. Kup zbroję");
            Console.WriteLine("2. Kup broń");
            Console.WriteLine("3. Kup miksturę zdrowia");
            Console.WriteLine("4. Wróć do menu");

            var choice = Console.ReadKey();

            switch (choice.KeyChar)
            {
                case '1':
                    BuyArmor();
                    break;
                case '2':
                    BuyWeapon();
                    break;
                case '3':
                    BuyPotion();
                    break;
                case '4':
                    stateMachine.ChangeState(new MenuState(stateMachine));
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór!");
                    break;
            }

            return true;
        }

        private void BuyArmor()
        {
            for (int i = 0; i < armors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {armors[i].Name}, cena: {armors[i].Price}");
            }

            var choice = Console.ReadKey();
            int index = choice.KeyChar - '1';

            if (index >= 0 && index < armors.Count)
            {
                if (stateMachine.Player.Gold >= armors[index].Price)
                {
                    stateMachine.Player.EquipArmor(armors[index]);
                    stateMachine.Player.Gold -= armors[index].Price;

                    // Usuń zakupioną zbroję i wszystkie tańsze
                    armors = armors.Where(armor => armor.Price > armors[index].Price).ToList();

                    Console.WriteLine("Zakupiono zbroję!");
                }
                else
                {
                    Console.WriteLine("Nie masz wystarczającej ilości złota!");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
            }
        }

        private void BuyWeapon()
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {weapons[i].Name}, cena: {weapons[i].Price}");
            }

            var choice = Console.ReadKey();
            int index = choice.KeyChar - '1';

            if (index >= 0 && index < weapons.Count)
            {
                if (stateMachine.Player.Gold >= weapons[index].Price)
                {
                    stateMachine.Player.EquipWeapon(weapons[index]);
                    stateMachine.Player.Gold -= weapons[index].Price;

                    // Usuń zakupioną broń i wszystkie tańsze
                    weapons = weapons.Where(weapon => weapon.Price > weapons[index].Price).ToList();

                    Console.WriteLine("Zakupiono broń!");
                }
                else
                {
                    Console.WriteLine("Nie masz wystarczającej ilości złota!");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór!");
            }
        }

        private void BuyPotion()
        {
            if (stateMachine.Player.Gold >= 50)
            {
                stateMachine.Player.Gold -= 50;
                stateMachine.Player.Potions += 1;
            }
            else
            {
                Console.WriteLine("Nie masz wystarczającej ilości złota!");
            }
        }
    }

}
