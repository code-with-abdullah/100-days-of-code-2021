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
    public partial class ThreeByThreeGameForm : MetroFramework.Forms.MetroForm
    {
        // Local shallow copy of facade controller
        FacadeController facadeController = FacadeController.GetFacadeController();

        // Timer
        byte seconds = 60;
        byte timeAllowedToSolveInMinutes = 0;

        // Original back color of button
        Color originalBackColorOfBtn = Color.FromArgb(240, 240, 20);

        // Get latest button that was clicked
        Button lastSelectedButton = null;

        List<Button> gridRow0 = new List<Button>(9);
        List<Button> gridRow1 = new List<Button>(9);
        List<Button> gridRow2 = new List<Button>(9);
        List<Button> gridRow3 = new List<Button>(9);
        List<Button> gridRow4 = new List<Button>(9);
        List<Button> gridRow5 = new List<Button>(9);
        List<Button> gridRow6 = new List<Button>(9);
        List<Button> gridRow7 = new List<Button>(9);
        List<Button> gridRow8 = new List<Button>(9);
        List<Button> gridCol0 = new List<Button>(9);
        List<Button> gridCol1 = new List<Button>(9);
        List<Button> gridCol2 = new List<Button>(9);
        List<Button> gridCol3 = new List<Button>(9);
        List<Button> gridCol4 = new List<Button>(9);
        List<Button> gridCol5 = new List<Button>(9);
        List<Button> gridCol6 = new List<Button>(9);
        List<Button> gridCol7 = new List<Button>(9);
        List<Button> gridCol8 = new List<Button>(9);

        // Make a list of 9 strings for customizability
        List<string> valuesUsedInSudoku = new List<string>(9);

        // Total number of moves carried out
        int noOfMoves = 0;

        byte timeInMinutesToComplete;

        bool[] erroniuosRows;
        bool[] erroniuosColumns;

        byte[,] grid;

        public ThreeByThreeGameForm(string difficultyLevel="Easy")
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture
            = new System.Globalization.CultureInfo("ur");
            InitializeComponent();

            // Register view Available options event on each button
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    getButton("Button" + i.ToString() + j.ToString()).Click += new System.EventHandler(enableMoveOnClickOfButton);
                }
            }

            // Click function of available options
            foreach (Control button in this.AvailableOptionsPanel.Controls)
            {
                button.Click += new EventHandler(makeMove);
            }

            // Initialize lists used locally
            initializer();

            // Assign difficulty level
            switch (difficultyLevel)
            {
                case "Easy":
                    timeAllowedToSolveInMinutes = 15;
                    fillInitialGameValues(50);
                    break;
                case "Medium":
                    timeAllowedToSolveInMinutes = 12;
                    fillInitialGameValues(30);
                    break;
                case "Hard":
                    timeAllowedToSolveInMinutes = 10;
                    fillInitialGameValues(10);
                    break;
            }
            this.MinutesLBL.Text = facadeController.convertNumberToUrdu(timeAllowedToSolveInMinutes - 1);

            timeInMinutesToComplete = timeAllowedToSolveInMinutes;

            // Start timer at the start of game
            elapsedTimeTimer.Start();
        }

        private void initializer()
        {
            #region
            gridCol0.Add(Button00);
            gridCol0.Add(Button10);
            gridCol0.Add(Button20);
            gridCol0.Add(Button30);
            gridCol0.Add(Button40);
            gridCol0.Add(Button50);
            gridCol0.Add(Button60);
            gridCol0.Add(Button70);
            gridCol0.Add(Button80);

            gridCol1.Add(Button01);
            gridCol1.Add(Button11);
            gridCol1.Add(Button21);
            gridCol1.Add(Button31);
            gridCol1.Add(Button41);
            gridCol1.Add(Button51);
            gridCol1.Add(Button61);
            gridCol1.Add(Button71);
            gridCol1.Add(Button81);

            gridCol2.Add(Button02);
            gridCol2.Add(Button12);
            gridCol2.Add(Button22);
            gridCol2.Add(Button32);
            gridCol2.Add(Button42);
            gridCol2.Add(Button52);
            gridCol2.Add(Button62);
            gridCol2.Add(Button72);
            gridCol2.Add(Button82);

            gridCol3.Add(Button03);
            gridCol3.Add(Button13);
            gridCol3.Add(Button23);
            gridCol3.Add(Button33);
            gridCol3.Add(Button43);
            gridCol3.Add(Button53);
            gridCol3.Add(Button63);
            gridCol3.Add(Button73);
            gridCol3.Add(Button83);

            gridCol4.Add(Button04);
            gridCol4.Add(Button14);
            gridCol4.Add(Button24);
            gridCol4.Add(Button34);
            gridCol4.Add(Button44);
            gridCol4.Add(Button54);
            gridCol4.Add(Button64);
            gridCol4.Add(Button74);
            gridCol4.Add(Button84);

            gridCol5.Add(Button05);
            gridCol5.Add(Button15);
            gridCol5.Add(Button25);
            gridCol5.Add(Button35);
            gridCol5.Add(Button45);
            gridCol5.Add(Button55);
            gridCol5.Add(Button65);
            gridCol5.Add(Button75);
            gridCol5.Add(Button85);

            gridCol6.Add(Button06);
            gridCol6.Add(Button16);
            gridCol6.Add(Button26);
            gridCol6.Add(Button36);
            gridCol6.Add(Button46);
            gridCol6.Add(Button56);
            gridCol6.Add(Button66);
            gridCol6.Add(Button76);
            gridCol6.Add(Button86);

            gridCol7.Add(Button07);
            gridCol7.Add(Button17);
            gridCol7.Add(Button27);
            gridCol7.Add(Button37);
            gridCol7.Add(Button47);
            gridCol7.Add(Button57);
            gridCol7.Add(Button67);
            gridCol7.Add(Button77);
            gridCol7.Add(Button87);

            gridCol8.Add(Button08);
            gridCol8.Add(Button18);
            gridCol8.Add(Button28);
            gridCol8.Add(Button38);
            gridCol8.Add(Button48);
            gridCol8.Add(Button58);
            gridCol8.Add(Button68);
            gridCol8.Add(Button78);
            gridCol8.Add(Button88);

            #endregion

            #region
            gridRow0.Add(Button00);
            gridRow0.Add(Button01);
            gridRow0.Add(Button02);
            gridRow0.Add(Button03);
            gridRow0.Add(Button04);
            gridRow0.Add(Button05);
            gridRow0.Add(Button06);
            gridRow0.Add(Button07);
            gridRow0.Add(Button08);

            gridRow1.Add(Button10);
            gridRow1.Add(Button11);
            gridRow1.Add(Button12);
            gridRow1.Add(Button13);
            gridRow1.Add(Button14);
            gridRow1.Add(Button15);
            gridRow1.Add(Button16);
            gridRow1.Add(Button17);
            gridRow1.Add(Button18);

            gridRow2.Add(Button20);
            gridRow2.Add(Button21);
            gridRow2.Add(Button22);
            gridRow2.Add(Button23);
            gridRow2.Add(Button24);
            gridRow2.Add(Button25);
            gridRow2.Add(Button26);
            gridRow2.Add(Button27);
            gridRow2.Add(Button28);

            gridRow3.Add(Button30);
            gridRow3.Add(Button31);
            gridRow3.Add(Button32);
            gridRow3.Add(Button33);
            gridRow3.Add(Button34);
            gridRow3.Add(Button35);
            gridRow3.Add(Button36);
            gridRow3.Add(Button37);
            gridRow3.Add(Button38);

            gridRow4.Add(Button40);
            gridRow4.Add(Button41);
            gridRow4.Add(Button42);
            gridRow4.Add(Button43);
            gridRow4.Add(Button44);
            gridRow4.Add(Button45);
            gridRow4.Add(Button46);
            gridRow4.Add(Button47);
            gridRow4.Add(Button48);

            gridRow5.Add(Button50);
            gridRow5.Add(Button51);
            gridRow5.Add(Button52);
            gridRow5.Add(Button53);
            gridRow5.Add(Button54);
            gridRow5.Add(Button55);
            gridRow5.Add(Button56);
            gridRow5.Add(Button57);
            gridRow5.Add(Button58);

            gridRow6.Add(Button60);
            gridRow6.Add(Button61);
            gridRow6.Add(Button62);
            gridRow6.Add(Button63);
            gridRow6.Add(Button64);
            gridRow6.Add(Button65);
            gridRow6.Add(Button66);
            gridRow6.Add(Button67);
            gridRow6.Add(Button68);

            gridRow7.Add(Button70);
            gridRow7.Add(Button71);
            gridRow7.Add(Button72);
            gridRow7.Add(Button73);
            gridRow7.Add(Button74);
            gridRow7.Add(Button75);
            gridRow7.Add(Button76);
            gridRow7.Add(Button77);
            gridRow7.Add(Button78);

            gridRow8.Add(Button80);
            gridRow8.Add(Button81);
            gridRow8.Add(Button82);
            gridRow8.Add(Button83);
            gridRow8.Add(Button84);
            gridRow8.Add(Button85);
            gridRow8.Add(Button86);
            gridRow8.Add(Button87);
            gridRow8.Add(Button88);
            #endregion

            erroniuosRows = new bool[9] { false, false, false, false, false, false, false, false, false };
            erroniuosColumns = new bool[9] { false, false, false, false, false, false, false, false, false };

            grid = new byte[9, 9] {
                { 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 },
                { 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 },
                { 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 },{ 255, 255, 255, 255, 255, 255, 255, 255, 255 } };

            valuesUsedInSudoku = facadeController.getDefaultRandomValueToStartGame("Three");

            for (int i = 0; i < 9; i++)
            {
                AvailableOptionsPanel.Controls["Option" + i.ToString()].Text = valuesUsedInSudoku[i];
            }
        }

        public void enableMoveOnClickOfButton(object sender, EventArgs e)
        {
            AvailableOptionsPanel.Enabled = true;
            lastSelectedButton = (sender as Button);
            AvailableOptionsPanel.Visible = true;
        }

        public void makeMove(object sender, EventArgs e)
        {
            // Names are in the format "ButtonRC" where R represents row and C represents column
            int row = int.Parse(lastSelectedButton.Name.Substring(6, 1));
            int column = int.Parse(lastSelectedButton.Name.Substring(7, 1));

            // Get the index of Selected Option and store it in 
            byte valueToPlace = Convert.ToByte(valuesUsedInSudoku.IndexOf((sender as Button).Text));

            this.AvailableOptionsPanel.Visible = false;
            lastSelectedButton.Text = (sender as Button).Text;
            this.MovesCarriedOutLBL.Text = (facadeController.convertNumberToUrdu(++noOfMoves));

            grid[row, column] = valueToPlace;

            if (facadeController.isValueRepeatedInRowUpdated(grid, row, "Three"))
            {
                erroniuosRows[row] = true;
            }
            else
            {
                erroniuosRows[row] = false;
            }

            if (facadeController.isValueRepeatedInColumnUpdated(grid, column, "Three"))
            {
                erroniuosColumns[column] = true;
            }
            else
            {
                erroniuosColumns[column] = false;
            }

            for (int i = 0; i < 9; i++)
            {
                changeRowBackColor(i.ToString(), false);
                changeColumnBackColor(i.ToString(), false);
            }

            for (int i = 0; i < 9; i++)
            {
                if (erroniuosRows[i])
                {
                    changeRowBackColor(i.ToString(), true);
                }
                if (erroniuosColumns[i])
                {
                    changeColumnBackColor(i.ToString(), true);
                }
            }

            // Check if grid has been solved
            if (facadeController.isThreeByThreeGridSolved(grid))
            {
                if (!isAnyErroniousRowOrColumnLeft())
                {
                    elapsedTimeTimer.Stop();
                    MetroMessageBox.Show(this, "مبارک ہو آپ نے سوڈوکو حل کرلیا ہے", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if (MetroMessageBox.Show(this, "کیا آپ ہمیں اپنی تفصیلات فراہم کریں گے؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string timeTaken = facadeController.convertNumberToUrdu(timeInMinutesToComplete - timeAllowedToSolveInMinutes) + " : " + facadeController.convertNumberToUrdu(60 - seconds);

                        GetDetailsAtEndOfGameForm getDetailsAtEnd = new GetDetailsAtEndOfGameForm(timeTaken, noOfMoves.ToString(), timeInMinutesToComplete - timeAllowedToSolveInMinutes, 60 - seconds, 3);
                        this.Hide();
                        getDetailsAtEnd.Show();
                    }
                    this.Dispose();
                }
            }
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
                    case "4":
                        changeRowBackColorToRed(gridRow0);
                        break;
                    case "5":
                        changeRowBackColorToRed(gridRow1);
                        break;
                    case "6":
                        changeRowBackColorToRed(gridRow2);
                        break;
                    case "7":
                        changeRowBackColorToRed(gridRow2);
                        break;
                    case "8":
                        changeRowBackColorToRed(gridRow2);
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
                    case "4":
                        changeRowBackColorToNormal(gridRow0);
                        break;
                    case "5":
                        changeRowBackColorToNormal(gridRow1);
                        break;
                    case "6":
                        changeRowBackColorToNormal(gridRow2);
                        break;
                    case "7":
                        changeRowBackColorToNormal(gridRow2);
                        break;
                    case "8":
                        changeRowBackColorToNormal(gridRow2);
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
                    case "4":
                        changeColumnBackColorToRed(gridCol4);
                        break;
                    case "5":
                        changeColumnBackColorToRed(gridCol5);
                        break;
                    case "6":
                        changeColumnBackColorToRed(gridCol6);
                        break;
                    case "7":
                        changeColumnBackColorToRed(gridCol7);
                        break;
                    case "8":
                        changeColumnBackColorToRed(gridCol8);
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
                    case "4":
                        changeColumnBackColorToNormal(gridCol4);
                        break;
                    case "5":
                        changeColumnBackColorToNormal(gridCol5);
                        break;
                    case "6":
                        changeColumnBackColorToNormal(gridCol6);
                        break;
                    case "7":
                        changeColumnBackColorToNormal(gridCol7);
                        break;
                    case "8":
                        changeColumnBackColorToNormal(gridCol8);
                        break;
                }
            }
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, "کیا آپ اس کھیل کو چھوڑنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void ThreeByThreeGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this, "کیا آپ اس کھیل کو چھوڑنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void ElapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == 0)
            {
                timeAllowedToSolveInMinutes--;
                this.MinutesLBL.Text = facadeController.convertNumberToUrdu(timeAllowedToSolveInMinutes);
                if (timeAllowedToSolveInMinutes == 0)
                {
                    MetroMessageBox.Show(this, "آپ اس کھیل کو حل کرنے میں ناکام رہے ہیں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    elapsedTimeTimer.Stop();
                    this.Dispose();
                }
                seconds = 60;
            }

            SecondsLBL.Text = facadeController.convertNumberToUrdu(seconds);
        }

        private Button getButton(string name)
        {
            foreach (Control control in this.ThreeByThreeGrid.Controls)
            {
                if (control is Panel)
                {
                    foreach (Control innerControl in control.Controls)
                    {
                        if (innerControl is Button)
                        {
                            if (innerControl.Name == name)
                            {
                                return (innerControl as Button);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private bool isAnyErroniousRowOrColumnLeft()
        {
            for (int i = 0; i < 9; i++)
            {
                // Find if any erronious row or column is left
                if(!(erroniuosRows[i]) || !(erroniuosColumns[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private void fillInitialGameValues(int numberOfFilledButtons)
        {
            List<int> rows = facadeController.generateRandomList(numberOfFilledButtons, "Three");
            List<int> columns = facadeController.generateRandomListTwo(numberOfFilledButtons, "Three");

            byte valueToPlace = 0;

            for (int i = 0; i < numberOfFilledButtons; i++)
            {
                if (i == 0)
                {
                    grid[rows[i], columns[i]] = valueToPlace;

                    string firstButtonToDisable = "Button" + rows[i].ToString() + columns[i].ToString();

                    Button ButtonFirstButtonToDisable = getButton(firstButtonToDisable);

                    //ButtonFirstButtonToDisable.Enabled = false;
                    ButtonFirstButtonToDisable.Text = valuesUsedInSudoku[valueToPlace];

                    continue;
                }

                while (facadeController.foundValueInRow(grid, rows[i], columns[i], valueToPlace, "Three")
                    ||
                    facadeController.foundValueInColumn(grid, columns[i], rows[i], valueToPlace, "Three"))
                {
                    valueToPlace++;   
                }
                if (valueToPlace > 8)
                {
                    continue;
                }

                grid[rows[i], columns[i]] = valueToPlace;
                string btnToDisable = "Button" + rows[i].ToString() + columns[i].ToString();

                Button buttonToDisable = getButton(btnToDisable);

                //buttonToDisable.Enabled = false;
                buttonToDisable.Text = valuesUsedInSudoku[valueToPlace];
            }
        }

    }
}
