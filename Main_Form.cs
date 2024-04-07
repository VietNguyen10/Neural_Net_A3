using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNet
{
    /// <summary>
    /// Main_Form class
    /// Ties project logic into Main_Form GUI
    /// </summary>
    public partial class Main_Form : Form
    {

        // File paths for MNIST dataset
        string trainImagesPath = "../../train-images.idx3-ubyte";
        string trainLabelsPath = "../../train-labels.idx1-ubyte";
        string testImagesPath = "../../t10k-images.idx3-ubyte";
        string testLabelsPath = "../../t10k-labels.idx1-ubyte";

        //Counter for the number of child forms
        private int childFormNumber = 0;

        //Drawing variables
        private Bitmap drawnBitmap;
        private Graphics drawnGraphics;
        private bool isDrawing = false;
        private Point previousPoint;
        private Pen drawingPen = new Pen(Brushes.Black, 10);

        public Main_Form()
        {
            InitializeComponent();
            InitializeDrawingArea();

            // Load training dataset
            (double[][] trainImages, int[] trainLabels) = MNISTLoader.LoadDataset(trainImagesPath, trainLabelsPath);
            (double[][] testImages, int[] testLabels) = MNISTLoader.LoadDataset(testImagesPath, testLabelsPath);

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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Using cut tool as tester.
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeuralNet curNeuralNetwork = new NeuralNet(1, 3);

            Console.WriteLine("Synaptic weights before training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);

            var trainingInputs = new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 } };
            var trainingOutputs = NeuralNet.MatrixTranspose(new double[,] { { 0, 1, 1, 0 } });

            curNeuralNetwork.Train(trainingInputs, trainingOutputs, 10000);

            Console.WriteLine("\nSynaptic weights after training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);


            // testing neural networks against a new problem 
            var output = curNeuralNetwork.Think(new double[,] { { 1, 0, 0 } });
            Console.WriteLine("\nConsidering new problem [1, 0, 0] => :");
            PrintMatrix(output);

            Console.Read();
        }

        

        //Helper for printing the matrix
        static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
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
                        Color pixelColor = drawnBitmap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb() ? Color.Black : Color.White;

                        // Draw a scaled rectangle at the corresponding position
                        Rectangle rect = new Rectangle(x * scaleFactorX, y * scaleFactorY, scaleFactorX, scaleFactorY);
                        using (SolidBrush brush = new SolidBrush(pixelColor))
                        {
                            g.FillRectangle(brush, rect);
                        }
                    }
                }
            }
            displayArea.Image = scaledImage;
        }


        //////////////////////////////Unused Status Bar items/////////////////////////////////

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
