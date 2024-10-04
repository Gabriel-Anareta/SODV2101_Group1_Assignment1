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
        private const int MAX_GUESS = 7;        // Holds count for maximum guesses - can be adjusted later if needed

        private string Word { get; set; }        // Holds string for current word being guessed
        private string Progress { get; set; }    // Holds string for current progress on the guessed word
        public int InvalidCount { get; private set; }   // Holds count of incorrect guesses on Word
        public List<char> Guesses { get; private set; } // Holds record of all guessed letters
        
        public GuessWord(string word)
        {
            Word = word;
            Progress = CreateProgress(word);      
            InvalidCount = 0;
        }

        private string CreateProgress(string word)      // used to clean up constructor code
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == '-')
                {
                    builder.Append('-');
                    continue;
                }

                if (word[i] == '.')
                {
                    builder.Append('.');
                    continue;
                }

                if (word[i] == ' ')
                {
                    builder.Append(' ');
                    continue;
                }

                builder.Append('_');
            }

            return builder.ToString();
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

        public void UpdateProgress(char guess, List<int> indecies)      // used to update Progress when a letter is guessed
        {
            Char[] progressArr = Progress.ToCharArray();

            foreach (int index in indecies)
            {
                progressArr[index] = guess;
            }

            Progress = progressArr.ToString();
        }

        public bool CheckProgress()     // returns true if Progress has been updated enough to match the word being guessed
        {                               // intended to be called right after UpdateProgress method for checking/updating game state
            if (Progress == Word)
            {
                return true;
            }

            return false;
        }

        public void UpdateInvalidCount()    // used to update InvalidCount when a letter is incorrectly guessed
        {                                   // intended to be called after checking if the guessed letter does not exist in current word
            InvalidCount++;
        }

        public bool CheckInvalidCount()     // returns true if the maximum amount of incorrect guesses were reached
        {                                   // intended to be called when checking for ending game states
            if (InvalidCount == MAX_GUESS)
            {
                return true;
            }

            return false;
        }

        public void SetGuess(char guess)
        {
            Guesses.Add(guess);
        }

        public bool CheckGuess(char guess)
        {
            
        }
    }
}
