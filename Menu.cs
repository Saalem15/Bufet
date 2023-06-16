using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Menu : IState
    {
    

        public void InputQ()
        {
            Console.WriteLine("Exit");
        }

        public void InputW()
        {
            Console.WriteLine("Start");
        }

        public void InputE()
        {
            throw new NotImplementedException();
        }

        public void InputR()
        {
            throw new NotImplementedException();
        }
    }
}
