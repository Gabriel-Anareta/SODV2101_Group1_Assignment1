using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void Start()     // Call when the game is started
        {
            bool playAgain = true;

            while (playAgain)
            {
                /* Ask for all player names then pass the player names*/

                List<string> playerNames = new List<string>();
                string currentWord = WordBank.GetRandomWord();

                Game game = new Game(currentWord, playerNames);
                game.Start();

                 /* Ask if players want to play again */ 
            }
        }
    }
}
