namespace NeuralNet
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMNISTCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMNISTCSVtestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMNISTByteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMNISTBytetestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTMNISTCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sigmoidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reLUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siLUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useExistingWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clearDrawingBtn = new System.Windows.Forms.Button();
            this.submitDrawingBtn = new System.Windows.Forms.Button();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.drawingAreaLabel = new System.Windows.Forms.Label();
            this.displayArea = new System.Windows.Forms.PictureBox();
            this.displayAreaLabel = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.testBtn2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDisplay = new System.Windows.Forms.GroupBox();
            this.showDisplayBox = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayArea)).BeginInit();
            this.groupDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.activationTypesToolStripMenuItem,
            this.weightsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(46, 24);
            this.fileMenu.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMNISTCSVToolStripMenuItem,
            this.loadMNISTCSVtestToolStripMenuItem,
            this.loadMNISTByteToolStripMenuItem,
            this.loadMNISTBytetestToolStripMenuItem,
            this.loadTMNISTCSVToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(58, 24);
            this.toolsMenu.Text = "&Tools";
            // 
            // loadMNISTCSVToolStripMenuItem
            // 
            this.loadMNISTCSVToolStripMenuItem.Name = "loadMNISTCSVToolStripMenuItem";
            this.loadMNISTCSVToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadMNISTCSVToolStripMenuItem.Text = "Load MNIST CSV";
            this.loadMNISTCSVToolStripMenuItem.Click += new System.EventHandler(this.loadMNISTCSVToolStripMenuItem_Click);
            // 
            // loadMNISTCSVtestToolStripMenuItem
            // 
            this.loadMNISTCSVtestToolStripMenuItem.Name = "loadMNISTCSVtestToolStripMenuItem";
            this.loadMNISTCSVtestToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadMNISTCSVtestToolStripMenuItem.Text = "Load MNIST CSV_test";
            this.loadMNISTCSVtestToolStripMenuItem.Click += new System.EventHandler(this.loadMNISTCSVtestToolStripMenuItem_Click);
            // 
            // loadMNISTByteToolStripMenuItem
            // 
            this.loadMNISTByteToolStripMenuItem.Name = "loadMNISTByteToolStripMenuItem";
            this.loadMNISTByteToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadMNISTByteToolStripMenuItem.Text = "Load MNIST byte";
            this.loadMNISTByteToolStripMenuItem.Click += new System.EventHandler(this.loadMNISTByteToolStripMenuItem_Click);
            // 
            // loadMNISTBytetestToolStripMenuItem
            // 
            this.loadMNISTBytetestToolStripMenuItem.Name = "loadMNISTBytetestToolStripMenuItem";
            this.loadMNISTBytetestToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadMNISTBytetestToolStripMenuItem.Text = "Load MNIST byte_test";
            this.loadMNISTBytetestToolStripMenuItem.Click += new System.EventHandler(this.loadMNISTBytetestToolStripMenuItem_Click);
            // 
            // loadTMNISTCSVToolStripMenuItem
            // 
            this.loadTMNISTCSVToolStripMenuItem.Name = "loadTMNISTCSVToolStripMenuItem";
            this.loadTMNISTCSVToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.loadTMNISTCSVToolStripMenuItem.Text = "Load TMNIST CSV";
            this.loadTMNISTCSVToolStripMenuItem.Click += new System.EventHandler(this.loadTMNISTCSVToolStripMenuItem_Click);
            // 
            // activationTypesToolStripMenuItem
            // 
            this.activationTypesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sigmoidToolStripMenuItem,
            this.tanHToolStripMenuItem,
            this.reLUToolStripMenuItem,
            this.siLUToolStripMenuItem});
            this.activationTypesToolStripMenuItem.Name = "activationTypesToolStripMenuItem";
            this.activationTypesToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.activationTypesToolStripMenuItem.Text = "Activation Types";
            // 
            // sigmoidToolStripMenuItem
            // 
            this.sigmoidToolStripMenuItem.Name = "sigmoidToolStripMenuItem";
            this.sigmoidToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.sigmoidToolStripMenuItem.Text = "Sigmoid";
            this.sigmoidToolStripMenuItem.Click += new System.EventHandler(this.sigmoidToolStripMenuItem_Click);
            // 
            // tanHToolStripMenuItem
            // 
            this.tanHToolStripMenuItem.Name = "tanHToolStripMenuItem";
            this.tanHToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.tanHToolStripMenuItem.Text = "TanH";
            this.tanHToolStripMenuItem.Click += new System.EventHandler(this.tanHToolStripMenuItem_Click);
            // 
            // reLUToolStripMenuItem
            // 
            this.reLUToolStripMenuItem.Name = "reLUToolStripMenuItem";
            this.reLUToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.reLUToolStripMenuItem.Text = "ReLU";
            this.reLUToolStripMenuItem.Click += new System.EventHandler(this.reLUToolStripMenuItem_Click);
            // 
            // siLUToolStripMenuItem
            // 
            this.siLUToolStripMenuItem.Name = "siLUToolStripMenuItem";
            this.siLUToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.siLUToolStripMenuItem.Text = "SiLU";
            this.siLUToolStripMenuItem.Click += new System.EventHandler(this.siLUToolStripMenuItem_Click);
            // 
            // weightsToolStripMenuItem
            // 
            this.weightsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useExistingWeightsToolStripMenuItem,
            this.createWeightsToolStripMenuItem});
            this.weightsToolStripMenuItem.Name = "weightsToolStripMenuItem";
            this.weightsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.weightsToolStripMenuItem.Text = "Weights";
            // 
            // useExistingWeightsToolStripMenuItem
            // 
            this.useExistingWeightsToolStripMenuItem.Name = "useExistingWeightsToolStripMenuItem";
            this.useExistingWeightsToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.useExistingWeightsToolStripMenuItem.Text = "Use Existing Weights";
            this.useExistingWeightsToolStripMenuItem.Click += new System.EventHandler(this.useExistingWeightsToolStripMenuItem_Click);
            // 
            // createWeightsToolStripMenuItem
            // 
            this.createWeightsToolStripMenuItem.Name = "createWeightsToolStripMenuItem";
            this.createWeightsToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.createWeightsToolStripMenuItem.Text = "Create Weights";
            this.createWeightsToolStripMenuItem.Click += new System.EventHandler(this.createWeightsToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 464);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(684, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // clearDrawingBtn
            // 
            this.clearDrawingBtn.Location = new System.Drawing.Point(120, 348);
            this.clearDrawingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearDrawingBtn.Name = "clearDrawingBtn";
            this.clearDrawingBtn.Size = new System.Drawing.Size(100, 47);
            this.clearDrawingBtn.TabIndex = 5;
            this.clearDrawingBtn.Text = "Clear Drawing";
            this.clearDrawingBtn.UseVisualStyleBackColor = true;
            this.clearDrawingBtn.Click += new System.EventHandler(this.clearDrawingBtn_Click);
            // 
            // submitDrawingBtn
            // 
            this.submitDrawingBtn.Location = new System.Drawing.Point(12, 348);
            this.submitDrawingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.submitDrawingBtn.Name = "submitDrawingBtn";
            this.submitDrawingBtn.Size = new System.Drawing.Size(100, 47);
            this.submitDrawingBtn.TabIndex = 6;
            this.submitDrawingBtn.Text = "Submit Drawing";
            this.submitDrawingBtn.UseVisualStyleBackColor = true;
            this.submitDrawingBtn.Click += new System.EventHandler(this.submitDrawingBtn_Click);
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(12, 60);
            this.drawingArea.Margin = new System.Windows.Forms.Padding(4);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(280, 280);
            this.drawingArea.TabIndex = 4;
            this.drawingArea.TabStop = false;
            this.drawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseDown);
            this.drawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseMove);
            this.drawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseUp);
            // 
            // drawingAreaLabel
            // 
            this.drawingAreaLabel.AutoSize = true;
            this.drawingAreaLabel.Location = new System.Drawing.Point(12, 41);
            this.drawingAreaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.drawingAreaLabel.Name = "drawingAreaLabel";
            this.drawingAreaLabel.Size = new System.Drawing.Size(88, 16);
            this.drawingAreaLabel.TabIndex = 8;
            this.drawingAreaLabel.Text = "Drawing Area";
            // 
            // displayArea
            // 
            this.displayArea.BackColor = System.Drawing.SystemColors.Control;
            this.displayArea.Location = new System.Drawing.Point(34, 19);
            this.displayArea.Margin = new System.Windows.Forms.Padding(4);
            this.displayArea.Name = "displayArea";
            this.displayArea.Size = new System.Drawing.Size(280, 280);
            this.displayArea.TabIndex = 9;
            this.displayArea.TabStop = false;
            // 
            // displayAreaLabel
            // 
            this.displayAreaLabel.AutoSize = true;
            this.displayAreaLabel.Location = new System.Drawing.Point(7, 0);
            this.displayAreaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayAreaLabel.Name = "displayAreaLabel";
            this.displayAreaLabel.Size = new System.Drawing.Size(85, 16);
            this.displayAreaLabel.TabIndex = 10;
            this.displayAreaLabel.Text = "Display Area";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(562, 362);
            this.testBtn.Margin = new System.Windows.Forms.Padding(4);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(100, 55);
            this.testBtn.TabIndex = 12;
            this.testBtn.Text = "Testing Button";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // testBtn2
            // 
            this.testBtn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testBtn2.Location = new System.Drawing.Point(309, 362);
            this.testBtn2.Margin = new System.Windows.Forms.Padding(4);
            this.testBtn2.Name = "testBtn2";
            this.testBtn2.Size = new System.Drawing.Size(100, 55);
            this.testBtn2.TabIndex = 14;
            this.testBtn2.Text = "Who\'s that pokemon?";
            this.testBtn2.UseVisualStyleBackColor = true;
            this.testBtn2.Click += new System.EventHandler(this.whatPokemon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 437);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // groupDisplay
            // 
            this.groupDisplay.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupDisplay.Controls.Add(this.displayArea);
            this.groupDisplay.Controls.Add(this.displayAreaLabel);
            this.groupDisplay.Location = new System.Drawing.Point(309, 41);
            this.groupDisplay.Name = "groupDisplay";
            this.groupDisplay.Size = new System.Drawing.Size(353, 314);
            this.groupDisplay.TabIndex = 17;
            this.groupDisplay.TabStop = false;
            // 
            // showDisplayBox
            // 
            this.showDisplayBox.AutoSize = true;
            this.showDisplayBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.showDisplayBox.Checked = true;
            this.showDisplayBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDisplayBox.Location = new System.Drawing.Point(562, 436);
            this.showDisplayBox.Name = "showDisplayBox";
            this.showDisplayBox.Size = new System.Drawing.Size(111, 20);
            this.showDisplayBox.TabIndex = 19;
            this.showDisplayBox.Text = "Show Display";
            this.showDisplayBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showDisplayBox.UseVisualStyleBackColor = false;
            this.showDisplayBox.CheckedChanged += new System.EventHandler(this.showDisplayBox_CheckedChanged);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 490);
            this.Controls.Add(this.showDisplayBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testBtn2);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.drawingAreaLabel);
            this.Controls.Add(this.submitDrawingBtn);
            this.Controls.Add(this.clearDrawingBtn);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupDisplay);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.Text = "MDIParent1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayArea)).EndInit();
            this.groupDisplay.ResumeLayout(false);
            this.groupDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button clearDrawingBtn;
        private System.Windows.Forms.Button submitDrawingBtn;
        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Label drawingAreaLabel;
        private System.Windows.Forms.PictureBox displayArea;
        private System.Windows.Forms.Label displayAreaLabel;
        private System.Windows.Forms.ToolStripMenuItem loadMNISTCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMNISTCSVtestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMNISTByteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMNISTBytetestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTMNISTCSVToolStripMenuItem;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.ToolStripMenuItem activationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sigmoidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reLUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siLUToolStripMenuItem;
        private System.Windows.Forms.Button testBtn2;
        private System.Windows.Forms.ToolStripMenuItem weightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createWeightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useExistingWeightsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupDisplay;
        private System.Windows.Forms.CheckBox showDisplayBox;
    }
}



