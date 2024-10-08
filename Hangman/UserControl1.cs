﻿using System;
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
        public bool GameEnded { get; set; } = false;
        
        public UserControl1()
        {
            InitializeComponent();

            PlayerNames = new List<string>();

            LetterButtons = new List<Button>
            {
                btn_a, btn_b, btn_c, btn_d, btn_e, btn_f, btn_g, btn_h, btn_i, btn_j, btn_k, btn_l, btn_m,
                btn_n, btn_o, btn_p, btn_q, btn_r, btn_s, btn_t, btn_u, btn_v, btn_w, btn_x, btn_y, btn_z
            };

            SetLetterBtnVisible(false);

            lbl_hangman.Text = "";
            lbl_progress.Text = "";
            lbl_lettererror.Text = "";
            lbl_guesses.Text = "";
            lbl_winlose.Text = "";
            lbl_finalword.Text = "";
            lbl_currentPlayer.Text = "";

            lbl_playernames.Text = "Input player names: ";
            lbl_playernameslist.Text = "";
            lbl_nameserror.Text = "";
        }

        public void SetLetterBtnVisible(bool visible)
        {
            foreach (Button button in LetterButtons)
            {
                button.Visible = visible;
            }
        }

        public void Start()     // Call when the game is started
        {
            SetLetterBtnVisible(true);

            CurrentWord = WordBank.GetRandomWord();

            CurrentGame = new Game(CurrentWord, PlayerNames);

            lbl_guesses.Text = "No current guesses";
            lbl_hangman.Text = HangmanStates.GetState(0);
            lbl_progress.Text = CurrentGame.CurrentWord.Progress;
            lbl_currentPlayer.Text = PlayerNames[CurrentGame.CurrentPlayerIndex];
        }

        private void HandleLetterBtnClick(object sender, EventArgs e)
        {
            if (GameEnded)
                return;
            
            Button letterBtn = (Button)sender;

            bool check = CurrentGame.CurrentWord.CheckGuess(letterBtn.Text.ToLower());

            if (check)
            {
                lbl_lettererror.Text = letterBtn.Text + " has already been guessed";
                return;
            }

            CurrentGame.CurrentWord.SetGuess(letterBtn.Text.ToLower());
            CurrentGame.Start();

            lbl_guesses.Text = "Guesses: " + CurrentGame.CurrentWord.GuessesString();
            lbl_hangman.Text = HangmanStates.GetState(CurrentGame.CurrentWord.InvalidCount);
            lbl_progress.Text = CurrentGame.CurrentWord.Progress;

            if (CurrentGame.CurrentWord.CheckInvalidCount())
            {
                lbl_finalword.Text = "The word was " + CurrentGame.CurrentWord.Word;
                lbl_winlose.Text = PlayerNames[CurrentGame.CurrentPlayerIndex] + " lost!";
                GameEnded = true;
                return;
            }

            if (CurrentGame.CurrentWord.CheckProgress())
            {
                lbl_finalword.Text = "The word was " + CurrentGame.CurrentWord.Word;
                lbl_winlose.Text = PlayerNames[CurrentGame.CurrentPlayerIndex] + " won!";
                GameEnded = true;
                return;
            }

            CurrentGame.CurrentPlayerIndex = 
                CurrentGame.CurrentPlayerIndex == CurrentGame.Players.Count - 1 
                ? 0 : CurrentGame.CurrentPlayerIndex + 1;

            lbl_currentPlayer.Text = PlayerNames[CurrentGame.CurrentPlayerIndex];
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (PlayerNames.Count == 0)
            {
                lbl_nameserror.Text = "There must be at least 1 player inputted";
                return;
            }
            
            btn_start.Visible = false;
            btn_addPlayer.Visible = false;
            lbl_playernames.Visible = false;
            lbl_playernameslist.Visible = false;
            txtbx_player.Visible = false;
            Start();
        }

        private void btn_addPlayer_Click(object sender, EventArgs e)
        {
            string player =  txtbx_player.Text;

            if (player.Trim() == "")
            {
                lbl_playernameslist.Text = "Player name cannot be blank";
                txtbx_player.Text = "";
                return;
            }

            PlayerNames.Add(player);
            txtbx_player.Text = "";
            lbl_playernameslist.Text = PlayersString();
        }

        public string PlayersString()
        {
            StringBuilder playersString = new StringBuilder();

            for (int i = 0; i < PlayerNames.Count; i++)
            {
                playersString.Append(PlayerNames[i]);

                if (i != PlayerNames.Count - 1)
                {
                    playersString.Append(", ");
                }
            }

            return "All players: " + playersString.ToString();
        }
    }
}
