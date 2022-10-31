using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerSim
{
    public static class ConsoleUtility
    {
        const char _block = '■';
        const string _twirl = "-\\|/";
        public static void WriteProgressBar(int percent, bool update = false)
        {
            Console.CursorVisible = false;
            if (update)
                Console.SetCursorPosition(0, 0);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
            Console.CursorVisible = true;
        }
        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
                Console.SetCursorPosition(0,0);
            Console.Write(_twirl[progress % _twirl.Length]);
        }
    }
}
