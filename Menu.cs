﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Menu : IState
    {
        public void HandleInput(char input)
        {
            switch(input)
            {
                case 'q': ExitMenu();
                    break;
                case 'w': StartGame();
                    break;
            }
        }
        void ExitMenu()
        {
            
        }
        void StartGame()
        {

        }
    


    }
}
