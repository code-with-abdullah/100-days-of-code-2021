namespace SemesterProject_V_0._1
{
    partial class StatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CnicTB = new System.Windows.Forms.TextBox();
            this.ExitBTN = new System.Windows.Forms.Button();
            this.RankingLBL = new System.Windows.Forms.Label();
            this.MoveNextPB = new System.Windows.Forms.PictureBox();
            this.MovePrevPB = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MoveNextPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrevPB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CnicTB
            // 
            resources.ApplyResources(this.CnicTB, "CnicTB");
            this.CnicTB.Name = "CnicTB";
            this.CnicTB.ReadOnly = true;
            // 
            // ExitBTN
            // 
            resources.ApplyResources(this.ExitBTN, "ExitBTN");
            this.ExitBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.ExitBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBTN.FlatAppearance.BorderSize = 3;
            this.ExitBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ExitBTN.Name = "ExitBTN";
            this.ExitBTN.UseVisualStyleBackColor = false;
            this.ExitBTN.Click += new System.EventHandler(this.ExitBTN_Click);
            // 
            // RankingLBL
            // 
            resources.ApplyResources(this.RankingLBL, "RankingLBL");
            this.RankingLBL.Name = "RankingLBL";
            // 
            // MoveNextPB
            // 
            resources.ApplyResources(this.MoveNextPB, "MoveNextPB");
            this.MoveNextPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveNextPB.Image = global::SemesterProject_V_0._1.Properties.Resources.next;
            this.MoveNextPB.Name = "MoveNextPB";
            this.MoveNextPB.TabStop = false;
            this.MoveNextPB.Click += new System.EventHandler(this.MoveNextPB_Click);
            // 
            // MovePrevPB
            // 
            resources.ApplyResources(this.MovePrevPB, "MovePrevPB");
            this.MovePrevPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MovePrevPB.Image = global::SemesterProject_V_0._1.Properties.Resources.prev;
            this.MovePrevPB.Name = "MovePrevPB";
            this.MovePrevPB.TabStop = false;
            this.MovePrevPB.Click += new System.EventHandler(this.MovePrevPB_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // StatsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MovePrevPB);
            this.Controls.Add(this.MoveNextPB);
            this.Controls.Add(this.RankingLBL);
            this.Controls.Add(this.ExitBTN);
            this.Controls.Add(this.CnicTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Name = "StatsForm";
            this.Resizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.MoveNextPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovePrevPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CnicTB;
        private System.Windows.Forms.Button ExitBTN;
        private System.Windows.Forms.Label RankingLBL;
        private System.Windows.Forms.PictureBox MoveNextPB;
        private System.Windows.Forms.PictureBox MovePrevPB;
        private System.Windows.Forms.Label label3;
    }
}