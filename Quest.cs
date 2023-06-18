using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    public class Quest
    {
        public int GoblinCount { get; private set; }
        public int TrollCount { get; private set; }
        public int OrcCount { get; private set; }
        public bool IsCompleted { get; private set; }

        public Quest(int goblinCount, int trollCount, int orcCount)
        {
            GoblinCount = goblinCount;
            TrollCount = trollCount;
            OrcCount = orcCount;
            IsCompleted = false;
        }


        public void UpdateQuest(int goblinsKilled, int trollsKilled, int orcsKilled)
        {
            if (!IsCompleted && goblinsKilled >= GoblinCount && trollsKilled >= TrollCount && orcsKilled >= OrcCount)
            {
                IsCompleted = true;
                Console.WriteLine("Ukończyłeś misje, możesz wejść do jaskini.");
            }
            else
            {
                if (goblinsKilled >= GoblinCount)
                {
                    Console.WriteLine("Pokonałeś odpowiednią ilość goblinów.");
                }
                else
                {
                    Console.WriteLine("Pozostało {0} goblinów do zabicia", GoblinCount - goblinsKilled);
                }

                if (trollsKilled >= TrollCount)
                {
                    Console.WriteLine("Pokonałeś odpowiednią ilość trolli.");
                }
                else
                {
                    Console.WriteLine("Pozostało {0} trolli do zabicia", TrollCount - trollsKilled);
                }

                if (orcsKilled >= OrcCount)
                {
                    Console.WriteLine("Pokonałeś odpowiednią ilość orków.");
                }
                else
                {
                    Console.WriteLine("Pozostało {0} orków do zabicia", OrcCount - orcsKilled);
                }

            }
        }
    }

}
