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

        Bitmap[] images;
        string[] rawFiles;
        string folderDirectory = "";
        int imgIndex = 0;
        bool imgOpened = false;
        
            
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

            this.TopMost = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right || e.KeyCode == Keys.N)
            {
                GotoNextImage();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.L)
            {
                GotoPreviousImage();
            }
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {
            GotoPreviousImage();
            Text = ":)";
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            GotoNextImage();
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
                images = new Bitmap[rawFiles.Length];

                for (int i = 0; i < images.Length; i++)
                {
                    if (IsCorrectFileType(rawFiles[i]))
                    {
                        images[i] = new Bitmap(rawFiles[i]);
                    }
                }
                
                openDialog.Dispose();

                btnLeft.Enabled = true;
                btnRight.Enabled = true;

                imgOpened = true;
            }
        }

        bool IsCorrectFileType(string file)
        {
            if (file.Contains(".jpg") || file.Contains(".png") || file.Contains(".bmp") || file.Contains(".jpeg") || file.Contains(".gif"))
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
            if (imgOpened == true)
            {
                if (imgIndex >= images.Length - 1)
                {
                    imgIndex = 0;
                }
                else
                {
                    imgIndex++;
                }
                imgLoaded.Image = images[imgIndex];
            }
            else
            {
                return;
            }
            
            //Increase the index for the images array?
        }
        void GotoPreviousImage()
        {
            //Decrerase the index for the images array?
            if (imgOpened == true)
            {
                if (imgIndex - 1 < 0)
                {
                    imgIndex = images.Length - 1;
                }
                else
                {
                    imgIndex--;
                }
                imgLoaded.Image = images[imgIndex];
            }
            else
            {
                return;
            }
        }

        Bitmap[] getImages(string directory)//This might not be necessary...
        {
            // pull the images from the folder based on the directory given
            return new Bitmap[0];
            //This is a test comment for github commits
            //This is another test comment for github commits
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsWindow ow = new OptionsWindow();
            ow.Show();
        }
    }
}

