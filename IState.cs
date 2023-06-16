using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    interface IState
    {
        public abstract void HandleInput(char input);
  
    }
}
