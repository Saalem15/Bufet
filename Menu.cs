using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class MenuState : IGameState
    {
        private StateMachine stateMachine;
        public MenuState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            bool selectedOption = false;
            while (selectedOption is false)
            {
                Console.WriteLine("1. Walka");
                Console.WriteLine("2. Bodzio");
                Console.WriteLine("3. Sklep");
                Console.WriteLine("4. Plecak");
                Console.WriteLine("5. Jaskinia");
                Console.WriteLine("9. Wyłącz Gre");
                Console.WriteLine();

                var pressedKey = Console.ReadKey();
                switch (pressedKey.KeyChar)
                {
                    case '1':
                        //fight
                        selectedOption = ChooseMonster();
                        break;
                    case '2':
                        //talk
                        stateMachine.ChangeState(new TalkState(stateMachine));
                        selectedOption = true;
                        break;
                    case '3':
                        //shop
                        stateMachine.ChangeState(new ShopState(stateMachine));
                        selectedOption = true;
                        break;
                    case '4':
                        //eq
                        stateMachine.ChangeState(new EqState(stateMachine));
                        selectedOption = true;
                        break;
                    case '5':
                        //boss
                        stateMachine.ChangeState(new BossState(stateMachine));
                        selectedOption = true;
                        break;
                    case '9':
                        //Exit
                        return false;
                    default:
                        Console.WriteLine("Niepoprawna Komenda");
                        break;



                }

            }
            return true;


        }

        private bool ChooseMonster()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Wybierz potwora, z którym chcesz walczyć:");
            Console.WriteLine("1. Goblin");
            Console.WriteLine("2. Troll");
            Console.WriteLine("3. Ork");
            Console.WriteLine();

            var pressedKey = Console.ReadKey();
            switch (pressedKey.KeyChar)
            {
                case '1':
                    // Walka z goblinem
                    stateMachine.ChangeState(new FightState(stateMachine, "Goblin"));
                    return true;
                case '2':
                    // Walka z trollem
                    stateMachine.ChangeState(new FightState(stateMachine, "Troll"));
                    return true;
                case '3':
                    // Walka z orkiem
                    stateMachine.ChangeState(new FightState(stateMachine, "Ork"));
                    return true;
                default:
                    Console.WriteLine("Niepoprawna Komenda");
                    return false;
            }
        }






    }
}
