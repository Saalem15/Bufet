using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class StateMachine
    {
        private IGameState currentState;
        public Player Player { get; private set; }
        public Quest MyQuest { get; private set; }

        public StateMachine()
        { 
            Player = new Player("Gracz", 100, 20); 
            Armor shirt = new Armor("Koszula", 0, 0);
            Weapon stick = new Weapon("Patyk", 0, 0);
            Player.EquipArmor(shirt);
            Player.EquipWeapon(stick);
            MyQuest = new Quest(10, 10, 10);
            this.currentState = new MenuState(this);
        }

        public void ChangeState(IGameState newState)
        {
            this.currentState = newState;
            // Regeneracja zdrowia po walce
            if (currentState is MenuState)
            {
                Player.Health = Player.BaseHealth;
            }
        }

        public bool Run()
        {
            return currentState.Process();
        }
    }

}
