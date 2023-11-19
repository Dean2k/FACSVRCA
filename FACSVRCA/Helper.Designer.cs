namespace FACSVRCA
{
    partial class Helper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBrowse = new Button();
            btnFix = new Button();
            txtFilePath = new TextBox();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(514, 19);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(91, 26);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnFix
            // 
            btnFix.Location = new Point(611, 19);
            btnFix.Name = "btnFix";
            btnFix.Size = new Size(91, 26);
            btnFix.TabIndex = 1;
            btnFix.Text = "Fix";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += btnFix_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(12, 19);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(496, 23);
            txtFilePath.TabIndex = 2;
            // 
            // Helper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 60);
            Controls.Add(txtFilePath);
            Controls.Add(btnFix);
            Controls.Add(btnBrowse);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Helper";
            Text = "FACS Helper";
            Load += Helper_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBrowse;
        private Button btnFix;
        private TextBox txtFilePath;
    }
}