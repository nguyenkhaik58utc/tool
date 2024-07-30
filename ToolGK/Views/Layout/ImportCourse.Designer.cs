namespace ToolGK.Views.Layout
{
    partial class ImportCourse
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
            this.tbPathExcel = new System.Windows.Forms.TextBox();
            this.tbMaxLine = new System.Windows.Forms.TextBox();
            this.tbPathSql = new System.Windows.Forms.TextBox();
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.btnOpenSql = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.ofdSql = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tbPathExcel
            // 
            this.tbPathExcel.Enabled = false;
            this.tbPathExcel.Location = new System.Drawing.Point(182, 41);
            this.tbPathExcel.Name = "tbPathExcel";
            this.tbPathExcel.Size = new System.Drawing.Size(358, 22);
            this.tbPathExcel.TabIndex = 0;
            // 
            // tbMaxLine
            // 
            this.tbMaxLine.Location = new System.Drawing.Point(182, 103);
            this.tbMaxLine.Name = "tbMaxLine";
            this.tbMaxLine.Size = new System.Drawing.Size(100, 22);
            this.tbMaxLine.TabIndex = 1;
            // 
            // tbPathSql
            // 
            this.tbPathSql.Enabled = false;
            this.tbPathSql.Location = new System.Drawing.Point(182, 164);
            this.tbPathSql.Name = "tbPathSql";
            this.tbPathSql.Size = new System.Drawing.Size(358, 22);
            this.tbPathSql.TabIndex = 2;
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.AutoSize = true;
            this.btnOpenExcel.Location = new System.Drawing.Point(589, 41);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(81, 27);
            this.btnOpenExcel.TabIndex = 3;
            this.btnOpenExcel.Text = "Browser...";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.BtnOpenExcel_Click);
            // 
            // btnOpenSql
            // 
            this.btnOpenSql.AutoSize = true;
            this.btnOpenSql.Location = new System.Drawing.Point(589, 164);
            this.btnOpenSql.Name = "btnOpenSql";
            this.btnOpenSql.Size = new System.Drawing.Size(81, 27);
            this.btnOpenSql.TabIndex = 4;
            this.btnOpenSql.Text = "Browser...";
            this.btnOpenSql.UseVisualStyleBackColor = true;
            this.btnOpenSql.Click += new System.EventHandler(this.BtnOpenSql_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.Location = new System.Drawing.Point(329, 329);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 27);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "PathExcel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "MaxLine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "PathOutput";
            // 
            // ofdExcel
            // 
            this.ofdExcel.FileName = "openFileDialog1";
            // 
            // ofdSql
            // 
            this.ofdSql.FileName = "openFileDialog2";
            // 
            // ImportCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnOpenSql);
            this.Controls.Add(this.btnOpenExcel);
            this.Controls.Add(this.tbPathSql);
            this.Controls.Add(this.tbMaxLine);
            this.Controls.Add(this.tbPathExcel);
            this.Name = "ImportCourse";
            this.Size = new System.Drawing.Size(763, 466);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPathExcel;
        private System.Windows.Forms.TextBox tbMaxLine;
        private System.Windows.Forms.TextBox tbPathSql;
        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.Button btnOpenSql;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.OpenFileDialog ofdSql;
    }
}
