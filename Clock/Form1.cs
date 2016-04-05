using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {

        private bool turn = true;
        private int turn_count = 0;
        
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

       
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Max","Tic-Tac-Toe");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            checkForWinnwe();
        }

        private void checkForWinnwe()
        {
            bool thereIsWinner = false;
            turn_count++;
            //Horizontal check
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled)
                thereIsWinner = true;
            else if(B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled)
                thereIsWinner = true;
            else if(C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled)
                thereIsWinner = true;

            //Vertical check
            if (A1.Text == B1.Text && B1.Text == A1.Text && !C1.Enabled)
                thereIsWinner = true;
            else if (A2.Text == B2.Text && B2.Text == A2.Text && !C2.Enabled)
                thereIsWinner = true;
            else if (A3.Text == B3.Text && B3.Text == A3.Text && !C3.Enabled)
                thereIsWinner = true;

            //Diagonal check
            if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled)
                thereIsWinner = true;
            else if (B3.Text == B2.Text && B2.Text == C1.Text && !C1.Enabled)
                thereIsWinner = true;
            
            if (thereIsWinner)
            {
                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + "  Winns !!!");
                disableAllButtons();
            }else if(turn_count == 9)
            {
                MessageBox.Show("Draw","Bumer !!!");
            } 
        }

        private void disableAllButtons()
        {
            try{
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    c.Enabled = false;
                }
            }
            catch
            {

            };
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach(Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch
            {

            }
        }
    }
}
