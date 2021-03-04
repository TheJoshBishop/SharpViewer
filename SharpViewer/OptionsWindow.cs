using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SharpViewer
{
    public partial class OptionsWindow : Form
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptionsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save the user data
            SaveData();
            //Test Comment
        }

        void SaveData()
        {
            Properties.Settings.Default.ShowSplash = splashscreenEnabled.Checked;
            Properties.Settings.Default.KeepDir = keepDirectory.Checked;
            Properties.Settings.Default.DarkMode = HaveDarkMode.Checked;
            Properties.Settings.Default.Save();
        }

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            splashscreenEnabled.Checked = Properties.Settings.Default.ShowSplash;
            keepDirectory.Checked = Properties.Settings.Default.KeepDir;
            HaveDarkMode.Checked = Properties.Settings.Default.DarkMode;

            if (Properties.Settings.Default.DarkMode == true)
            {
                EnableDarkMode();
            }
            else
            {
                DisableDarkMode();
            }
        }

        void EnableDarkMode()
        {
            this.BackColor = Color.FromArgb(50, 50, 50);
            foreach (Control c in this.Controls)
            {
                c.ForeColor = SystemColors.ControlLightLight;
                if (c is Button)
                {
                    c.BackColor = Color.FromArgb(60, 60, 60);
                }
            }
        }

        void DisableDarkMode()
        {
            this.BackColor = SystemColors.Control;
            foreach (Control c in this.Controls)
            {
                c.ForeColor = SystemColors.ControlText;
                if (c is Button)
                {
                    c.BackColor = SystemColors.Control;
                }
            }
        }
    }
}