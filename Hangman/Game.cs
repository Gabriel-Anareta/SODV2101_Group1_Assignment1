using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    internal class Game
    {
        public GuessWord CurrentWord { get; set; }      // stores the current guessing word in game sequence
        public List<string> Players { get; set; }       // stores a list of names of players
        public int CurrentPlayerIndex { get; set; }     // stores the current index of the currently guessing player
        public bool TurnInProgress { get; set; }

        public Game(string word, List<string> players)
        {
            CurrentWord = new GuessWord(word);
            Players = new List<string>(players);
            CurrentPlayerIndex = 0;
            TurnInProgress = true;
        }

        public void Start()
        {
            int lastindex = CurrentWord.Guesses.Count - 1;
            char guess = CurrentWord.Guesses[lastindex].ToLower().ToCharArray()[0];

            List<int> guessIndecies = CurrentWord.GetIndecies(guess);

            if (guessIndecies.Count > 0)
            {
                CurrentWord.UpdateProgress(guess, guessIndecies);
            }
            else
            {
                CurrentWord.UpdateInvalidCount();
            }
        }
    }
}
