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
using System.Collections;
using System.Diagnostics;

namespace SemesterProject_V_0._1
{
    public partial class TwoByTwoGameForm : MetroFramework.Forms.MetroForm
    {
        byte timeInMinutesToComplete = 0;

        // Timer
        byte seconds = 60;
        byte timeAllowedToSolveInMinutes = 0;

        // Original back color of button
        Color originalBackColorOfBtn = Color.FromArgb(50, 220, 50);

        // Get latest button that was clicked
        Button lastSelectedButton = null;

        List<Button> gridRow0 = new List<Button>(4);
        List<Button> gridRow1 = new List<Button>(4);
        List<Button> gridRow2 = new List<Button>(4);
        List<Button> gridRow3 = new List<Button>(4);
        List<Button> gridCol0 = new List<Button>(4);
        List<Button> gridCol1 = new List<Button>(4);
        List<Button> gridCol2 = new List<Button>(4);
        List<Button> gridCol3 = new List<Button>(4);

        // bool urduLanguageSelected = false;

        // Local shallow copy of facade controller
        FacadeController facadeController = FacadeController.GetFacadeController();

        // Make a list of 4 strings for customizability
        List<string> valuesUsedInSudoku = new List<string>(4);

        // Total number of moves carried out
        int noOfMoves = 0;

        bool[] erroniuosRows;
        bool[] erroniuosColumns;

        byte[,] grid;

        public TwoByTwoGameForm(string difficultyLevel ="Hard")
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ur");

            InitializeComponent();

            // Registering MakeMove event on each button in panel
            foreach (Control control in this.TwoByTwoGamePanel.Controls)
            {
                if (control is Panel)
                {
                    foreach(Control innerControls in control.Controls)
                    {
                        if(innerControls is Button)
                        {
                            innerControls.Click += new EventHandler(MadeMove);
                        }
                    }
                }
            }

            // Registering getValueToPlaceFromUser on option buttons
            foreach(Control button in this.AvailableOptionsPanel.Controls)
            {
                button.Click += new EventHandler(getValueToPlaceFromUser);
            }

            valuesUsedInSudoku = facadeController.getDefaultRandomValueToStartGame("Two");

            // Place the values in keys
            Option0.Text = FirstKeysValueLBL.Text = valuesUsedInSudoku[0];
            Option1.Text = SecondKeysValueLBL.Text = valuesUsedInSudoku[1];
            Option2.Text = ThirdKeysValueLBL.Text = valuesUsedInSudoku[2];
            Option3.Text = FourthKeysValueLBL.Text = valuesUsedInSudoku[3];

            initializeGridRowAndColumns();


            // Filling grid at initial level
            switch (difficultyLevel)
            {
                case "Easy":
                    fillInitialGameValues(20);
                    timeAllowedToSolveInMinutes = 10;
                    break;
                case "Medium":
                    fillInitialGameValues(8);
                    timeAllowedToSolveInMinutes = 7;
                    break;
                case "Hard":
                    fillInitialGameValues(4);
                    timeAllowedToSolveInMinutes = 5;
                    break;
            }
            timeInMinutesToComplete = timeAllowedToSolveInMinutes;

            // Setting inital time on timer
            MinutesLBL.Text = facadeController.convertNumberToUrdu(timeAllowedToSolveInMinutes - 1);
        }

        private void initializeGridRowAndColumns()
        {
            gridRow0.Add(Button00);
            gridRow0.Add(Button01);
            gridRow0.Add(Button02);
            gridRow0.Add(Button03);

            gridRow1.Add(Button10);
            gridRow1.Add(Button11);
            gridRow1.Add(Button12);
            gridRow1.Add(Button13);

            gridRow2.Add(Button20);
            gridRow2.Add(Button21);
            gridRow2.Add(Button22);
            gridRow2.Add(Button23);

            gridRow3.Add(Button30);
            gridRow3.Add(Button31);
            gridRow3.Add(Button32);
            gridRow3.Add(Button33);

            gridCol0.Add(Button00);
            gridCol0.Add(Button10);
            gridCol0.Add(Button20);
            gridCol0.Add(Button30);

            gridCol1.Add(Button01);
            gridCol1.Add(Button11);
            gridCol1.Add(Button21);
            gridCol1.Add(Button31);

            gridCol2.Add(Button02);
            gridCol2.Add(Button12);
            gridCol2.Add(Button22);
            gridCol2.Add(Button32);

            gridCol3.Add(Button03);
            gridCol3.Add(Button13);
            gridCol3.Add(Button23);
            gridCol3.Add(Button33);

            grid = new byte[4, 4]
            {
                { 255, 255, 255, 255 },
                { 255, 255, 255, 255 },
                { 255, 255, 255, 255 },
                { 255, 255, 255, 255 }
            };

            erroniuosRows = new bool[] { false, false, false, false };
            erroniuosColumns = new bool[] { false, false, false, false };
        }

        void changeRowBackColorToRed(List<Button> rowToChange)
        {
            foreach (Button button in rowToChange)
            {
                button.BackColor = Color.Red;
            }
        }

