using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;


namespace NeuralNet
{
    /// <summary>
    /// Neural network class
    /// Used for training and "thinking" for the neural network.
    /// </summary>
    internal class NeuralNet
    {
        public int numLayers { get; set; }
        public Layer[] NetworkLayers { get; set; }
        public double[][][] Weights { get; set; }

        public NeuralNet(int[] numbersOfNeurons)
        {
            numLayers = numbersOfNeurons.Length;
            NetworkLayers = new Layer[numLayers];
            Weights = new double[numLayers - 1][][];
            for (int i = 0; i < numLayers; i++)
            {
                NetworkLayers[i] = new Layer(numbersOfNeurons[i]);
                if (i < numLayers - 1)
                {
                    Weights[i] = new double[numbersOfNeurons[i]][];
                    for (int j = 0; j < numbersOfNeurons[i]; j++)
                    {
                        Weights[i][j] = new double[numbersOfNeurons[i + 1]];
                    }
                }
            }
        }

        public void SetInput(double[] values)
        {
            for (int i = 0; i < NetworkLayers[0].Neurons.Length; i++)
            {
                NetworkLayers[0].Neurons[i].Value = values[i];
            }
        }

        public void ForwardFeed()
        {
            // Perform forward propagation through the network
            for (int k = 1; k < numLayers; k++)
            {
                for (int i = 0; i < NetworkLayers[k].Neurons.Length; i++)
                {
                    NetworkLayers[k].Neurons[i].Value = 0;

                    // Calculate the weighted sum of inputs to the current neuron from the previous layer
                    for (int j = 0; j < NetworkLayers[k - 1].Neurons.Length; j++)
                    {
                        NetworkLayers[k].Neurons[i].Value += NetworkLayers[k - 1].Neurons[j].Value * Weights[k - 1][j][i];
                    }

                    // Activate the neuron using its activation function
                    NetworkLayers[k].Neurons[i].Activation();
                }
            }
        }

        public void ForwardFeed(int layerNumber)
        {
            // Perform forward propagation for a specific layer
            for (int i = 0; i < NetworkLayers[layerNumber].Neurons.Length; i++)
            {
                NetworkLayers[layerNumber].Neurons[i].Value = 0;

                // Calculate the weighted sum of inputs to the current neuron from the previous layer
                for (int j = 0; j < NetworkLayers[layerNumber - 1].Neurons.Length; j++)
                {
                    NetworkLayers[layerNumber].Neurons[i].Value += NetworkLayers[layerNumber - 1].Neurons[j].Value * Weights[layerNumber - 1][j][i];
                }

                // Activate the neuron using its activation function
                NetworkLayers[layerNumber].Neurons[i].Activation();
            }
        }

        public void BackPropagation(int[] labels, double learningRate)
        {
            // Calculate errors for output layer neurons
            for (int i = 0; i < NetworkLayers[numLayers - 1].Neurons.Length; i++)
            {
                double[] expectedOutputs = GetExpectedOutputs(labels, i); // Get expected outputs for label i
                for (int j = 0; j < NetworkLayers[numLayers - 1].Neurons.Length; j++)
                {
                    NetworkLayers[numLayers - 1].Neurons[j].Error = NetworkLayers[numLayers - 1].Neurons[j].Value - expectedOutputs[j];
                }
            }

            // Backpropagate errors through the network
            for (int i = numLayers - 2; i >= 0; i--)
            {
                for (int j = 0; j < NetworkLayers[i].Neurons.Length; j++)
                {
                    double error = 0.0;
                    for (int k = 0; k < NetworkLayers[i + 1].Neurons.Length; k++)
                    {
                        error += NetworkLayers[i + 1].Neurons[k].Error * Weights[i][j][k];
                    }
                    NetworkLayers[i].Neurons[j].Error = error;
                }
            }

            // Update weights
            for (int i = 0; i < numLayers - 1; i++)
            {
                for (int j = 0; j < NetworkLayers[i].Neurons.Length; j++)
                {
                    for (int k = 0; k < NetworkLayers[i + 1].Neurons.Length; k++)
                    {
                        Weights[i][j][k] +=
                            learningRate *
                            NetworkLayers[i + 1].Neurons[k].Error *
                            SigmoidDerivative(NetworkLayers[i + 1].Neurons[k].Value * NetworkLayers[i].Neurons[j].Value);
                    }
                }
            }
        }


