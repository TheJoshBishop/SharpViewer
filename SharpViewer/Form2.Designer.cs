
namespace SharpViewer
{
    partial class splashscreen
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
            this.angryface = new System.Windows.Forms.PictureBox();
            this.loading = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.angryface)).BeginInit();
            this.SuspendLayout();
            // 
            // angryface
            // 
            this.angryface.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.angryface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.angryface.Image = global::SharpViewer.Properties.Resources.loading1;
            this.angryface.Location = new System.Drawing.Point(89, 12);
            this.angryface.Name = "angryface";
            this.angryface.Size = new System.Drawing.Size(609, 267);
            this.angryface.TabIndex = 0;
            this.angryface.TabStop = false;
            // 
            // loading
            // 
            this.loading.Location = new System.Drawing.Point(172, 368);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(434, 23);
            this.loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loading.TabIndex = 1;
            // 
            // splashscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.angryface);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "splashscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.splashscreen_Load);
            this.Shown += new System.EventHandler(this.splashscreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.angryface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox angryface;
        private System.Windows.Forms.ProgressBar loading;
    }
}