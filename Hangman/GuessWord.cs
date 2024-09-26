using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class GuessWord
    {
        public string Word { get; set; }    // Holds string for current word being guessed
        
        public GuessWord(string word)
        {
            Word = word;
        }
    }
}
