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
                    monster = new Goblin();
                    break;
                case "Troll":
                    monster = new Troll();
                    break;
                case "Ork":
                    monster = new Orc();
                    break;
                case "Dragon":
                    monster = new Dragon();
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

            while (true)
            {
                // Tura gracza
                Console.WriteLine();
                Console.WriteLine("Twoja tura! Wybierz akcję: 1. Atak 2. Ucieczka 3. Ulecz się");
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
                else if (key.KeyChar == '3')
                {
                    if (stateMachine.Player.Potions >= 1)
                    {
                        stateMachine.Player.Health += 50;
                        if (stateMachine.Player.Health > stateMachine.Player.BaseHealth)
                        {
                            stateMachine.Player.Health = stateMachine.Player.BaseHealth;
                        }
                        stateMachine.Player.Potions -= 1;
                    }
                 
                }

                if (monster.Health <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Pokonałeś potwora! Powrót do menu...");
                    Console.WriteLine();
                    Console.WriteLine();
                    switch (monster.Name)
                    {
                        case "Goblin":
                            stateMachine.Player.Gold += 10;
                            stateMachine.Player.GoblinsKilled += 1;
                            Console.WriteLine("Otrzymałeś 10 złota");
                            Console.WriteLine();
                            break;
                        case "Troll":
                            stateMachine.Player.Gold += 20;
                            stateMachine.Player.TrollsKilled += 1;
                            Console.WriteLine("Otrzymałeś 20 złota");
                            Console.WriteLine();
                            break;
                        case "Ork":
                            stateMachine.Player.Gold += 30;
                            stateMachine.Player.OrcsKilled += 1;
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
