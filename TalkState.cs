using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class TalkState : IGameState
    {
        private StateMachine stateMachine;

        public TalkState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[Bodzio]: Witaj, czego chcesz się dowiedzieć?");
            Console.WriteLine();
            Console.WriteLine("1. Zapytaj o zadanie");
            Console.WriteLine("2. Zakończ rozmowę");
            Console.WriteLine();

            var pressedKey = Console.ReadKey();

            switch (pressedKey.KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Co muszę jeszcze zrobić, aby móc wejść do jaskini smoka?");
                    Console.WriteLine();
                    Console.WriteLine("[Bodzio]:");
                    stateMachine.MyQuest.UpdateQuest(stateMachine.Player.GoblinsKilled, stateMachine.Player.TrollsKilled, stateMachine.Player.OrcsKilled);
                    Console.WriteLine();
                    stateMachine.ChangeState(new MenuState(stateMachine));
                    break;
                case '2':
                    Console.WriteLine("Kończysz rozmowę. Wróć do menu.");
                    stateMachine.ChangeState(new MenuState(stateMachine));
                    break;
                default:
                    Console.WriteLine("Niepoprawna komenda");
                    break;
            }

            return true;
        }
    }

}
