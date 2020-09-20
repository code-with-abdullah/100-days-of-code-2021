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
using System.Data.SqlClient;

namespace SemesterProject_V_0._1
{
    public partial class StatsForm : MetroFramework.Forms.MetroForm
    {
        FacadeController facadeController = FacadeController.GetFacadeController();
        List<string> Cnics;

        int i = 0;

        public StatsForm()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("ur");

            InitializeComponent();

            Cnics = new List<string>();

            SqlDataReader reader = facadeController.readTopTenGames();

            while(reader.Read())
            {
                Cnics.Add(reader["Cnic"].ToString());
            }

            CnicTB.Text = Cnics[0];
            RankingLBL.Text = facadeController.convertNumberToUrdu(1);

            
        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MoveNextPB_Click(object sender, EventArgs e)
        {
            if (i < 10 && i + 1 < Cnics.Count)
            {
                i++;
                this.CnicTB.Text = Cnics[i];
                this.RankingLBL.Text = facadeController.convertNumberToUrdu(i + 1);
            }
        }

        private void MovePrevPB_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                this.CnicTB.Text = Cnics[i];
                this.RankingLBL.Text = facadeController.convertNumberToUrdu(i + 1);
            }
        }
    }
}
