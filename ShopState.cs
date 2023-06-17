using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class ShopState : IGameState
    {
        private StateMachine stateMachine;

        public ShopState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            Console.WriteLine("Jesteś w sklepie!");

            // Tutaj dodajesz logikę sklepu.

            // Na razie po prostu wróćmy do MenuState
            Console.WriteLine("Opuszczasz sklep i wracasz do menu.");
            stateMachine.ChangeState(new MenuState(stateMachine));
            return true;
        }
    }
}
