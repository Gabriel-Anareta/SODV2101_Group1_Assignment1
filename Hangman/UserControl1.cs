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
        internal Game CurrentGame { get; set; }
        public string CurrentWord { get; set; }
        public List<string> PlayerNames { get; set; }
        public List<Button> LetterButtons { get; set; }
        
        public UserControl1()
        {
            InitializeComponent();
            LetterButtons = new List<Button>
            {
                btn_a, btn_b, btn_c, btn_d, btn_e, btn_f, btn_g, btn_h, btn_i, btn_j, btn_k, btn_l, btn_m,
                btn_n, btn_o, btn_p, btn_q, btn_r, btn_s, btn_t, btn_u, btn_v, btn_w, btn_x, btn_y, btn_z
            };
            foreach(Button button in LetterButtons)
            {
                button.Visible = false;
            }
            lbl_hangman.Text = "";
            lbl_progress.Text = "";
            lbl_error.Text = "";
            lbl_guesses.Text = "";
            lbl_debug.Text = "";
        }

        public void Start()     // Call when the game is started
        {
            foreach (Button button in LetterButtons)
            {
                button.Visible = true;
            }

            PlayerNames = new List<string> { "john", "mary", "joey" };
            CurrentWord = WordBank.GetRandomWord();

            CurrentGame = new Game(CurrentWord, PlayerNames);

            lbl_debug.Text = CurrentWord;
            lbl_hangman.Text = HangmanStates.GetState(0);
            lbl_progress.Text = CurrentGame.CurrentWord.Progress;
        }

        private void HandleLetterBtnClick(object sender, EventArgs e)
        {
            Button letterBtn = (Button)sender;

            bool check = CurrentGame.CurrentWord.CheckGuess(letterBtn.Text);

            if (check)
            {
                lbl_error.Text = letterBtn.Text + " has already been guessed";
                return;
            }

            CurrentGame.CurrentWord.SetGuess(letterBtn.Text);
            CurrentGame.Start();

            lbl_hangman.Text = HangmanStates.GetState(CurrentGame.CurrentWord.InvalidCount);
            lbl_progress.Text = CurrentGame.CurrentWord.Progress;

            if (CurrentGame.CurrentWord.CheckInvalidCount())
            {
                /* Add code here to handle losing player
                 * you can get the player name through currentPlayer */
            }

            if (CurrentGame.CurrentWord.CheckProgress())
            {
                /* Add code here to handle winning player
                 * you can get the player name through currentPlayer */
            }

            /* Add code here to display the current state of the guessed word
             * current state can be found through CurrentWord.Progress */

            CurrentGame.CurrentPlayerIndex = 
                CurrentGame.CurrentPlayerIndex == CurrentGame.Players.Count - 1 
                ? 0 : CurrentGame.CurrentPlayerIndex + 1;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Visible = false;
            Start();
        }
    }
}
