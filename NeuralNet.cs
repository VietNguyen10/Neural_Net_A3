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
        public int Layers { get; set; }
        public Neuron[][] Neurons { get; set; }
        public double[][][] Weights { get; set; }

        public NeuralNet(int inputSize, int hiddenSize, int outputSize)
        {
            this.layers = new Layer[2]; // For simplicity, we use only one hidden layer
            layers[0] = new Layer(inputSize, hiddenSize, Activation.GetActivationFromType(Activation.ActivationType.ReLU));
            layers[1] = new Layer(hiddenSize, outputSize, Activation.GetActivationFromType(Activation.ActivationType.Sigmoid));
        }
        public void ForwardFeed()
        {
            for (int k = 1; k < Layers; k++)
            {
                for (int i = 0; i < Neurons[k].Length; i++)
                {
                    Neurons[k][i].Value = 0;
                    for (int j = 0; j < Neurons[k - 1].Length; j++)
                        Neurons[k][i].Value += Neurons[k - 1][j].Value * Weights[k - 1][j][i];
                    Neurons[k][i].Activation();
                }
            }
        }

        public void ForwardFeed(int layerNumber)
        {
            for (int i = 0; i < Neurons[layerNumber].Length; i++)
            {
                Neurons[layerNumber][i].Value = 0;
                for (int j = 0; j < Neurons[layerNumber - 1].Length; j++)
                    Neurons[layerNumber][i].Value += Neurons[layerNumber - 1][j].Value * Weights[layerNumber - 1][j][i];
                Neurons[layerNumber][i].Activation();
            }
        }
    }

}
