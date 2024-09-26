using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class GuessWord
    {
        public string Word { get; set; }        // Holds string for current word being guessed
        
        public GuessWord(string word)
        {
            Word = word;
        }

        public List<int> GetIndecies(char guess)   // used to find all indecies of a given letter in the guessed word
        {
            return new List<int>();
        }
    }
}
