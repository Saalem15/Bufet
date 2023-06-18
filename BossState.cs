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
