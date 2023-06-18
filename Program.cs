using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Gierka
{
    internal class Program
    {
        static void Main()
        {
            var stateMachine = new StateMachine();
            while (stateMachine.Run())
            {

            }   
        }
    }
}