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

        Bitmap[] images;
        string[] rawFiles;
        List<string> sRawFiles;
        string folderDirectory = "";
        int imgIndex = 0;
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

            sRawFiles = new List<string>();
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {

            Text = ":)";
            GotoPreviousImage();
            //this is async change
            //Wassap
            //yo
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            Text = ":D";
            GotoNextImage();
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                lblImgName.Text = openDialog.SafeFileName;

                imgLoaded.Image = new Bitmap(openDialog.FileName);

                folderDirectory = Path.GetDirectoryName(openDialog.FileName);

                foreach (string file in Directory.GetFiles(folderDirectory, "*.*", SearchOption.AllDirectories))
                {
                    if (IsCorrectFileType(file.ToLower()))
                    {
                        sRawFiles.Add(file);
                    }
                }

                Bitmap[] imgs = new Bitmap[sRawFiles.Count];
                images = imgs;

                for (int i = 0; i < images.Length; i++)
                {
                    images[i] = new Bitmap(sRawFiles[i]);
                }
                
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
            //Decrerase the index for the images array?
            if (imgIndex + 1 > images.Length - 1)
            {
                imgIndex = 0;
            }
            else
            {
                imgIndex++;
            }
            imgLoaded.Image = images[imgIndex];
        }
        void GotoPreviousImage()
        {
            //Decrerase the index for the images array?
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

        Bitmap[] getImages(string directory)//This might not be necessary...
        {
            // pull the images from the folder based on the directory given
            return new Bitmap[0];
            //This is a test comment for github commits
            //This is another test comment for github commits
        }
    }
}

