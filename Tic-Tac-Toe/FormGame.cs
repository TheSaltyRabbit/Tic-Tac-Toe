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
    public partial class FormGame : Form
    {
        public Form RefToMainMenu { get; set; }
        public bool ToMainMenu = false;
        public int ComputerChoice;
        public int[,] Spaces = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        //first array is uppper, second is middle, third is lower
        //in array, first number is left, second is middle, third is right
        public int PlayerTurn = 0;
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            //determine which code to use
            if (FormMainMenu.SinglePlayer == true)
            {
                lblMainGameTitle.Text = ("Your Turn");
                PlayerTurn = 0; //indicates singleplayer
            }
            if (FormMainMenu.SinglePlayer == false) 
            {
                lblMainGameTitle.Text = ("Player 1's Turn");
                PlayerTurn = 1; //indicates which player's turn
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            var window = MessageBox.Show(
                "Return to the Main Menu?",
                "Are you sure?",
                MessageBoxButtons.YesNo);
            if (window == DialogResult.Yes)
            {
                ToMainMenu = true;
                FormMainMenu.SinglePlayer = true;
                this.RefToMainMenu.Show();
                this.Close();
            }
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ToMainMenu == false)
            {
                var window = MessageBox.Show(
                    "Close the game?",
                    "Are you sure?",
                    MessageBoxButtons.YesNo);
                if (window == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    FormMainMenu.SinglePlayer = true;
                    FormMainMenu.ForceClose = true;
                    this.RefToMainMenu.Close();
                }
                ToMainMenu = false;
            }
        }

        public void ComputerTurn()
        {
            Random random = new Random(); //computer randomly picks a space
            while (ComputerChoice == 0)
            {
                int randomNumber = random.Next(0, 9);
                if (randomNumber == 0 && Spaces[0,0] == 0) //if it chooses this number and the Upper Left slot is open
                {
                    Spaces[0,0] = 2;
                    pbxULO.Visible = true;
                    btnUL.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 1 && Spaces[0,1] == 0)
                {
                    Spaces[0,1] = 2;
                    pbxUMO.Visible = true;
                    btnUM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 2 && Spaces[0,2] == 0)
                {
                    Spaces[0,2] = 2;
                    pbxURO.Visible = true;
                    btnUR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 3 && Spaces[1,0] == 0)
                {
                    Spaces[1,0] = 2;
                    pbxMLO.Visible = true;
                    btnML.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 4 && Spaces[1,1] == 0)
                {
                    Spaces[1,1] = 2;
                    pbxMMO.Visible = true;
                    btnMM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 5 && Spaces[1,2] == 0)
                {
                    Spaces[1,2] = 2;
                    pbxMRO.Visible = true;
                    btnMR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 6 && Spaces[2,0] == 0)
                {
                    Spaces[2,0] = 2;
                    pbxLLO.Visible = true;
                    btnLL.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 7 && Spaces[2,1] == 0)
                {
                    Spaces[2,1] = 2;
                    pbxLMO.Visible = true;
                    btnLM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 8 && Spaces[2,2] == 0)
                {
                    Spaces[2,2] = 2;
                    pbxLRO.Visible = true;
                    btnLR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (Spaces[0,0]!=0 && Spaces[0,1]!= 0 && Spaces[0,2]!= 0 && Spaces[1,0]!=0 && Spaces[1,1]!=0 && Spaces[1,2]!=0 && Spaces[2,0]!=0 && Spaces[2,1]!=0 && Spaces[2,2]!=0) //if all slots are full
                {
                    ComputerChoice = 1;
                    lblMainGameTitle.Text = ("DRAW!");
                }
                CheckIfWon();
            }
        }
        public void CheckIfWon()
        {
            if ((Spaces[0,0] == 1 && Spaces[0,2] == 1 && Spaces[0,1] == 1) || //checks for if Player 1 has a match on any rows
                (Spaces[1,0] == 1 && Spaces[1,1] == 1 && Spaces[1,2] == 1) ||
                (Spaces[2,0] == 1 && Spaces[2,1] == 1 && Spaces[2,2] == 1) ||

                (Spaces[0,0] == 1 && Spaces[1,0] == 1 && Spaces[2,0] == 1) ||
                (Spaces[0,1] == 1 && Spaces[1,1] == 1 && Spaces[2,1] == 1) ||
                (Spaces[0,2] == 1 && Spaces[1,2] == 1 && Spaces[2,2] == 1) ||

                (Spaces[0,0] == 1 && Spaces[1,1] == 1 && Spaces[2,2] == 1) ||
                (Spaces[0,2] == 1 && Spaces[1,1] == 1 && Spaces[2,0] == 1))
            {
                if (FormMainMenu.SinglePlayer == false) lblMainGameTitle.Text = ("Player 2 Wins!");
                if (FormMainMenu.SinglePlayer == true) lblMainGameTitle.Text = ("You Win!");
                ComputerChoice = 1;
                DisableButtons();
            }
            else if ((Spaces[0,0] == 2 && Spaces[0,2] == 2 && Spaces[0,1] == 2) || //checks for if Player 2 (or computer) has a match in any rows
                (Spaces[1,0] == 2 && Spaces[1,1] == 2 && Spaces[1,2] == 2) ||
                (Spaces[2,0] == 2 && Spaces[2,1] == 2 && Spaces[2,2] == 2) ||

                (Spaces[0,0] == 2 && Spaces[1,0] == 2 && Spaces[2,0] == 2) ||
                (Spaces[0,1] == 2 && Spaces[1,1] == 2 && Spaces[2,1] == 2) ||
                (Spaces[0,2] == 2 && Spaces[1,2] == 2 && Spaces[2,2] == 2) ||

                (Spaces[0,0] == 2 && Spaces[1,1] == 2 && Spaces[2,2] == 2) ||
                (Spaces[0,2] == 2 && Spaces[1,1] == 2 && Spaces[2,0] == 2))
            {
                if (FormMainMenu.SinglePlayer == false) lblMainGameTitle.Text = ("Player 1 Wins!");
                if (FormMainMenu.SinglePlayer == true) lblMainGameTitle.Text = ("The Computer Wins!");
                ComputerChoice = 1;
                DisableButtons();
            }
        }

        public void DisableButtons()
        {
            btnUL.Visible = false;
            btnUM.Visible = false;
            btnUR.Visible = false;
            btnML.Visible = false;
            btnMM.Visible = false;
            btnMR.Visible = false;
            btnLL.Visible = false;
            btnLM.Visible = false;
            btnLR.Visible = false;
        }
        /*All buttons are abbreviated.
         * U* = Upper
         * M* = Middle
         * L* = Lower
         * *L = Left
         * *M = Middle
         * *R = Right*/
        private void btnUL_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[0,0] = 1;
                pbxULX.Visible = true;
                btnUL.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[0,0] = 2;
                pbxULX.Visible = true;
                btnUL.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[0,0] = 1;
                pbxULO.Visible = true;
                btnUL.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnUM_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[0,1] = 1;
                pbxUMX.Visible = true;
                btnUM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[0,1] = 2;
                pbxUMX.Visible = true;
                btnUM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[0,1] = 1;
                pbxUMO.Visible = true;
                btnUM.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnUR_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[0,2] = 1;
                pbxURX.Visible = true;
                btnUR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[0,2] = 2;
                pbxURX.Visible = true;
                btnUR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[0,2] = 1;
                pbxURO.Visible = true;
                btnUR.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnML_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[1,0] = 1;
                pbxMLX.Visible = true;
                btnML.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[1,0] = 2;
                pbxMLX.Visible = true;
                btnML.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[1,0] = 1;
                pbxMLO.Visible = true;
                btnML.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[1,1] = 1;
                pbxMMX.Visible = true;
                btnMM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[1,1] = 2;
                pbxMMX.Visible = true;
                btnMM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[1,1] = 1;
                pbxMMO.Visible = true;
                btnMM.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[1,2] = 1;
                pbxMRX.Visible = true;
                btnMR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[1,2] = 2;
                pbxMRX.Visible = true;
                btnMR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[1,2] = 1;
                pbxMRO.Visible = true;
                btnMR.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnLL_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[2,0] = 1;
                pbxLLX.Visible = true;
                btnLL.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[2,0] = 2;
                pbxLLX.Visible = true;
                btnLL.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[2,0] = 1;
                pbxLLO.Visible = true;
                btnLL.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[2,1] = 1;
                pbxLMX.Visible = true;
                btnLM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[2,1] = 2;
                pbxLMX.Visible = true;
                btnLM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[2,1] = 1;
                pbxLMO.Visible = true;
                btnLM.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnLR_Click(object sender, EventArgs e)
        {
            if (PlayerTurn == 0)
            {
                Spaces[2,2] = 1;
                pbxLRX.Visible = true;
                btnLR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                Spaces[2,2] = 2;
                pbxLRX.Visible = true;
                btnLR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                Spaces[2,2] = 1;
                pbxLRO.Visible = true;
                btnLR.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {//Resets all variables, labels, buttons//
            for (int i=0;i<3;i++)
                for (int j=0;j<3;j++)
                {
                    Spaces[i, j] = 0;
                }

            if (FormMainMenu.SinglePlayer == true)
            {
                PlayerTurn = 0;
                lblMainGameTitle.Text = ("Your Turn!");
            }
            else
            {
                PlayerTurn = 1;
                lblMainGameTitle.Text = ("Player 1's Turn!");
            }

            pbxULO.Visible = false;
            pbxULX.Visible = false;
            btnUL.Visible = true;

            pbxUMO.Visible = false;
            pbxUMX.Visible = false;
            btnUM.Visible = true;

            pbxURO.Visible = false;
            pbxURX.Visible = false;
            btnUR.Visible = true;

            pbxMLO.Visible = false;
            pbxMLX.Visible = false;
            btnML.Visible = true;

            pbxMMO.Visible = false;
            pbxMMX.Visible = false;
            btnMM.Visible = true;

            pbxMRO.Visible = false;
            pbxMRX.Visible = false;
            btnMR.Visible = true;

            pbxLLO.Visible = false;
            pbxLLX.Visible = false;
            btnLL.Visible = true;

            pbxLMO.Visible = false;
            pbxLMX.Visible = false;
            btnLM.Visible = true;

            pbxLRO.Visible = false;
            pbxLRX.Visible = false;
            btnLR.Visible = true;
        }
    }
}
