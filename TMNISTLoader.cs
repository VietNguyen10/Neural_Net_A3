using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal class TMNISTLoader
    {
        private readonly string _filePath = "../../94_character_TMNIST.csv";

        public (double[][], string[]) LoadTMNISTCSV()
        {
            // Read lines from CSV file
            string[] lines = File.ReadAllLines(_filePath).Skip(1).ToArray();

            // Extract labels and images from lines
            string[] labels = lines.Select(line => line.Split(',')[1]).ToArray();
            double[][] images = lines.Select(line => line.Split(',').Skip(2).Select(x => double.Parse(x.Trim()) / 255.0).ToArray()).ToArray();

            return (images, labels);
        }
    }
}
