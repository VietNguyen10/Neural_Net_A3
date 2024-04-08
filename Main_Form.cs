using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace NeuralNet
{
    /// <summary>
    /// Main_Form class
    /// Ties project logic into Main_Form GUI
    /// </summary>
    public partial class Main_Form : Form
    {
        //Counter for the number of child forms
        private int childFormNumber = 0;

        //Drawing variables
        private Bitmap drawnBitmap;
        private Graphics drawnGraphics;
        private bool isDrawing = false;
        private Point previousPoint;
        readonly private Pen drawingPen = new Pen(Brushes.Black, 10);

        //Neural Network variables
        MNISTLoader mload = new MNISTLoader();
        TMNISTLoader tload = new TMNISTLoader();
        double[][] images = null;
        int[] labels = null;
        string[] labels_tmnist = null;

        //NeuralNet nn = new NeuralNet(new UInt16[]{784, 16, 16, 10}); // 784 input, 16 hidden, 16 hidden, 10 output (0-9 digits)

        public Main_Form()
        {
            InitializeComponent();
            InitializeDrawingArea();
        }

        private void InitializeDrawingArea()
        {
            drawnBitmap = new Bitmap(drawingArea.Width, drawingArea.Height);
            drawnGraphics = Graphics.FromImage(drawnBitmap);
            drawnGraphics.Clear(Color.White);
            drawingArea.Image = drawnBitmap;
            previousPoint = Point.Empty;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Drawing area functions
        /// </summary>

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = e.Location;
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // Calculate the circle coordinates
                int diameter = 2 * Math.Max(Math.Abs(e.X - previousPoint.X), Math.Abs(e.Y - previousPoint.Y));
                int x = e.X - diameter / 2;
                int y = e.Y - diameter / 2;

                using (Graphics bitmapGraphics = Graphics.FromImage(drawnBitmap))
                {
                    bitmapGraphics.DrawEllipse(drawingPen, x, y, diameter, diameter);
                }
                drawnGraphics.DrawEllipse(drawingPen, x, y, diameter, diameter);

                drawingArea.Invalidate();
                drawingArea.Update();
                previousPoint = e.Location;
            }
        }

        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        // Submits Drawing Area -- process to 28x28//
        private void submitDrawingBtn_Click(object sender, EventArgs e)
        {
            // Create a new Bitmap with size 28x28
            Bitmap resizedImage = new Bitmap(28, 28);
            float scaleX = (float)28 / drawnBitmap.Width;
            float scaleY = (float)28 / drawnBitmap.Height;


            // Get the graphics object of the resized image
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Clear the resized image with white background
                g.Clear(Color.White);

                g.ScaleTransform(scaleX, scaleY);
                g.DrawImage(drawnBitmap, new PointF(0, 0));
            }

            // Display the resized image in the displayPictureBox
            if (displayArea.Image != null)
            {
                displayArea.Image.Dispose();
            }
            drawnBitmap = resizedImage;

            displayDrawing();
        }

        // Clears the drawing area//
        private void clearDrawingBtn_Click(object sender, EventArgs e)
        {
            //Clears previous drawing
            drawnBitmap = new Bitmap(drawingArea.Width, drawingArea.Height);
            drawnGraphics.Clear(Color.White);
            drawingArea.Refresh();
        }

        private void displayDrawing()
        {
            // Create a new bitmap for the scaled drawing
            Bitmap scaledImage = new Bitmap(280, 280);

            // Clear the bitmap
            using (Graphics clearGraphics = Graphics.FromImage(scaledImage))
            {
                clearGraphics.Clear(Color.White); // Assuming you want to clear with white color
            }

            // Calculate the scaling factor for width and height
            int scaleFactorX = 280 / 28;
            int scaleFactorY = 280 / 28;

            // Draw the scaled pixels onto the bitmap
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                for (int y = 0; y < 28; y++)
                {
                    for (int x = 0; x < 28; x++)
                    {
                        // Get the pixel color from the input drawing
                        Color pixelColor = drawnBitmap.GetPixel(x, y);

                        // Calculate grayscale intensity using luminance formula
                        int intensity = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                        // Create grayscale color using calculated intensity
                        Color grayscaleColor = Color.FromArgb(intensity, intensity, intensity);

                        // Draw a scaled rectangle at the corresponding position
                        Rectangle rect = new Rectangle(x * scaleFactorX, y * scaleFactorY, scaleFactorX, scaleFactorY);
                        using (SolidBrush brush = new SolidBrush(grayscaleColor))
                        {
                            g.FillRectangle(brush, rect);
                        }
                    }
                }
            }
            displayArea.Image = scaledImage;
        }


        private void loadMNISTCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (images, labels) = mload.LoadMNISTCSV();
            MessageBox.Show("MNIST dataset loaded successfully.");
        }

        private void loadMNISTCSVtestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (images, labels) = mload.LoadMNISTCSV_test();
            MessageBox.Show("MNIST test loaded successfully.");
        }

        private void loadMNISTByteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (images, labels) = mload.LoadTrainingDataset();
            MessageBox.Show("MNIST dataset loaded successfully.");
        }

        private void loadMNISTBytetestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (images, labels) = mload.LoadTestingDataset();
            MessageBox.Show("MNIST test loaded successfully.");
        }

        private void loadTMNISTCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //(images, labels_tmnist) = tload.LoadTMNISTCSV();
            MessageBox.Show("TMNIST dataset is currently broken. DO NOT USE.");
        }

        //////////////////////////////Unused Status Bar items/////////////////////////////////

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        
    }
}
