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


        }

        public void Start()     // Call when the game is started
        {
            bool playAgain = true;

            while (playAgain)
            {
                /* Ask for all player names then pass the player names*/

                PlayerNames = new List<string>();
                CurrentWord = WordBank.GetRandomWord();

                CurrentGame = new Game(CurrentWord, PlayerNames);
                CurrentGame.Start();

                /* Ask if players want to play again */ 
            }
        }

        private void HandleLetterBtnClick(object sender, EventArgs e)
        {
            Button letterBtn = (Button)sender;

            bool check = CurrentGame.CurrentWord.CheckGuess(letterBtn.Text);

            if (check)
            {
                /* Display err message for already checked symbol*/
            }
            else
            {
                CurrentGame.CurrentWord.SetGuess(letterBtn.Text);
                CurrentGame.TurnInProgress = false;
            }
        }
    }
}
