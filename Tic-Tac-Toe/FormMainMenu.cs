using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class FormMainMenu: Form
    {
        public static bool SinglePlayer = true;
        public static bool ForceClose = false;
        public FormMainMenu()
        { 
            InitializeComponent();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSinglePlayer_Click_1(object sender, EventArgs e)
        {
            FormMainMenu.SinglePlayer = true; //toggles singleplayer version of code
            FormGame MainGame = new FormGame();
            MainGame.RefToMainMenu = this; //sets up reference to this form so it will reopen when the main game is closed
            MainGame.Text = "Single Player Game";
            this.Visible = false;
            MainGame.Show();
        }

        private void btnMultiPlayer_Click_1(object sender, EventArgs e)
        {
            FormMainMenu.SinglePlayer = false; //toggles multiplayer version of code
            FormGame MainGame = new FormGame();
            MainGame.RefToMainMenu = this;
            this.Visible = false;
            MainGame.Show();
        }

        private void btnCredits_Click_1(object sender, EventArgs e)
        {
            FormCredits credits = new FormCredits();
            credits.RefToMainMenu = this;
            this.Visible = false;
            credits.Show();
        }

        private void FormMainMenu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (ForceClose == false)
            {
                var window = MessageBox.Show(
                    "Close the game?",
                    "Are you sure?",
                    MessageBoxButtons.YesNo);
                e.Cancel = (window == DialogResult.No);
            }
        }
    }
}
