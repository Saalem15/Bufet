using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            // Inicjalizacja list przedmiotów do kupienia
            armors = new List<Armor>()
            {
            new Armor("Lekka zbroja", 50, 10),
            new Armor("Średnia zbroja", 100, 20),
            new Armor("Ciężka zbroja", 200, 30)
            };

            weapons = new List<Weapon>()
            {
            new Weapon("Miecz", 30, 15),
            new Weapon("Topór", 70, 25),
            new Weapon("Miecz dwuręczny", 120, 35)
            };
        }

        public bool Process()
        {
            while (true)
            {
                Console.WriteLine("1. Kup zbroję");
                Console.WriteLine("2. Kup broń");
                Console.WriteLine("3. Powrót do menu");

                var pressedKey = Console.ReadKey();
                switch (pressedKey.KeyChar)
                {
                    case '1':
                        BuyArmor();
                        break;
                    case '2':
                        BuyWeapon();
                        break;
                    case '3':
                        stateMachine.ChangeState(new MenuState(stateMachine));
                        return true;
                    default:
                        Console.WriteLine("Niepoprawna Komenda");
                        break;
                }
            }


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
                    for (int i = armors.Count - 1; i >= 0; i--)
                    {
                        if (armors[i].Price <= armors[index].Price)
                        {
                            armors.RemoveAt(i);
                        }
                    }

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
                    for (int i = weapons.Count - 1; i >= 0; i--)
                    {
                        if (weapons[i].Price <= weapons[index].Price)
                        {
                            weapons.RemoveAt(i);
                        }
                    }

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

    }
}
