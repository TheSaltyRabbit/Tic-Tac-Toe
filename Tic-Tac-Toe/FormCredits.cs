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
    public partial class FormCredits : Form
    {
        public Form RefToMainMenu { get; set;}
        public FormCredits()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        { 
            Close();
        }

        private void FormCredits_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefToMainMenu.Show();
        }
    }
}