        void changeColumnBackColorToRed(List<Button> columnToChange)
        {
            // Calling the same row function because the functionality 
            // would be same. Only argument passed will be different
            changeRowBackColorToRed(columnToChange);
        }

        void changeRowBackColorToNormal(List<Button> rowToChange)
        {
            foreach (Button button in rowToChange)
            {
                button.BackColor = originalBackColorOfBtn;
            }
        }

        void changeColumnBackColorToNormal(List<Button> columnToChange)
        {
            foreach (Button button in columnToChange)
            {
                button.BackColor = originalBackColorOfBtn;
            }
        }

        private void changeRowBackColor(string row, bool toRed)
        {
            if (toRed)
            {
                switch (row)
                {
                    case "0":
                        changeRowBackColorToRed(gridRow0);
                        break;
                    case "1":
                        changeRowBackColorToRed(gridRow1);
                        break;
                    case "2":
                        changeRowBackColorToRed(gridRow2);
                        break;
                    case "3":
                        changeRowBackColorToRed(gridRow3);
                        break;
                }
            }
            else
            {
                switch (row)
                {
                    case "0":
                        changeRowBackColorToNormal(gridRow0);
                        break;
                    case "1":
                        changeRowBackColorToNormal(gridRow1);
                        break;
                    case "2":
                        changeRowBackColorToNormal(gridRow2);
                        break;
                    case "3":
                        changeRowBackColorToNormal(gridRow3);
                        break;
                }
            }
        }

        private void changeColumnBackColor(string col, bool toRed)
        {
            if (toRed)
            {
                switch (col)
                {
                    case "0":
                        changeColumnBackColorToRed(gridCol0);
                        break;
                    case "1":
                        changeColumnBackColorToRed(gridCol1);
                        break;
                    case "2":
                        changeColumnBackColorToRed(gridCol2);
                        break;
                    case "3":
                        changeColumnBackColorToRed(gridCol3);
                        break;
                }
            }
            else
            {
                switch (col)
                {
                    case "0":
                        changeColumnBackColorToNormal(gridCol0);
                        break;
                    case "1":
                        changeColumnBackColorToNormal(gridCol1);
                        break;
                    case "2":
                        changeColumnBackColorToNormal(gridCol2);
                        break;
                    case "3":
                        changeColumnBackColorToNormal(gridCol3);
                        break;
                }
            }
        }

        private void MadeMove(object sender, EventArgs e)
        {
            AvailableOptionsPanel.Enabled = true;
            lastSelectedButton = sender as Button;
            this.AvailableOptionsPanel.Visible = true;
        }

        private void BackBTN_MouseClick(object sender, MouseEventArgs e)
        {
            if (noOfMoves > 0)
                this.MovesCarriedOutLBL.Text = (--noOfMoves).ToString();
            else
                MetroMessageBox.Show(this, "No moves left");
        }

        private void ForwardBTN_MouseClick(object sender, MouseEventArgs e)
        {
            this.MovesCarriedOutLBL.Text = (++noOfMoves).ToString();
        }

        private void ChangeLangageBTN_Click(object sender, EventArgs e)
        {
            // Swapping the location of moves carried out Button

            //Point temp = new Point(MovesLBL.Location.X, MovesLBL.Location.Y);
            //MovesLBL.Location = MovesCarriedOutLBL.Location;
            //MovesCarriedOutLBL.Location = temp;

            //if (urduLanguageSelected)
            //{
            //    this.RightToLeft = RightToLeft.No;
            //    this.RightToLeftLayout = false;
            //}
            //else
            //{
            //    this.RightToLeft = RightToLeft.Yes;
            //    this.RightToLeftLayout = true;
            //}
        }

