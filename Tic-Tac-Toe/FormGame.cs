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
        public int UL=0, UM=0, UR=0, ML=0, MM=0, MR=0, LL=0, LM=0, LR=0;
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
                if (randomNumber == 0 && UL == 0) //if it chooses this number and the Upper Left slot is open
                {
                    UL = 2;
                    pbxULO.Visible = true;
                    btnUL.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 1 && UM == 0)
                {
                    UM = 2;
                    pbxUMO.Visible = true;
                    btnUM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 2 && UR == 0)
                {
                    UR = 2;
                    pbxURO.Visible = true;
                    btnUR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 3 && ML == 0)
                {
                    ML = 2;
                    pbxMLO.Visible = true;
                    btnML.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 4 && MM == 0)
                {
                    MM = 2;
                    pbxMMO.Visible = true;
                    btnMM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 5 && MR == 0)
                {
                    MR = 2;
                    pbxMRO.Visible = true;
                    btnMR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 6 && LL == 0)
                {
                    LL = 2;
                    pbxLLO.Visible = true;
                    btnLL.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 7 && LM == 0)
                {
                    LM = 2;
                    pbxLMO.Visible = true;
                    btnLM.Visible = false;
                    ComputerChoice = 1;
                }
                else if (randomNumber == 8 && LR == 0)
                {
                    LR = 2;
                    pbxLRO.Visible = true;
                    btnLR.Visible = false;
                    ComputerChoice = 1;
                }
                else if (UL!=0 && UM!= 0 && UR!= 0 && ML!=0 && MM!=0 && MR!=0 && LL!=0 && LM!=0 && LR!=0) //if all slots are full
                {
                    ComputerChoice = 1;
                    lblMainGameTitle.Text = ("DRAW!");
                }
                CheckIfWon();
            }
        }
        public void CheckIfWon()
        {
            if ((UL == 1 && UR == 1 && UM == 1) || //checks for if Player 1 has a match on any rows
                (ML == 1 && MM == 1 && MR == 1) ||
                (LL == 1 && LM == 1 && LR == 1) ||

                (UL == 1 && ML == 1 && LL == 1) ||
                (UM == 1 && MM == 1 && LM == 1) ||
                (UR == 1 && MR == 1 && LR == 1) ||

                (UL == 1 && MM == 1 && LR == 1) ||
                (UR == 1 && MM == 1 && LL == 1))
            {
                if (FormMainMenu.SinglePlayer == false) lblMainGameTitle.Text = ("Player 2 Wins!");
                if (FormMainMenu.SinglePlayer == true) lblMainGameTitle.Text = ("You Win!");
                ComputerChoice = 1;
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
            else if ((UL == 2 && UR == 2 && UM == 2) || //checks for if Player 2 (or computer) has a match in any rows
                (ML == 2 && MM == 2 && MR == 2) ||
                (LL == 2 && LM == 2 && LR == 2) ||

                (UL == 2 && ML == 2 && LL == 2) ||
                (UM == 2 && MM == 2 && LM == 2) ||
                (UR == 2 && MR == 2 && LR == 2) ||

                (UL == 2 && MM == 2 && LR == 2) ||
                (UR == 2 && MM == 2 && LL == 2))
            {
                if (FormMainMenu.SinglePlayer == false) lblMainGameTitle.Text = ("Player 1 Wins!");
                if (FormMainMenu.SinglePlayer == true) lblMainGameTitle.Text = ("The Computer Wins!");
                ComputerChoice = 1;
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
                UL = 1;
                pbxULX.Visible = true;
                btnUL.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                UL = 2;
                pbxULX.Visible = true;
                btnUL.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                UL = 1;
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
                UM = 1;
                pbxUMX.Visible = true;
                btnUM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                UM = 2;
                pbxUMX.Visible = true;
                btnUM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                UM = 1;
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
                UR = 1;
                pbxURX.Visible = true;
                btnUR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                UR = 2;
                pbxURX.Visible = true;
                btnUR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                UR = 1;
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
                ML = 1;
                pbxMLX.Visible = true;
                btnML.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                ML = 2;
                pbxMLX.Visible = true;
                btnML.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                ML = 1;
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
                MM = 1;
                pbxMMX.Visible = true;
                btnMM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                MM = 2;
                pbxMMX.Visible = true;
                btnMM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                MM = 1;
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
                MR = 1;
                pbxMRX.Visible = true;
                btnMR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                MR = 2;
                pbxMRX.Visible = true;
                btnMR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                MR = 1;
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
                LL = 1;
                pbxLLX.Visible = true;
                btnLL.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                LL = 2;
                pbxLLX.Visible = true;
                btnLL.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                LL = 1;
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
                LM = 1;
                pbxLMX.Visible = true;
                btnLM.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                LM = 2;
                pbxLMX.Visible = true;
                btnLM.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                LM = 1;
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
                LR = 1;
                pbxLRX.Visible = true;
                btnLR.Visible = false;
                ComputerChoice = 0;
                ComputerTurn();
            }
            else if (PlayerTurn == 1)
            {
                LR = 2;
                pbxLRX.Visible = true;
                btnLR.Visible = false;
                PlayerTurn = 2;
            }
            else
            {
                LR = 1;
                pbxLRO.Visible = true;
                btnLR.Visible = false;
                PlayerTurn = 1;
            }
            CheckIfWon();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {//Resets all variables, labels, buttons//
            UL = 0;
            UM = 0;
            UR = 0;
            ML = 0;
            MM = 0;
            MR = 0;
            LL = 0;
            LM = 0;
            LR = 0;

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
