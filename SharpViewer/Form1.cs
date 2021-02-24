using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SharpViewer
{
    public partial class Form1 : Form
    {

        List<Bitmap> images;
        string[] rawFiles;
        string folderDirectory = "";
        
            
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(splashscreen));
            t.Start();
            Thread.Sleep(6000);
            InitializeComponent();
            t.Abort();
        }

        public void splashscreen()
        {
            Application.Run(new splashscreen());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {

            Text = ":)";
         
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            Text = ":D";
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                lblImgName.Text = openDialog.SafeFileName;

                imgLoaded.Image = new Bitmap(openDialog.FileName);

                folderDirectory = Path.GetDirectoryName(openDialog.FileName);

                rawFiles = Directory.GetFiles(folderDirectory);
                
                openDialog.Dispose();

                btnLeft.Enabled = true;
                btnRight.Enabled = true;
            }
        }

        bool IsCorrectFileType(string file)
        {
            if (file.Contains(".jpg") || file.Contains(".png") || file.Contains(".bmp") || file.Contains(".jpeg"))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        void GotoNextImage()
        {
            //Increase the index for the images array?
        }
        void GotoPreviousImage()
        {
            //Decrerase the index for the images array?
        }

        Bitmap[] getImages(string directory)//This might not be necessary...
        {
            // pull the images from the folder based on the directory given
            return new Bitmap[0];
            //This is a test comment for github commits
            //This is another test comment for github commits
        }
    }
}