        private void TwoByTwoGameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());

            //if (AvailableOptionsPanel.Visible)
            //{
            //if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D4)
            //{
            //    // Names are in the format "ButtonRC" where R represents row and C represents column
            //    int row = int.Parse(lastSelectedButton.Name.Substring(6, 1));
            //    int column = int.Parse(lastSelectedButton.Name.Substring(7, 1));

            //    // Get the index of Selected Option and store it in 
            //    byte valueToPlace = Convert.ToByte(valuesUsedInSudoku.IndexOf((sender as Button).Text));

            //    grid[row, column] = valueToPlace;

            //    this.AvailableOptionsPanel.Visible = false;
            //    lastSelectedButton.Text = getValueOfKeyPressedBasedInIndex(e.KeyCode);
            //    this.MovesCarriedOutLBL.Text = (facadeController.convertNumberToUrdu(++noOfMoves));
            //}
            //}
        }

        private Button getButton(string name)
        {
            foreach (Control control in this.TwoByTwoGamePanel.Controls)
            {
                if (control is Panel)
                {
                    foreach (Control innerControl in control.Controls)
                    {
                        if (innerControl is Button)
                        {
                            if(innerControl.Name == name)
                            {
                                return (innerControl as Button);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void fillInitialGameValues(int numberOfFilledButtons)
        {
            List<int> rows = facadeController.generateRandomList(numberOfFilledButtons, "Two");
            List<int> columns = facadeController.generateRandomListTwo(numberOfFilledButtons, "Two");

            byte valueToPlace = 0;

            for (int i = 0; i < numberOfFilledButtons; i++)
            {
                if(i == 0)
                {
                    grid[rows[i], columns[i]] = valueToPlace;

                    string firstButtonToDisable = "Button" + rows[i].ToString() + columns[i].ToString();

                    Button ButtonFirstButtonToDisable = getButton(firstButtonToDisable);

                    //ButtonFirstButtonToDisable.Enabled = false;
                    ButtonFirstButtonToDisable.Text = valuesUsedInSudoku[valueToPlace];

                    continue;
                }

                while(facadeController.foundValueInRow(grid, rows[i], columns[i], valueToPlace, "Two") 
                    ||
                    facadeController.foundValueInColumn(grid, columns[i], rows[i], valueToPlace, "Two"))
                {
                    valueToPlace++;
                }

                if (valueToPlace > 3)
                {
                    //throw new Exception(valueToPlace.ToString());
                    continue;
                }

                grid[rows[i], columns[i]] = valueToPlace;
                string btnToDisable = "Button" + rows[i].ToString() + columns[i].ToString();

                Button buttonToDisable = getButton(btnToDisable);

                //buttonToDisable.Enabled = false;
                buttonToDisable.Text = valuesUsedInSudoku[valueToPlace];
            }
        }

        private void getValueToPlaceFromUser(object sender, EventArgs e)
        {
            // Names are in the format "ButtonRC" where R represents row and C represents column
            int row = int.Parse(lastSelectedButton.Name.Substring(6, 1));
            int column = int.Parse(lastSelectedButton.Name.Substring(7, 1));

            // Get the index of Selected Option and store it in 
            byte valueToPlace = Convert.ToByte(valuesUsedInSudoku.IndexOf((sender as Button).Text));

            grid[row, column] = valueToPlace;

            this.AvailableOptionsPanel.Visible = false;
            lastSelectedButton.Text = (sender as Button).Text;
            this.MovesCarriedOutLBL.Text = (facadeController.convertNumberToUrdu(++noOfMoves));

            if (facadeController.foundValueInRow(grid, row, column, valueToPlace, "Two"))
            {
                changeRowBackColor(row.ToString(), true);
                erroniuosRows[row] = true;
            }
            else if (facadeController.isValueRepeatedInRow(grid, row, column, valueToPlace, "Two"))
            {
                erroniuosRows[row] = false;
                changeRowBackColor(row.ToString(), false);

                for (int i = 0; i < 4; i++)
                {
                    if (erroniuosColumns[i] == true)
                    {
                        changeColumnBackColor(i.ToString(), true);
                    }
                }
            }

            if (facadeController.foundValueInColumn(grid, column, row, valueToPlace, "Two"))
            {
                erroniuosColumns[column] = true;
                changeColumnBackColor(column.ToString(), true);
            }
            else if (facadeController.isValueRepeatedInColumn(grid, column, row, valueToPlace, "Two"))
            {
                erroniuosColumns[column] = false;
                changeColumnBackColor(column.ToString(), false);

                for (int i = 0; i < 4; i++)
                {
                    if (erroniuosRows[i] == true)
                    {
                        changeRowBackColor(i.ToString(), true);
                    }
                }
            }

            // Check if grid has been solved
            if (facadeController.isGridSolved(grid, "Two"))
            {
                gameTimer.Stop();
                MetroMessageBox.Show(this, "مبارک ہو آپ نے سوڈوکو حل کرلیا ہے", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (MetroMessageBox.Show(this, "کیا آپ ہمیں اپنی تفصیلات فراہم کریں گے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string timeTaken = facadeController.convertNumberToUrdu(timeInMinutesToComplete - timeAllowedToSolveInMinutes) + " : " + facadeController.convertNumberToUrdu(seconds);

                    GetDetailsAtEndOfGameForm getDetailsAtEnd = new GetDetailsAtEndOfGameForm(timeTaken, noOfMoves.ToString(), timeInMinutesToComplete - timeAllowedToSolveInMinutes, 60 - seconds, 2);
                    this.Hide();
                    getDetailsAtEnd.Show();
                }

                this.Dispose();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == 0)
            {
                timeAllowedToSolveInMinutes--;
                seconds = 60;

                if(timeAllowedToSolveInMinutes == 0)
                {
                    MetroMessageBox.Show(this, "آپ اس کھیل کو حل کرنے میں ناکام رہے ہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gameTimer.Stop();
                    this.Dispose();
                }

                MinutesLBL.Text = facadeController.convertNumberToUrdu(timeAllowedToSolveInMinutes);
            }
            SecondsLBL.Text = facadeController.convertNumberToUrdu(seconds);
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "کیا آپ اس کھیل کو چھوڑنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void TwoByTwoGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "کیا آپ اس کھیل کو چھوڑنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
