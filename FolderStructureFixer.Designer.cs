namespace FolderStructureFixer
{
    partial class FolderStructureFixer
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.curStatLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.browseBtn = new System.Windows.Forms.Button();
            this.fixBtn = new System.Windows.Forms.Button();
            this.bmsFolderLbl = new System.Windows.Forms.Label();
            this.bmsPathBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curStatLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 131);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // curStatLbl
            // 
            this.curStatLbl.Name = "curStatLbl";
            this.curStatLbl.Size = new System.Drawing.Size(244, 17);
            this.curStatLbl.Text = "BMS Folder Structure Fixer v0.1 by futotorofu";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(425, 27);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // fixBtn
            // 
            this.fixBtn.Location = new System.Drawing.Point(12, 56);
            this.fixBtn.Name = "fixBtn";
            this.fixBtn.Size = new System.Drawing.Size(488, 72);
            this.fixBtn.TabIndex = 2;
            this.fixBtn.Text = "Fix!";
            this.fixBtn.UseVisualStyleBackColor = true;
            this.fixBtn.Click += new System.EventHandler(this.fixBtn_Click);
            // 
            // bmsFolderLbl
            // 
            this.bmsFolderLbl.AutoSize = true;
            this.bmsFolderLbl.Location = new System.Drawing.Point(12, 9);
            this.bmsFolderLbl.Name = "bmsFolderLbl";
            this.bmsFolderLbl.Size = new System.Drawing.Size(97, 15);
            this.bmsFolderLbl.TabIndex = 3;
            this.bmsFolderLbl.Text = "BMS Folder path:";
            // 
            // bmsPathBox
            // 
            this.bmsPathBox.Location = new System.Drawing.Point(12, 27);
            this.bmsPathBox.Name = "bmsPathBox";
            this.bmsPathBox.Size = new System.Drawing.Size(407, 23);
            this.bmsPathBox.TabIndex = 4;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FolderStructureFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 153);
            this.Controls.Add(this.bmsPathBox);
            this.Controls.Add(this.bmsFolderLbl);
            this.Controls.Add(this.fixBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FolderStructureFixer";
            this.Text = "BMS Folder Structure Fixer v0.1";
            this.Load += new System.EventHandler(this.FolderStructureFixerForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel curStatLbl;
        private Button browseBtn;
        private Button fixBtn;
        private Label bmsFolderLbl;
        private TextBox bmsPathBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}