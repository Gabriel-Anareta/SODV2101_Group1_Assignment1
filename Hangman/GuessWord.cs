using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hangman
{
    internal class GuessWord
    {
        public string Word { get; set; }        // Holds string for current word being guessed
        public string Progress { get; set; }    // Holds string for current progress on the guessed word
        
        public GuessWord(string word)
        {
            Word = word;

            StringBuilder builder = new StringBuilder();
            builder.Append(' ', word.Length);
            Progress = builder.ToString();      // initialize Progress as an empty string with length of the current guess word
        }

        public List<int> GetIndecies(char guess)   // used to find all indecies of a given letter in the guessed word
        {
            List<int> indecies = new List<int>();
            int index = -1;

            while (true)
            {
                index = Word.IndexOf(guess, index + 1);
                if (index < 0) { break; }
                indecies.Add(index);
            }

            return indecies;
        }
    }
}
