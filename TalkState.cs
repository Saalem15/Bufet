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
            // Tutaj dodajemy logikę rozmowy.
            // Możesz zastąpić poniższe wiersze swoją własną logiką rozmowy.

            Console.WriteLine("Rozpoczynasz rozmowę!");

            Console.WriteLine("1. Zapytaj o zadanie");
            Console.WriteLine("2. Zapytaj o pogodę");
            Console.WriteLine("3. Zakończ rozmowę");

            var pressedKey = Console.ReadKey();

            switch (pressedKey.KeyChar)
            {
                case '1':
                    Console.WriteLine("Zadajesz pytanie o zadanie.");
                    // Tutaj dodajesz logikę zadawania pytań o zadanie.
                    break;
                case '2':
                    Console.WriteLine("Zadajesz pytanie o pogodę.");
                    // Tutaj dodajesz logikę zadawania pytań o pogodę.
                    break;
                case '3':
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
