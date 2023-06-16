using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    interface IState
    {
        // kazdy stan musi wiedziec kto go uzywa, na wypadek gdyby potrzebowal wywolac metode ChangeState 
        protected Menu parentApp;

        // dlatego bedziemy podawali obiekt typu GameApp w konstruktorze
        public GameState(GameApp app)
        {
            parentApp = app;
        }
        public abstract void InputQ();
        public abstract  void InputW();
        public abstract void InputE();
        public abstract void InputR();
    }
}
