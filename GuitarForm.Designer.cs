using Guitar.Controls;

namespace Guitar
{
    partial class GuitarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuitarForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.goBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.exeFilename = new System.Windows.Forms.ComboBox();
            this.clParams = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.shouldShuffle = new System.Windows.Forms.CheckBox();
            this.shouldRunDisabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startupFolder = new System.Windows.Forms.ComboBox();
            this.buttonSelectStartupFolder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutGuitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.formCloseTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.testTree = new Guitar.Controls.TestTreeView();
            this.runResults1 = new Guitar.Controls.RunResults();
            this.menuStrip1.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.Filter = "Executable|*.exe|All files|*.*";
            // 
            // goBtn
            // 
            this.goBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.goBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBtn.Location = new System.Drawing.Point(320, 3);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(120, 35);
            this.goBtn.TabIndex = 7;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Google Test exe";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Location = new System.Drawing.Point(726, 9);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select...";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // exeFilename
            // 
            this.exeFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exeFilename.FormattingEnabled = true;
            this.exeFilename.Location = new System.Drawing.Point(119, 9);
            this.exeFilename.Name = "exeFilename";
            this.exeFilename.Size = new System.Drawing.Size(603, 21);
            this.exeFilename.TabIndex = 0;
            this.exeFilename.TextChanged += new System.EventHandler(this.exeFilename_TextChanged);
            // 
            // clParams
            // 
            this.clParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clParams.FormattingEnabled = true;
            this.clParams.Location = new System.Drawing.Point(119, 138);
            this.clParams.Name = "clParams";
            this.clParams.Size = new System.Drawing.Size(603, 21);
            this.clParams.TabIndex = 2;
            this.clParams.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command line params";
            this.label4.Visible = false;
            // 
            // shouldShuffle
            // 
            this.shouldShuffle.AutoSize = true;
            this.shouldShuffle.Checked = true;
            this.shouldShuffle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shouldShuffle.Location = new System.Drawing.Point(126, 37);
            this.shouldShuffle.Name = "shouldShuffle";
            this.shouldShuffle.Size = new System.Drawing.Size(59, 17);
            this.shouldShuffle.TabIndex = 3;
            this.shouldShuffle.Text = "Shuffle";
            this.shouldShuffle.UseVisualStyleBackColor = true;
            // 
            // shouldRunDisabled
            // 
            this.shouldRunDisabled.AutoSize = true;
            this.shouldRunDisabled.Location = new System.Drawing.Point(126, 60);
            this.shouldRunDisabled.Name = "shouldRunDisabled";
            this.shouldRunDisabled.Size = new System.Drawing.Size(119, 17);
            this.shouldRunDisabled.TabIndex = 4;
            this.shouldRunDisabled.Text = "Run Disabled Tests";
            this.shouldRunDisabled.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Filter";
            this.label5.Visible = false;
            // 
            // filter
            // 
            this.filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filter.FormattingEnabled = true;
            this.filter.Location = new System.Drawing.Point(119, 111);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(603, 21);
            this.filter.TabIndex = 6;
            this.filter.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Startup folder";
            // 
            // startupFolder
            // 
            this.startupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startupFolder.Location = new System.Drawing.Point(119, 85);
            this.startupFolder.Name = "startupFolder";
            this.startupFolder.Size = new System.Drawing.Size(603, 21);
            this.startupFolder.TabIndex = 19;
            // 
            // buttonSelectStartupFolder
            // 
            this.buttonSelectStartupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectStartupFolder.Location = new System.Drawing.Point(726, 83);
            this.buttonSelectStartupFolder.Name = "buttonSelectStartupFolder";
            this.buttonSelectStartupFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectStartupFolder.TabIndex = 20;
            this.buttonSelectStartupFolder.Text = "Select..";
            this.buttonSelectStartupFolder.UseVisualStyleBackColor = true;
            this.buttonSelectStartupFolder.Click += new System.EventHandler(this.buttonSelectStartupFolder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1214, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.optionsToolStripMenuItem.Text = "Options Panel";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutGuitarToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutGuitarToolStripMenuItem
            // 
            this.aboutGuitarToolStripMenuItem.Name = "aboutGuitarToolStripMenuItem";
            this.aboutGuitarToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutGuitarToolStripMenuItem.Text = "About Guitar";
            this.aboutGuitarToolStripMenuItem.Click += new System.EventHandler(this.aboutGuitarToolStripMenuItem_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.buttonSelectStartupFolder);
            this.optionsPanel.Controls.Add(this.label6);
            this.optionsPanel.Controls.Add(this.startupFolder);
            this.optionsPanel.Controls.Add(this.buttonSelect);
            this.optionsPanel.Controls.Add(this.label4);
            this.optionsPanel.Controls.Add(this.shouldRunDisabled);
            this.optionsPanel.Controls.Add(this.filter);
            this.optionsPanel.Controls.Add(this.shouldShuffle);
            this.optionsPanel.Controls.Add(this.label3);
            this.optionsPanel.Controls.Add(this.label5);
            this.optionsPanel.Controls.Add(this.exeFilename);
            this.optionsPanel.Controls.Add(this.clParams);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(806, 164);
            this.optionsPanel.TabIndex = 22;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.optionsPanel);
            this.splitContainer2.Panel1.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.splitContainer2.Panel1MinSize = 150;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.runResults1);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel2MinSize = 150;
            this.splitContainer2.Size = new System.Drawing.Size(806, 757);
            this.splitContainer2.SplitterDistance = 164;
            this.splitContainer2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.goBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 549);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 40);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // formCloseTimer
            // 
            this.formCloseTimer.Tick += new System.EventHandler(this.formCloseTimer_Tick);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 24);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.testTree);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(1214, 757);
            this.splitContainer3.SplitterDistance = 404;
            this.splitContainer3.TabIndex = 24;
            // 
            // testTree
            // 
            this.testTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testTree.Location = new System.Drawing.Point(0, 0);
            this.testTree.Name = "testTree";
            this.testTree.Size = new System.Drawing.Size(404, 757);
            this.testTree.TabIndex = 0;
            // 
            // runResults1
            // 
            this.runResults1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runResults1.Location = new System.Drawing.Point(0, 0);
            this.runResults1.Name = "runResults1";
            this.runResults1.Size = new System.Drawing.Size(806, 549);
            this.runResults1.TabIndex = 8;
            // 
            // GuitarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 781);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GuitarForm";
            this.Text = "Guitar 1.2.3 - Google Unit Test Application Runner";
            this.Load += new System.EventHandler(this.GuitarForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GuitarForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ComboBox exeFilename;
        private System.Windows.Forms.ComboBox clParams;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox shouldShuffle;
        private System.Windows.Forms.CheckBox shouldRunDisabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox filter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox startupFolder;
        private System.Windows.Forms.Button buttonSelectStartupFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutGuitarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Timer formCloseTimer;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private TestTreeView testTree;
        private RunResults runResults1;
        private System.Windows.Forms.Panel panel1;
    }
}

