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

namespace SharpViewer
{
    public partial class Form1 : Form
    {

        List<Bitmap> images;
        string[] rawFiles;
        string folderDirectory = "";
        public Form1()
        {
            splashscreen();

            InitializeComponent();
            //doesn't hurt to try again i suppose, if y'all got the time
            //do y'all want to chat on discord and see if we can figure out github?
            //im down if we all want to try i dont have much time but ill stay as long as can
            //noice
        }

        public void splashscreen()
        {
            //AppDomainInitializer()
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {

            Text = ":)";
            //this is async change
            //Wassap
            //yo
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            Text = ":D";
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                rawFiles = Directory.GetFiles(openDialog.FileName);

                foreach (string file in rawFiles)
                {
                    if (IsCorrectFileType(file))
                    {
                        //images.Add();
                    }
                }

                imgLoaded.Image = new Bitmap(openDialog.FileName);

                // set folderDirectory to whatever the image directory is
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

