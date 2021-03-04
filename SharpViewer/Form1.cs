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
    

    public partial class main : Form
    {

        Bitmap[] images;                //Stores the images themselves
        string[] rawFiles;              //Stores the string paths to each of the files in the folder
        List<string> rawImgFiles = new List<string>();      //Stores the string paths to each of the files that are images
        string folderDirectory = "";    //Stores the directory for the folder all the images are in
        int imgIndex = 0;               //Index for the current selected image in the images array
        bool imgOpened = false;         //Keeps track of whether we've opened an image yet or not
        int size;
            
        public main()
        {  
            if (Properties.Settings.Default.ShowSplash == true)
            {
                //Starts the program with the splashscreen, waits 6 seconds, then opens the program.
                Thread t = new Thread(new ThreadStart(splashscreen));
                t.Start();
                Thread.Sleep(6000);
                t.Abort();
            }

            InitializeComponent();
            size = this.Width - imgLoaded.Width;
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

            //Checks the settings to see if the darkmode setting is enabled
            if (Properties.Settings.Default.DarkMode == true)
            {
                EnableDarkMode();   //Enable dark mode
            }
            else
            {
                DisableDarkMode();  //Disable dark mode
            }
        }

        //Does the changes for dark mode.
        void EnableDarkMode()
        {
            this.BackColor = Color.FromArgb(50, 50, 50);        //Changes the back color of the window
            menuStrip1.BackColor = Color.FromArgb(60, 60, 60);  //Changes the back color of the menu strip
            //Loops through all the elements to change the text color
            foreach (Control c in this.Controls)
            {
                //Changes the forecolor for each element
                c.ForeColor = SystemColors.ControlLightLight;
            }
        }

        //Changes back to the default colors
        void DisableDarkMode()
        {
            this.BackColor = SystemColors.Control;          //Changes the back color of the window
            menuStrip1.BackColor = SystemColors.Control;    //Changes the back color of the menu strip
            //Loops through all the elements to change the text color
            foreach (Control c in this.Controls)
            {
                //Changes the forecolor for each element
                c.ForeColor = SystemColors.ControlText;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //If we press the 'next' button...
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.N)
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

            if (Properties.Settings.Default.KeepDir == true)
            {
                if (Properties.Settings.Default.LastDir != null)
                {
                    openDialog.InitialDirectory = Properties.Settings.Default.LastDir;
                }
            }

            openDialog.Filter = "All Image Types|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif|BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";

            //If we press the OK button
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                rawFiles = null;
                rawImgFiles = new List<string>();
                lblImgName.Text = openDialog.SafeFileName;      //Sets the lable to the opened file's name

                imgLoaded.Image = new Bitmap(openDialog.FileName);  //Creates a Bitmap from that file based on the directory

                folderDirectory = Path.GetDirectoryName(openDialog.FileName);   //Gets the folder directory from that image's directory (minus the image name)

                Properties.Settings.Default.LastDir = folderDirectory;
                Properties.Settings.Default.Save();

                rawFiles = Directory.GetFiles(folderDirectory);     //Gets the string directories for all the files in the folder

                //Goes through each directory in the list
                foreach (string file in rawFiles)
                {
                    //checks that the file directory contains the proper extension type
                    if (IsCorrectFileType(file))
                    {
                        //Adds the file to the list that only contains images
                        rawImgFiles.Add(file);
                    }
                }
                images = new Bitmap[rawImgFiles.Count]; //Sets the bitmap array to the same length of the rawImgFiles array

                //Loops through each image in the rawImgFile list and creates a new Bitmap for each entry in the list
                for (int i = 0; i < images.Length; i++)
                {
                    images[i] = new Bitmap(rawImgFiles[i]);     //Creates a Bitmap at position 'i' with the rawImgFiles[i] data
                }

                //Closes the openDialog
                openDialog.Dispose();

                //Enables the buttons for clicking
                btnLeft.Enabled = true;
                btnRight.Enabled = true;

                //Sets the imgOpened true for reference in other parts of the code
                imgOpened = true;

                //Loops through all the images to see what the image index of the opened image happens to be
                for (int i = 0; i < rawImgFiles.Count; i++)
                {
                    //Compares the name of the opened image to each entry
                    if (openDialog.FileName == rawImgFiles[i])
                    {
                        imgIndex = i;
                        numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;  //Sets the counter text to whatever the index is
                    }
                }
            }
        }

        //Checks the string to see if it contains the correct file type extension
        bool IsCorrectFileType(string file)
        {
            //Big ol' if statement
            if (file.Contains(".jpg") || file.Contains(".png") || file.Contains(".bmp") || file.Contains(".jpeg") || file.Contains(".gif") || file.Contains(".tif"))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        //Goes to next image by increasing the imgIndex
        void GotoNextImage()
        {
            //Checks that an image is opened
            if (imgOpened == true)
            {
                //Checks whether the imgIndex is at the maximum value for the array
                if (imgIndex >= images.Length - 1)
                {
                    //If it is, go back to zero to loop back
                    imgIndex = 0;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                else
                {
                    //Otherwise, keep increasing the imgIndex
                    imgIndex++;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                imgLoaded.Image = images[imgIndex];         //Sets the image on the screen to the current image based on the index
                lblImgName.Text = Path.GetFileName(rawImgFiles[imgIndex]);      //Displays the image name
            }
            else
            {
                //If the image isn't even opened yet, do nothing.
                return;
            }

            //Increase the index for the images array?
        }
        //Goes to previous image by decreasing the imgIndex
        void GotoPreviousImage()
        {
            //Checks that an image has been opened
            if (imgOpened == true)
            {
                //Checks if the index is going below zero if we proceed
                if (imgIndex - 1 < 0)
                {
                    //If it is, then loop back to the final index value, to loop back to the end of the folder
                    imgIndex = images.Length - 1;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                else
                {
                    //Otherwise, keep decreasing the index.
                    imgIndex--;
                    numberImagesinFolder.Text = imgIndex + 1 + " of " + images.Length;
                }
                imgLoaded.Image = images[imgIndex];         //Sets the image on the screen to the current image based on the index
                lblImgName.Text = Path.GetFileName(rawImgFiles[imgIndex]);      //Displays the image name
            }
            else
            {
                //If an image isn't even opened yet, do nothing.
                return;
            }
        }

        //Event to open the Options Window
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creates the options Window, then shows it.
            OptionsWindow ow = new OptionsWindow();
            ow.Show();
        }

        //Checks that the window's size doesn't get too small, at the start of the resizing
        private void main_Resize(object sender, EventArgs e)
        {
            imgLoaded.Width = this.Width - size;
            imgLoaded.Height = this.Height - size;
        }

        //Also checks that the window's size doesn't get too small, at the end of the resizing
        private void main_ResizeEnd(object sender, EventArgs e)
        {
            imgLoaded.Width = this.Width - size;
            imgLoaded.Height = this.Height - size;
        }
    }
}

