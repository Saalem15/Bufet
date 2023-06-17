using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class BreadState : IGameState
    {
        private StateMachine stateMachine;

        public BreadState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            Console.WriteLine("Przygotowujesz chleb!");

            // Tutaj dodajesz logikę przygotowywania chleba.

            // Na razie po prostu wróćmy do MenuState
            Console.WriteLine("Skończyłeś przygotowywać chleb i wracasz do menu.");
            stateMachine.ChangeState(new MenuState(stateMachine));
            return true;
        }
    }
}
