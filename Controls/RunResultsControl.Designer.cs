namespace Guitar.Controls
{
    partial class RunResults
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new ColorProgressBar.ColorProgressBar(ViewModel);
            this.label2 = new System.Windows.Forms.Label();
            this.numTestsLabel = new System.Windows.Forms.Label();
            this.numFailuresLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorScreen3 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 24);
            this.progressBar.Maximum = 9;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(904, 24);
            this.progressBar.TabIndex = 19;
            this.progressBar.Value = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(781, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Number of Failures:";
            // 
            // numTestsLabel
            // 
            this.numTestsLabel.AutoSize = true;
            this.numTestsLabel.Location = new System.Drawing.Point(97, 3);
            this.numTestsLabel.Name = "numTestsLabel";
            this.numTestsLabel.Size = new System.Drawing.Size(13, 13);
            this.numTestsLabel.TabIndex = 22;
            this.numTestsLabel.Text = "0";
            // 
            // numFailuresLabel
            // 
            this.numFailuresLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFailuresLabel.AutoSize = true;
            this.numFailuresLabel.Location = new System.Drawing.Point(885, 3);
            this.numFailuresLabel.Name = "numFailuresLabel";
            this.numFailuresLabel.Size = new System.Drawing.Size(13, 13);
            this.numFailuresLabel.TabIndex = 23;
            this.numFailuresLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Number of Tests:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numFailuresLabel);
            this.panel1.Controls.Add(this.numTestsLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 20);
            this.panel1.TabIndex = 26;
            // 
            // errorScreen3
            // 
            this.errorScreen3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorScreen3.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.errorScreen3.Location = new System.Drawing.Point(0, 68);
            this.errorScreen3.Name = "errorScreen3";
            this.errorScreen3.Size = new System.Drawing.Size(904, 438);
            this.errorScreen3.TabIndex = 27;
            this.errorScreen3.Text = "";
            this.errorScreen3.WordWrap = false;
            // 
            // RunResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorScreen3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar);
            this.Name = "RunResults";
            this.Size = new System.Drawing.Size(904, 506);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorProgressBar.ColorProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numTestsLabel;
        private System.Windows.Forms.Label numFailuresLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox errorScreen3;

    }
}
