namespace SemesterProject_V_0._1
{
    partial class GetDetailsAtEndOfGameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetDetailsAtEndOfGameForm));
            this.ExitBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ElapsedTimeLBL = new System.Windows.Forms.Label();
            this.MovesUsedLBL = new System.Windows.Forms.Label();
            this.CnicTB = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SubmitBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitBTN
            // 
            resources.ApplyResources(this.ExitBTN, "ExitBTN");
            this.ExitBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.ExitBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProvider.SetError(this.ExitBTN, resources.GetString("ExitBTN.Error"));
            this.ExitBTN.FlatAppearance.BorderSize = 3;
            this.ExitBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.errorProvider.SetIconAlignment(this.ExitBTN, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ExitBTN.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.ExitBTN, ((int)(resources.GetObject("ExitBTN.IconPadding"))));
            this.ExitBTN.Name = "ExitBTN";
            this.ExitBTN.UseVisualStyleBackColor = false;
            this.ExitBTN.Click += new System.EventHandler(this.ExitBTN_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.errorProvider.SetError(this.label4, resources.GetString("label4.Error"));
            this.errorProvider.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            // 
            // ElapsedTimeLBL
            // 
            resources.ApplyResources(this.ElapsedTimeLBL, "ElapsedTimeLBL");
            this.errorProvider.SetError(this.ElapsedTimeLBL, resources.GetString("ElapsedTimeLBL.Error"));
            this.errorProvider.SetIconAlignment(this.ElapsedTimeLBL, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ElapsedTimeLBL.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.ElapsedTimeLBL, ((int)(resources.GetObject("ElapsedTimeLBL.IconPadding"))));
            this.ElapsedTimeLBL.Name = "ElapsedTimeLBL";
            // 
            // MovesUsedLBL
            // 
            resources.ApplyResources(this.MovesUsedLBL, "MovesUsedLBL");
            this.errorProvider.SetError(this.MovesUsedLBL, resources.GetString("MovesUsedLBL.Error"));
            this.errorProvider.SetIconAlignment(this.MovesUsedLBL, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("MovesUsedLBL.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.MovesUsedLBL, ((int)(resources.GetObject("MovesUsedLBL.IconPadding"))));
            this.MovesUsedLBL.Name = "MovesUsedLBL";
            // 
            // CnicTB
            // 
            resources.ApplyResources(this.CnicTB, "CnicTB");
            this.errorProvider.SetError(this.CnicTB, resources.GetString("CnicTB.Error"));
            this.errorProvider.SetIconAlignment(this.CnicTB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("CnicTB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.CnicTB, ((int)(resources.GetObject("CnicTB.IconPadding"))));
            this.CnicTB.Name = "CnicTB";
            this.CnicTB.TextChanged += new System.EventHandler(this.CnicTB_TextChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 100;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // SubmitBTN
            // 
            resources.ApplyResources(this.SubmitBTN, "SubmitBTN");
            this.SubmitBTN.BackColor = System.Drawing.Color.White;
            this.SubmitBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProvider.SetError(this.SubmitBTN, resources.GetString("SubmitBTN.Error"));
            this.SubmitBTN.FlatAppearance.BorderSize = 3;
            this.SubmitBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.errorProvider.SetIconAlignment(this.SubmitBTN, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("SubmitBTN.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.SubmitBTN, ((int)(resources.GetObject("SubmitBTN.IconPadding"))));
            this.SubmitBTN.Name = "SubmitBTN";
            this.SubmitBTN.UseVisualStyleBackColor = false;
            this.SubmitBTN.Click += new System.EventHandler(this.SubmitBTN_Click);
            // 
            // GetDetailsAtEndOfGameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SubmitBTN);
            this.Controls.Add(this.CnicTB);
            this.Controls.Add(this.MovesUsedLBL);
            this.Controls.Add(this.ElapsedTimeLBL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitBTN);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Name = "GetDetailsAtEndOfGameForm";
            this.Resizable = false;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ElapsedTimeLBL;
        private System.Windows.Forms.Label MovesUsedLBL;
        private System.Windows.Forms.TextBox CnicTB;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button SubmitBTN;
    }
}