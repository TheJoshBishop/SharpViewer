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
    public partial class splashscreen : Form
    {//initalizes the splashscreen
        public splashscreen()
        {
            InitializeComponent();
        }

        //creates a timer
        Timer tmr;

        private void splashscreen_Shown(object sender, EventArgs e)

        {

            tmr = new Timer();


            //sets timer to 6 seconds 
            tmr.Interval = 6000;

            //starts the timer

            tmr.Start();
            //creates timer progress
            tmr.Tick += tmr_Tick;

        }

        void tmr_Tick(object sender, EventArgs e)

        {

            //after 6 sec stop the timer

            tmr.Stop();
           
            //hides the splashscreen
            this.Hide();

        }

        private void splashscreen_Load(object sender, EventArgs e)
        {

        }
    }
}
