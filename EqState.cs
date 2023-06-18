using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class EqState : IGameState
    {
        private StateMachine stateMachine;

        public EqState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("1. Sprawdź ilość pieniędzy");
                Console.WriteLine("2. Sprawdź zbroje");
                Console.WriteLine("3. Sprawdź broń");
                Console.WriteLine("4. Powrót do menu");

                var pressedKey = Console.ReadKey();
                switch (pressedKey.KeyChar)
                {
                    case '1':
                        Console.WriteLine($"Ilość twoich złota: {stateMachine.Player.Gold}");
                        break;
                    case '2':
                        Console.WriteLine($"Twoja zbroja: {stateMachine.Player.Armor.Name}, Ochrona: {stateMachine.Player.Armor.HealthBoost}");
                        break;
                    case '3':
                        Console.WriteLine($"Twoja broń: {stateMachine.Player.Weapon.Name}, Atak: {stateMachine.Player.Weapon.AttackBoost}");
                        break;
                    case '4':
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna Komenda");
                        break;
                }
            }
            return true;
        }
    }
}
