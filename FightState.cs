using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class FightState : IGameState
    {
        private StateMachine stateMachine;
        private Character monster;

        public FightState(StateMachine stateMachine, string monsterType)
        {
            this.stateMachine = stateMachine;

            switch (monsterType)
            {
                case "Goblin":
                    monster = new Character("Goblin", 30, 10);
                    break;
                case "Troll":
                    monster = new Character("Troll", 40, 20);
                    break;
                case "Ork":
                    monster = new Character("Ork", 50, 30);
                    break;
                default:
                    throw new ArgumentException($"Nieznany typ potwora: {monsterType}");
            }
        }

        public bool Process()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Walka zaczęła się! Walczysz z {monster.Name}");
            Console.WriteLine();

            while (true)
            {
                // Tura gracza
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Twoja tura! Wybierz akcję: 1. Atak 2. Ucieczka");
                Console.WriteLine();
                var key = Console.ReadKey();
                if (key.KeyChar == '1')
                {
                    Console.WriteLine();
                    monster.Health -= stateMachine.Player.Attack;
                    Console.WriteLine();
                    Console.WriteLine($"{stateMachine.Player.Name} zaatakował {monster.Name}. Pozostałe zdrowie potwora: {monster.Health}");
                    Console.WriteLine();
                }
                else if (key.KeyChar == '2')
                {
                    Console.WriteLine();
                    Console.WriteLine("Uciekasz z walki. Wróć, kiedy będziesz gotowy.");
                    Console.WriteLine();
                    stateMachine.ChangeState(new MenuState(stateMachine));
                    return true;
                }

                if (monster.Health <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Pokonałeś potwora! Powrót do menu...");
                    Console.WriteLine();
                    switch (monster.Name)
                    {
                        case "Goblin":
                            stateMachine.Player.Gold += 10;
                            Console.WriteLine("Otrzymałeś 10 złota");
                            Console.WriteLine();
                            break;
                        case "Troll":
                            stateMachine.Player.Gold += 20;
                            Console.WriteLine("Otrzymałeś 20 złota");
                            Console.WriteLine();
                            break;
                        case "Ork":
                            stateMachine.Player.Gold += 30;
                            Console.WriteLine("Otrzymałeś 30 złota");
                            Console.WriteLine();
                            break;
                        default:
                            throw new ArgumentException($"Nieznany typ potwora: {monster.Name}");
                    }
                    stateMachine.ChangeState(new MenuState(stateMachine));
                    return true;
                }

                // Tura potwora
                stateMachine.Player.Health -= monster.Attack;
                Console.WriteLine();
                Console.WriteLine($"{monster.Name} zaatakował {stateMachine.Player.Name}. Twoje pozostałe zdrowie: {stateMachine.Player.Health}");
                Console.WriteLine();

                if (stateMachine.Player.Health <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Zostałeś pokonany! Gra się kończy.");
                    Console.WriteLine();
                    return false;  // Gra się kończy, gdy gracz jest pokonany
                }
            }
        }
    }

}
