namespace ToolGK.Views.Layout
{
    partial class ExportLoginMypageLog
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
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.lblSelectFolder = new System.Windows.Forms.Label();
            this.tbPathSave = new System.Windows.Forms.TextBox();
            this.btnBrowseSave = new System.Windows.Forms.Button();
            this.lblPathSave = new System.Windows.Forms.Label();
            this.ofdPathSaveFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdFolderLogs = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(377, 52);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 0;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.BtnBrowseFolder_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(213, 218);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(139, 54);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(232, 20);
            this.tbFolder.TabIndex = 2;
            // 
            // lblSelectFolder
            // 
            this.lblSelectFolder.AutoSize = true;
            this.lblSelectFolder.Location = new System.Drawing.Point(58, 57);
            this.lblSelectFolder.Name = "lblSelectFolder";
            this.lblSelectFolder.Size = new System.Drawing.Size(58, 13);
            this.lblSelectFolder.TabIndex = 3;
            this.lblSelectFolder.Text = "Folder logs";
            // 
            // tbPathSave
            // 
            this.tbPathSave.Location = new System.Drawing.Point(139, 104);
            this.tbPathSave.Name = "tbPathSave";
            this.tbPathSave.Size = new System.Drawing.Size(232, 20);
            this.tbPathSave.TabIndex = 4;
            // 
            // btnBrowseSave
            // 
            this.btnBrowseSave.Location = new System.Drawing.Point(377, 102);
            this.btnBrowseSave.Name = "btnBrowseSave";
            this.btnBrowseSave.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSave.TabIndex = 5;
            this.btnBrowseSave.Text = "Browse...";
            this.btnBrowseSave.UseVisualStyleBackColor = true;
            this.btnBrowseSave.Click += new System.EventHandler(this.BtnBrowseSave_Click);
            // 
            // lblPathSave
            // 
            this.lblPathSave.AutoSize = true;
            this.lblPathSave.Location = new System.Drawing.Point(13, 107);
            this.lblPathSave.Name = "lblPathSave";
            this.lblPathSave.Size = new System.Drawing.Size(103, 13);
            this.lblPathSave.TabIndex = 6;
            this.lblPathSave.Text = "Path save file export";
            // 
            // ofdPathSaveFile
            // 
            this.ofdPathSaveFile.FileName = "openFileDialog1";
            // 
            // ExportLoginMypageLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPathSave);
            this.Controls.Add(this.btnBrowseSave);
            this.Controls.Add(this.tbPathSave);
            this.Controls.Add(this.lblSelectFolder);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBrowseFolder);
            this.Name = "ExportLoginMypageLog";
            this.Size = new System.Drawing.Size(472, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Label lblSelectFolder;
        private System.Windows.Forms.TextBox tbPathSave;
        private System.Windows.Forms.Button btnBrowseSave;
        private System.Windows.Forms.Label lblPathSave;
        private System.Windows.Forms.OpenFileDialog ofdPathSaveFile;
        private System.Windows.Forms.FolderBrowserDialog fbdFolderLogs;
    }
}
