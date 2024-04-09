using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using Accord.Math.Optimization.Losses;
using Accord.Neuro;
using Accord.MachineLearning;
using Accord.Imaging;
using Accord.Genetic;
using System.Numerics;
        
namespace NeuralNet
{
    /// <summary>
    /// MNISTLoader class
    /// Handles loading of MNIST dataset files and converting to usable format.
    /// </summary>
    internal class MNISTLoader
    {
        private readonly string _filePath = "../../mnist_train.csv";
        private readonly string _filePath_test = "../../mnist_test.csv";
        private string file_sm = "../../handwritten_digits_small.csv";
        private string file_m = "../../handwritten_digits_medium.csv";   
        private string file_l = "../../handwritten_digits_large.csv";   

        // File paths for MNIST dataset
        static string trainImagesPath = "../../train-images.idx3-ubyte";
        static string trainLabelsPath = "../../train-labels.idx1-ubyte";
        static string testImagesPath = "../../t10k-images.idx3-ubyte";
        static string testLabelsPath = "../../t10k-labels.idx1-ubyte";

        public MNISTLoader()
        {
            // Check if MNIST dataset files exist
            if ((!File.Exists(trainImagesPath) || !File.Exists(trainLabelsPath) || !File.Exists(testImagesPath) || !File.Exists(testLabelsPath)) && !File.Exists(_filePath))
            {
                throw new FileNotFoundException("MNIST dataset files not found.");
            }
        }

        public (double[][], int[]) LoadMNISTCSV()
        {
            //string[] lines = File.ReadAllLines(_filePath_test).Skip(1).ToArray();
            string[] lines = File.ReadAllLines(file_sm).Skip(1).ToArray();
            //string[] lines = File.ReadAllLines(file_m).Skip(1).ToArray();
            //string[] lines = File.ReadAllLines(file_l).Skip(1).ToArray();

            // Extract labels and images from lines
            int[] labels = lines.Select(line => int.Parse(line.Split(',')[0])).ToArray();
            double[][] images = lines.Select(line => line.Split(',').Skip(1).Select(x => double.Parse(x) / 255.0).ToArray()).ToArray();

            return (images, labels);
        }

        public (double[][], int[]) LoadMNISTCSV_test()
        {
            // Read lines from CSV file
            string[] lines = File.ReadAllLines(_filePath_test).Skip(1).ToArray();
           //string[] lines = File.ReadAllLines(file_sm).Skip(1).ToArray();
            //string[] lines = File.ReadAllLines(file_m).Skip(1).ToArray();
            //string[] lines = File.ReadAllLines(file_l).Skip(1).ToArray();


            // Extract labels and images from lines
            int[] labels = lines.Select(line => int.Parse(line.Split(',')[0])).ToArray();
            double[][] images = lines.Select(line => line.Split(',').Skip(1).Select(x => double.Parse(x) / 255.0).ToArray()).ToArray();

            return (images, labels);
        }


        public (double[][], int[]) LoadTrainingDataset()
        {
            int[][] images = LoadImages(trainImagesPath);
            int[] labels = LoadLabels(trainLabelsPath);

            // Convert images to double array and normalize pixel values
            double[][] normalizedImages = NormalizeImages(images);

            return (normalizedImages, labels);
        }
        public (double[][], int[]) LoadTestingDataset()
        {
            int[][] images = LoadImages(testImagesPath);
            int[] labels = LoadLabels(testLabelsPath);

            // Convert images to double array and normalize pixel values
            double[][] normalizedImages = NormalizeImages(images);

            return (normalizedImages, labels);
        }

        private int[][] LoadImages(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                // Read IDX file header
                int magicNumber = SwapEndianness(reader.ReadInt32());
                if (magicNumber != 2051)
                    throw new InvalidDataException("Invalid magic number for images IDX file.");

                int numImages = SwapEndianness(reader.ReadInt32());
                int numRows = SwapEndianness(reader.ReadInt32());
                int numCols = SwapEndianness(reader.ReadInt32());

                // Read image data
                int[][] images = new int[numImages][];
                for (int i = 0; i < numImages; i++)
                {
                    images[i] = new int[numRows * numCols];
                    for (int j = 0; j < numRows * numCols; j++)
                    {
                        images[i][j] = reader.ReadByte();
                    }
                }

                return images;
            }
        }

        private int[] LoadLabels(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                // Read IDX file header
                int magicNumber = SwapEndianness(reader.ReadInt32());
                if (magicNumber != 2049)
                    throw new InvalidDataException("Invalid magic number for labels IDX file.");

                int numLabels = SwapEndianness(reader.ReadInt32());

                // Read label data
                int[] labels = new int[numLabels];
                for (int i = 0; i < numLabels; i++)
                {
                    labels[i] = reader.ReadByte();
                }

                return labels;
            }
        }

        private double[][] NormalizeImages(int[][] images)
        {
            double[][] normalizedImages = new double[images.Length][];

            for (int i = 0; i < images.Length; i++)
            {
                normalizedImages[i] = new double[images[i].Length];
                for (int j = 0; j < images[i].Length; j++)
                {
                    normalizedImages[i][j] = images[i][j] / 255.0; // Normalize pixel values to [0, 1]
                }
            }

            return normalizedImages;
        }

        private int SwapEndianness(int value)
        {
            return (int)(((uint)(value & 0x000000FF) << 24) |
                         ((uint)(value & 0x0000FF00) << 8) |
                         ((uint)(value & 0x00FF0000) >> 8) |
                         ((uint)(value & 0xFF000000) >> 24));
        }

    }
}
