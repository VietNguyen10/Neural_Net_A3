using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeuralNet.Activation;

namespace NeuralNet
{
    internal class Layer
    {
        double[,] weights;
        double[] biases;
        IActivation activationFunction;

        public Layer(int inputSize, int outputSize, IActivation activationFunction = null)
        {
            this.weights = new double[outputSize, inputSize];
            this.biases = new double[outputSize];
            this.activationFunction = activationFunction ?? Activation.GetActivationFromType(Activation.ActivationType.Sigmoid);
            InitializeWeights();
        }

        private void InitializeWeights()
        {
            Random random = new Random();
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    weights[i, j] = random.NextDouble(); // Initialize weights randomly
                }
                biases[i] = random.NextDouble(); // Initialize biases randomly
            }
        }

        // Forward propagation function
        public double[] Forward(double[] inputs)
        {
            int numNeurons = inputs.Length;
            double[] outputs = new double[numNeurons];

            for (int i = 0; i < numNeurons; i++)
            {
                // Activate each neuron in the layer
                outputs[i] = activationFunction.Activate(inputs, i);
            }

            return outputs;
        }

        //TODO: Implement backpropagation
    }
}
