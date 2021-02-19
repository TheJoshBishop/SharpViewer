using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpViewer
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = ":D";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Text = ":)";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Text = ":D";
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //This is a test comment for github commits
                //This is another test comment for github commits
            }
        }
    }
}
