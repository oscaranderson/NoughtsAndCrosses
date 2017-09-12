using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class User
    {
        public string UserInputTile()
        {
            Console.Write("Which tile do you want to change \n1 2 3\n4 5 6\n7 8 9\n\n>>> ");
            string tile = Console.ReadLine();
            return tile;
        }
        public char UserInputValue()
        {
            Console.Write("What do you want to change the selected tile to\n\n>>> ");
            char value = Console.ReadLine().Single();
            return value;
        }
    }
}
