namespace NetSatis.Update
{
    partial class FrmGuncelleme
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
            this.btnIndir = new DevExpress.XtraEditors.SimpleButton();
            this.progressFile = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblIndirilenVeri = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIndir
            // 
            this.btnIndir.Location = new System.Drawing.Point(187, 12);
            this.btnIndir.Name = "btnIndir";
            this.btnIndir.Size = new System.Drawing.Size(163, 130);
            this.btnIndir.TabIndex = 0;
            this.btnIndir.Text = "Güncellemeyi İndir";
            this.btnIndir.Click += new System.EventHandler(this.btnIndir_Click);
            // 
            // progressFile
            // 
            this.progressFile.Location = new System.Drawing.Point(12, 148);
            this.progressFile.Name = "progressFile";
            this.progressFile.Size = new System.Drawing.Size(551, 65);
            this.progressFile.TabIndex = 1;
            // 
            // lblIndirilenVeri
            // 
            this.lblIndirilenVeri.Location = new System.Drawing.Point(13, 220);
            this.lblIndirilenVeri.Name = "lblIndirilenVeri";
            this.lblIndirilenVeri.Size = new System.Drawing.Size(0, 13);
            this.lblIndirilenVeri.TabIndex = 2;
            // 
            // FrmGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 277);
            this.Controls.Add(this.lblIndirilenVeri);
            this.Controls.Add(this.progressFile);
            this.Controls.Add(this.btnIndir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGuncelleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güncelleme";
            ((System.ComponentModel.ISupportInitialize)(this.progressFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnIndir;
        private DevExpress.XtraEditors.ProgressBarControl progressFile;
        private DevExpress.XtraEditors.LabelControl lblIndirilenVeri;
    }
}