        private double[] GetExpectedOutputs(int[] labels, int neuronIndex)
        {
            double[] expectedOutputs = new double[NetworkLayers[numLayers - 1].Neurons.Length];
            for (int i = 0; i < labels.Length; i++)
            {
                if (neuronIndex == labels[i])
                    expectedOutputs[neuronIndex] = 1.0;
            }
            return expectedOutputs;
        }

        public static double SigmoidDerivative(double x)
        {
            if (Math.Abs(x - 1) < 1e-9 || Math.Abs(x) < 1e-9) return 0.0;
            double result = x * (1.0 - x);
            return result;
        }

        public int GetMaxNeuronIndex(int layerNumber)
        {
            double[] values = new double[NetworkLayers[layerNumber].Neurons.Length];
            Console.WriteLine("num of neurons in last layers: \n" + values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = NetworkLayers[layerNumber].Neurons[i].Value;
                Console.WriteLine(values[i] + "\n");
            }
            double maxValue = values.Max();
            return Array.IndexOf(values, maxValue);
        }

        public double MeanSquaredError(double[] predictedOutputs, double[] expectedOutputs)
        {
            double error = 0.0;
            for (int i = 0; i < predictedOutputs.Length; i++)
            {
                error += Math.Pow(predictedOutputs[i] - expectedOutputs[i], 2);
            }
            return error / predictedOutputs.Length;
        }

        /// <summary>
        /// Weight related
        /// </summary>
        public void SetRandomWeights()
        {
            Random rnd = new Random();
            for (int i = 0; i < numLayers - 1; i++)
            {
                Weights[i] = new double[NetworkLayers[i].Neurons.Length][];
                for (int j = 0; j < NetworkLayers[i].Neurons.Length; j++)
                {
                    Weights[i][j] = new double[NetworkLayers[i + 1].Neurons.Length];
                    for (int k = 0; k < NetworkLayers[i + 1].Neurons.Length; k++)
                    {
                        Weights[i][j][k] = rnd.Next(-100000, 100000) * 0.00002;
                    }
                }
            }
        }

        public void SaveWeightsToFile(string path)
        {
            string text = "";
            for (int i = 0; i < numLayers - 1; i++)
            {
                for (int j = 0; j < NetworkLayers[i].Neurons.Length; j++)
                {
                    for (int k = 0; k < NetworkLayers[i + 1].Neurons.Length; k++)
                    {
                        text += Weights[i][j][k] + " ";
                    }
                }
            }
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter stream = new StreamWriter(file))
                {
                    stream.Write(text);
                }
            }
        }

        public void LoadWeightsFromFile(string path)
        {
            string text = File.ReadAllText(path);
            string[] textWeights = text.Split(' ');
            int c = 0;
            for (int i = 0; i < numLayers - 1; i++)
            {
                for (int j = 0; j < NetworkLayers[i].Neurons.Length; j++)
                {
                    for (int k = 0; k < NetworkLayers[i + 1].Neurons.Length; k++)
                    {
                        Weights[i][j][k] = Convert.ToDouble(textWeights[c]);
                        c++;
                    }
                }
            }
        }

        public double CalculateMeanSquaredError(double[] predictedOutput, double[] targetOutput)
        {
            if (predictedOutput.Length != targetOutput.Length)
            {
                throw new ArgumentException("The length of predictedOutput and targetOutput must be the same.");
            }

            double sumSquaredError = 0.0;
            for (int i = 0; i < predictedOutput.Length; i++)
            {
                double error = predictedOutput[i] - targetOutput[i];
                sumSquaredError += error * error;
            }

            return sumSquaredError / predictedOutput.Length;
        }

    }
}
