namespace GUI
{
    partial class SelectDatabaseForm
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
            this.exitbtn = new System.Windows.Forms.Button();
            this.SQLServerbtn = new System.Windows.Forms.Button();
            this.filebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.exitbtn.Location = new System.Drawing.Point(119, 109);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(120, 40);
            this.exitbtn.TabIndex = 0;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // SQLServerbtn
            // 
            this.SQLServerbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SQLServerbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.SQLServerbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SQLServerbtn.Location = new System.Drawing.Point(25, 47);
            this.SQLServerbtn.Name = "SQLServerbtn";
            this.SQLServerbtn.Size = new System.Drawing.Size(120, 40);
            this.SQLServerbtn.TabIndex = 0;
            this.SQLServerbtn.Text = "SQL Server";
            this.SQLServerbtn.UseVisualStyleBackColor = true;
            this.SQLServerbtn.Click += new System.EventHandler(this.SQLServerbtn_Click);
            // 
            // filebtn
            // 
            this.filebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.filebtn.Location = new System.Drawing.Point(210, 47);
            this.filebtn.Name = "filebtn";
            this.filebtn.Size = new System.Drawing.Size(120, 40);
            this.filebtn.TabIndex = 0;
            this.filebtn.Text = "File ";
            this.filebtn.UseVisualStyleBackColor = true;
            this.filebtn.Click += new System.EventHandler(this.filebtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Using data in:";
            // 
            // SelectDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(360, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filebtn);
            this.Controls.Add(this.SQLServerbtn);
            this.Controls.Add(this.exitbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "SelectDatabaseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select DataBase";
            this.Load += new System.EventHandler(this.SelectDatabaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button SQLServerbtn;
        private System.Windows.Forms.Button filebtn;
        private System.Windows.Forms.Label label1;
    }
}