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
using MetroFramework.Forms;
using System.Threading;

namespace SemesterProject_V_0._1
{
    public partial class MainForm : MetroForm
    {
        string difficulty = "Hard";

        private bool urduLanguageSelected = true;

        public MainForm()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture
                    = new System.Globalization.CultureInfo("ur");
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            if (urduLanguageSelected)
            {
                if (MetroMessageBox.Show(this, @"کیا آپ واقعی رخصت ہونا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            else
            {
                if (MetroMessageBox.Show(this, "Do you really want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
        }

        private void ShowAgain(object sender, EventArgs e)
        {
            this.Show();
        }

        private void TwoByTwoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            TwoByTwoGameForm twoByTwoGame = new TwoByTwoGameForm(difficulty);
            this.Hide();
            twoByTwoGame.Show();
            twoByTwoGame.Disposed += new System.EventHandler(ShowAgain);
        }

        private void ChangeLangageBTN_Click(object sender, EventArgs e)
        {
            if (urduLanguageSelected)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture
                    = new System.Globalization.CultureInfo("en-US");
                this.RightToLeft = RightToLeft.No;
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture
                    = new System.Globalization.CultureInfo("ur");
                this.RightToLeft = RightToLeft.Yes;
            }

            this.Controls.Clear();
            InitializeComponent();

            urduLanguageSelected = !(urduLanguageSelected);
        }

        private void ThreeByThreePanel_MouseClick(object sender, MouseEventArgs e)
        {
            ThreeByThreeGameForm threeByThreeGame = new ThreeByThreeGameForm(difficulty);
            this.Hide();
            threeByThreeGame.Show();
            threeByThreeGame.Disposed += new System.EventHandler(ShowAgain);
        }

        private void ViewRankingsBTN_Click(object sender, EventArgs e)
        {
            StatsForm statsForm = new StatsForm();
            statsForm.Disposed += new System.EventHandler(ShowAgain);
            this.Hide();
            statsForm.Show();
        }

        private void EasyRB_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Checked)
            {
                difficulty = "Easy";
            }
        }

        private void Medium_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                difficulty = "Medium";
            }
        }

        private void Hard_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                difficulty = "Hard";
            }
        }
    }
}
