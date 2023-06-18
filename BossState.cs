using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class BossState : IGameState
    {
        private StateMachine stateMachine;

        public BossState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public bool Process()
        {
            if(stateMachine.MyQuest.IsCompleted)
            {
                Console.WriteLine("Widzisz smoka, czy chcesz go zaatakować?");
                Console.WriteLine("1. Tak");
                Console.WriteLine("2. Nie");
                var key = Console.ReadKey();
                if (key.KeyChar == '1')
                {
                    stateMachine.ChangeState(new FightState(stateMachine, "Dragon"));
                }
                else if (key.KeyChar == '2')
                {
                    stateMachine.ChangeState(new MenuState(stateMachine));
                }
                else
                {
                    Console.WriteLine("Błąd");  
                }

                return true;
            }
            else
            {
                Console.WriteLine("Nie możesz tu wejść. Pogadaj z Bodziem.");
                stateMachine.ChangeState(new MenuState(stateMachine));
                return true;
            }
        }
    }
}
