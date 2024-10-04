using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Game
    {
        public GuessWord CurrentWord { get; set; }
        public List<string> Players { get; set; }
        public int currentPlayerIndex { get; set; }


    }
}
