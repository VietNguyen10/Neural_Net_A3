using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    /// <summary>
    /// MNISTLoader class
    /// Handles loading of MNIST dataset files and converting to usable format.
    /// </summary>
    internal class MNISTLoader
    {
        public static (double[][], int[]) LoadDataset(string imagesFilePath, string labelsFilePath)
        {
            int[][] images = LoadImages(imagesFilePath);
            int[] labels = LoadLabels(labelsFilePath);

            // Convert images to double array and normalize pixel values
            double[][] normalizedImages = NormalizeImages(images);

            return (normalizedImages, labels);
        }

        private static int[][] LoadImages(string filePath)
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

        private static int[] LoadLabels(string filePath)
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

        private static double[][] NormalizeImages(int[][] images)
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

        private static int SwapEndianness(int value)
        {
            return (int)(((uint)(value & 0x000000FF) << 24) |
                         ((uint)(value & 0x0000FF00) << 8) |
                         ((uint)(value & 0x00FF0000) >> 8) |
                         ((uint)(value & 0xFF000000) >> 24));
        }

    }
}
