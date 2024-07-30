namespace ToolGK.Views.Layout
{
    partial class ExportDatabase
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
            this.tbTXT = new System.Windows.Forms.TextBox();
            this.tbXLS = new System.Windows.Forms.TextBox();
            this.btnTXT = new System.Windows.Forms.Button();
            this.btnXLS = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdTXT = new System.Windows.Forms.OpenFileDialog();
            this.ofdXLS = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tbTXT
            // 
            this.tbTXT.Enabled = false;
            this.tbTXT.Location = new System.Drawing.Point(120, 20);
            this.tbTXT.Multiline = true;
            this.tbTXT.Name = "tbTXT";
            this.tbTXT.Size = new System.Drawing.Size(275, 82);
            this.tbTXT.TabIndex = 0;
            // 
            // tbXLS
            // 
            this.tbXLS.Enabled = false;
            this.tbXLS.Location = new System.Drawing.Point(120, 108);
            this.tbXLS.Multiline = true;
            this.tbXLS.Name = "tbXLS";
            this.tbXLS.Size = new System.Drawing.Size(275, 82);
            this.tbXLS.TabIndex = 1;
            // 
            // btnTXT
            // 
            this.btnTXT.Location = new System.Drawing.Point(401, 18);
            this.btnTXT.Name = "btnTXT";
            this.btnTXT.Size = new System.Drawing.Size(75, 23);
            this.btnTXT.TabIndex = 2;
            this.btnTXT.Text = "Browser...";
            this.btnTXT.UseVisualStyleBackColor = true;
            this.btnTXT.Click += new System.EventHandler(this.BtnTXT_Click);
            // 
            // btnXLS
            // 
            this.btnXLS.Location = new System.Drawing.Point(401, 106);
            this.btnXLS.Name = "btnXLS";
            this.btnXLS.Size = new System.Drawing.Size(75, 23);
            this.btnXLS.TabIndex = 3;
            this.btnXLS.Text = "Browser...";
            this.btnXLS.UseVisualStyleBackColor = true;
            this.btnXLS.Click += new System.EventHandler(this.BtnXLS_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(221, 244);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TXT File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Excel File";
            // 
            // ExportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnXLS);
            this.Controls.Add(this.btnTXT);
            this.Controls.Add(this.tbXLS);
            this.Controls.Add(this.tbTXT);
            this.Name = "ExportGKDB";
            this.Size = new System.Drawing.Size(547, 353);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTXT;
        private System.Windows.Forms.TextBox tbXLS;
        private System.Windows.Forms.Button btnTXT;
        private System.Windows.Forms.Button btnXLS;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdTXT;
        private System.Windows.Forms.OpenFileDialog ofdXLS;
    }
}
