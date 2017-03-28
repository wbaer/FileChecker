namespace SharePoint.FileChecker
{
    partial class Control
    {
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.GroupBox outputGroup;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuCommandLine;
        private System.Windows.Forms.ToolStripMenuItem menuTechCenter;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.GroupBox inputGroup;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.validateButton = new System.Windows.Forms.Button();
            this.outputGroup = new System.Windows.Forms.GroupBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommandLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTechCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.inputGroup = new System.Windows.Forms.GroupBox();
            this.outputGroup.SuspendLayout();
            this.menu.SuspendLayout();
            this.inputGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.SystemColors.Menu;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(6, 27);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(418, 39);
            this.inputBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(6, 58);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(66, 33);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.Browse_Click);
            // 
            // validateButton
            // 
            this.validateButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validateButton.Location = new System.Drawing.Point(78, 58);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(66, 33);
            this.validateButton.TabIndex = 2;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.Validate_Click);
            // 
            // outputGroup
            // 
            this.outputGroup.Controls.Add(this.outputBox);
            this.outputGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputGroup.Location = new System.Drawing.Point(12, 139);
            this.outputGroup.Name = "outputGroup";
            this.outputGroup.Size = new System.Drawing.Size(430, 314);
            this.outputGroup.TabIndex = 3;
            this.outputGroup.TabStop = false;
            this.outputGroup.Text = "Output";
            // 
            // outputBox
            // 
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(6, 24);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(418, 283);
            this.outputBox.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(457, 40);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(64, 36);
            this.menuFile.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(152, 38);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCommandLine,
            this.menuTechCenter,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(77, 36);
            this.menuHelp.Text = "Help";
            // 
            // menuCommandLine
            // 
            this.menuCommandLine.Name = "menuCommandLine";
            this.menuCommandLine.Size = new System.Drawing.Size(337, 38);
            this.menuCommandLine.Text = "Command Line Help";
            this.menuCommandLine.Click += new System.EventHandler(this.Command_Click);
            // 
            // menuTechCenter
            // 
            this.menuTechCenter.Name = "menuTechCenter";
            this.menuTechCenter.Size = new System.Drawing.Size(337, 38);
            this.menuTechCenter.Text = "TechCenter Web Site";
            this.menuTechCenter.Click += new System.EventHandler(this.TechCenter_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(337, 38);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.About_Click);
            // 
            // inputGroup
            // 
            this.inputGroup.Controls.Add(this.inputBox);
            this.inputGroup.Controls.Add(this.browseButton);
            this.inputGroup.Controls.Add(this.validateButton);
            this.inputGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputGroup.Location = new System.Drawing.Point(12, 35);
            this.inputGroup.Name = "inputGroup";
            this.inputGroup.Size = new System.Drawing.Size(430, 98);
            this.inputGroup.TabIndex = 5;
            this.inputGroup.TabStop = false;
            this.inputGroup.Text = "Input";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(457, 477);
            this.Controls.Add(this.inputGroup);
            this.Controls.Add(this.outputGroup);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menu;
            this.Name = "Control";
            this.ShowIcon = false;
            this.Text = "SharePoint File Validation Tool";
            this.outputGroup.ResumeLayout(false);
            this.outputGroup.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.inputGroup.ResumeLayout(false);
            this.inputGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
