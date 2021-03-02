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
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            app.Settings.Add("ShowSplash", splashscreenEnabled.Checked.ToString());
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            string _check = ConfigurationManager.AppSettings["ShowSplash"];
            if (_check != null)
            {
                splashscreenEnabled.Checked = bool.Parse(_check);
            }
        }
    }
}
