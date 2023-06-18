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

        public StateMachine()
        {
            // Inicjalizujemy postać gracza z podstawowymi statystykami
            Player = new Player("Gracz", 100, 20); // Możesz zmienić te wartości na takie, które są odpowiednie dla Twojej gry
            Armor shirt = new Armor("Koszula", 0, 0);
            Weapon stick = new Weapon("Patyk", 0, 0);
            Player.EquipArmor(shirt);
            Player.EquipWeapon(stick);

            // Ustawiamy początkowy stan na MenuState
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
