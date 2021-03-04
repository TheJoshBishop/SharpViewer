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
        }

        void SaveData()
        {
            //Goes through each of the settings set in the Settings file, and sets them to the values based on the check boxes.
            Properties.Settings.Default.ShowSplash = splashscreenEnabled.Checked;   //Data for the splashscreen
            Properties.Settings.Default.KeepDir = keepDirectory.Checked;            //Data for the rememberDirectory option
            Properties.Settings.Default.DarkMode = HaveDarkMode.Checked;            //Data for darkMode
            Properties.Settings.Default.Save();     //And saves them
        }

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            //Loads the user data
            LoadData();
        }

        void LoadData()
        {
            //Goes through each of the settings in the Settings file, and sets the check boxes' values to the corresponding data
            splashscreenEnabled.Checked = Properties.Settings.Default.ShowSplash;   //Data for the splashscreen
            keepDirectory.Checked = Properties.Settings.Default.KeepDir;            //Data for the rememberDirectory option
            HaveDarkMode.Checked = Properties.Settings.Default.DarkMode;            //Data for darkMode

            //Checks whether dark mode is enabled or disabled
            if (Properties.Settings.Default.DarkMode == true)
            {
                EnableDarkMode();   //Enables dark mode
            }
            else
            {
                DisableDarkMode();  //Disables dark mode
            }
        }

        //Does changes for dark mode
        void EnableDarkMode()
        {
            this.BackColor = Color.FromArgb(50, 50, 50);    //Sets the back color for the window to the dark color
            //Loops through each control and sets the forecolor to a lighter color, and sets the buttons to a darker color
            foreach (Control c in this.Controls)
            {
                c.ForeColor = SystemColors.ControlLightLight;   //Sets the text color
                if (c is Button)    //Checks if it's a button
                {
                    c.BackColor = Color.FromArgb(60, 60, 60);   //Sets the button's color
                }
            }
        }

        //Does changes for light mode
        void DisableDarkMode()
        {
            this.BackColor = SystemColors.Control;  //Sets the back color for the window to a lighter color
            //Loops through each element and sets the forecolor to a darker color, and makes the button ligher.
            foreach (Control c in this.Controls)
            {
                c.ForeColor = SystemColors.ControlText;     //Sets the text color
                if (c is Button)    //Checks if it's a button
                {
                    c.BackColor = SystemColors.Control; //Sets the button's color
                }
            }
        }
    }
}