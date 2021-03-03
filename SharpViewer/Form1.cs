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
    //Fix bug where the goto next or prev image snaps to the first or second image
    //Get the main window to use saved data from the options window
    //Fix the filtering for the files

    public partial class main : Form
    {

        Bitmap[] images;                //Stores the images themselves
        string[] rawFiles;              //Stores the string paths to each of the files in the folder
        List<string> rawImgFiles = new List<string>();      //Stores the string paths to each of the files that are images
        string folderDirectory = "";    //Stores the directory for the folder all the images are in
        int imgIndex = 0;               //Index for the current selected image in the images array
        bool imgOpened = false;         //Keeps track of whether we've opened an image yet or not
        bool choice = false;
            
        public main()
        {  if (choice = true)
                {
                //Starts the program with the splashscreen, waits 6 seconds, then opens the program.
                Thread t = new Thread(new ThreadStart(splashscreen));
                t.Start();
                Thread.Sleep(6000);
                t.Abort();
            }
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;// checks if the form is Minimized
            this.Show(); //shows the image
            this.WindowState = FormWindowState.Normal;//makes it show up in front of any background programs
            
        }

        public void splashscreen()
        {
            //Opens the splashscreen
            Application.Run(new splashscreen());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Some setup when the program loads
            this.KeyPreview = true;         //Lets the keyboard input actually be read
            btnLeft.Enabled = false;        //Disables btnLeft
            btnRight.Enabled = false;       //Disables btnRight

            this.TopMost = true;    //Sets the window on top of the screen

            //Loops through the controls and sets PreviewKeyDown to true if the keys are the arrowKeys
            foreach (Control control in this.Controls)
            {
                //Adds the event to the current control
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //If we press the 'next' button...
            if (e.KeyCode==Keys.Right || e.KeyCode == Keys.N)
            {
                GotoNextImage();
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.L) //If we press the previous button...
            {
                GotoPreviousImage();
            }
        }

        //Checks if the button pressed is the arrowkeys, and returns IsInputKey = true if that's the case
        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;

            }
        }

        //If the left on-screen button is clicked...
        public void btnLeft_Click(object sender, EventArgs e)
        {
            GotoPreviousImage();
        }
        //If the right on-screen button is clicked...
        public void btnRight_Click(object sender, EventArgs e)
        {
            GotoNextImage();
        }

        //When the openFile menu button is clicked...
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            //Creates an OpenFileDialog
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "All Image Types|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif|BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";

            //If we press the OK button
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                lblImgName.Text = openDialog.SafeFileName;      //Sets the lable to the opened file's name

                imgLoaded.Image = new Bitmap(openDialog.FileName);  //Creates a Bitmap from that file based on the directory

                folderDirectory = Path.GetDirectoryName(openDialog.FileName);   //Gets the folder directory from that image's directory (minus the image name)

                rawFiles = Directory.GetFiles(folderDirectory);     //Gets the string directories for all the files in the folder

                foreach (string file in rawFiles)
                {
                    if (IsCorrectFileType(file))
                    {
                        rawImgFiles.Add(file);
                    }
                }
                images = new Bitmap[rawImgFiles.Count];

                for (int i = 0; i < images.Length; i++)
                {
                    images[i] = new Bitmap(rawImgFiles[i]);
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
                    numberImagesinFolder.Text = imgIndex+1 + " of " + images.Length;
                }
                else
                {
                    imgIndex++;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                imgLoaded.Image = images[imgIndex];
                lblImgName.Text = Path.GetFileName(rawImgFiles[imgIndex]);
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
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                else
                {
                    imgIndex--;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                imgLoaded.Image = images[imgIndex];
                lblImgName.Text = Path.GetFileName(rawImgFiles[imgIndex]);
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

