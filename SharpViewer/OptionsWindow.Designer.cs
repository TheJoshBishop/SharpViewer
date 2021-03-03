
namespace SharpViewer
{
    partial class OptionsWindow
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
            this.splashscreenEnabled = new System.Windows.Forms.CheckBox();
            this.keepDirectory = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.HaveDarkMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // splashscreenEnabled
            // 
            this.splashscreenEnabled.AutoSize = true;
            this.splashscreenEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashscreenEnabled.Location = new System.Drawing.Point(99, 57);
            this.splashscreenEnabled.Name = "splashscreenEnabled";
            this.splashscreenEnabled.Size = new System.Drawing.Size(227, 24);
            this.splashscreenEnabled.TabIndex = 0;
            this.splashscreenEnabled.Text = "Show Splashscreen on start";
            this.splashscreenEnabled.UseVisualStyleBackColor = true;
            // 
            // keepDirectory
            // 
            this.keepDirectory.AutoSize = true;
            this.keepDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keepDirectory.Location = new System.Drawing.Point(99, 91);
            this.keepDirectory.Name = "keepDirectory";
            this.keepDirectory.Size = new System.Drawing.Size(258, 24);
            this.keepDirectory.TabIndex = 1;
            this.keepDirectory.Text = "Remember last opened directory";
            this.keepDirectory.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(441, 175);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // HaveDarkMode
            // 
            this.HaveDarkMode.AutoSize = true;
            this.HaveDarkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HaveDarkMode.Location = new System.Drawing.Point(99, 122);
            this.HaveDarkMode.Name = "HaveDarkMode";
            this.HaveDarkMode.Size = new System.Drawing.Size(356, 24);
            this.HaveDarkMode.TabIndex = 3;
            this.HaveDarkMode.Text = "Janky Dark Mode (enabled when next opened)";
            this.HaveDarkMode.UseVisualStyleBackColor = true;
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 207);
            this.Controls.Add(this.HaveDarkMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.keepDirectory);
            this.Controls.Add(this.splashscreenEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Options";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsWindow_FormClosing);
            this.Load += new System.EventHandler(this.OptionsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox splashscreenEnabled;
        private System.Windows.Forms.CheckBox keepDirectory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox HaveDarkMode;
    }
}