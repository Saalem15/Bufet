using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Otwierasz ekwipunek!");

            // Tutaj dodajesz logikę ekwipunku.

            // Na razie po prostu wróćmy do MenuState
            Console.WriteLine("Zamykasz ekwipunek i wracasz do menu.");
            stateMachine.ChangeState(new MenuState(stateMachine));
            return true;
        }
    }
}
