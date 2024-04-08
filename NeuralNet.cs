using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;


namespace NeuralNet
{
    /// <summary>
    /// Neural network class
    /// Used for training and "thinking" for the neural network.
    /// </summary>
    internal class NeuralNet
    {
        private Layer[] layers;

        public NeuralNet(int inputSize, int hiddenSize, int outputSize)
        {
            this.layers = new Layer[2]; // For simplicity, we use only one hidden layer
            layers[0] = new Layer(inputSize, hiddenSize, Activation.GetActivationFromType(Activation.ActivationType.ReLU));
            layers[1] = new Layer(hiddenSize, outputSize, Activation.GetActivationFromType(Activation.ActivationType.Softmax));
        }
        public double[] Forward(double[] input)
        {
            double[] output = input;
            foreach (Layer layer in layers)
            {
                output = layer.Forward(output);
            }
            return output;
        }
    }

}
