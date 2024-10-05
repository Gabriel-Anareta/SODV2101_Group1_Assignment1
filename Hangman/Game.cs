﻿using System;
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
            bool gameEnded = false;

            /* Add code here to display the current state of game */

            while (!gameEnded)
            {
                string currentPlayer = Players[CurrentPlayerIndex];

                /* Add code here to tell player to pick a letter to guess */
                while ()
                {

                }

                char guess = ' '; /* Pass guessed letter to here */

                /* Add code to turn of guess button for current guessed char */

                List<int> guessIndecies = CurrentWord.GetIndecies(guess);
                
                if (guessIndecies.Count > 0)
                {
                    CurrentWord.UpdateProgress(guess, guessIndecies);
                }
                else
                {
                    CurrentWord.UpdateInvalidCount();
                }

                /* Add code here to display the current state of the guessed word
                 * current state can be found through CurrentWord.Progress */

                if (CurrentWord.CheckInvalidCount())
                {
                    gameEnded = true;
                    /* Add code here to handle losing player
                     * you can get the player name through currentPlayer */
                    break;
                }

                if (CurrentWord.CheckProgress())
                {
                    gameEnded = true;
                    /* Add code here to handle winning player
                     * you can get the player name through currentPlayer */
                    break;
                }

                CurrentPlayerIndex = CurrentPlayerIndex == Players.Count - 1 ? 0 : CurrentPlayerIndex + 1;
            }
        }
    }
}
