using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using BusinessLogicLayer;

namespace SemesterProject_V_0._1
{
    public partial class GetDetailsAtEndOfGameForm : MetroFramework.Forms.MetroForm
    {
        FacadeController facadeController = FacadeController.GetFacadeController();

        int minutes;
        int seconds;
        int moves;

        public GetDetailsAtEndOfGameForm(string timeTaken, string move, int minutes, int seconds, int gameType)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                 new System.Globalization.CultureInfo("ur");

            InitializeComponent();
            this.ElapsedTimeLBL.Text = timeTaken;
            this.MovesUsedLBL.Text = move;

            moves = int.Parse(move);
            this.minutes = minutes;
            this.seconds = seconds;
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CnicTB_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (facadeController.isCnicFormated(CnicTB.Text))
            {
                SubmitBTN.Enabled = true;
                errorProvider.Icon = Properties.Resources.TickMini;
                errorProvider.SetError(CnicTB, "");
            }
            else
            {
                SubmitBTN.Enabled = false;
                errorProvider.Icon = Properties.Resources.CrossMini;
                errorProvider.SetError(CnicTB, "Incorrect CNIC format.");

            }


        }

        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            facadeController.insertToDatabase(CnicTB.Text, moves, minutes, seconds, 2);
            this.Dispose();
        }
    }
}
