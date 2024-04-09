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
        public Neuron[] Neurons { get; set; }
        public double[] Biases { get; set; }

        public Layer(int numberOfNeurons)
        {
            Neurons = new Neuron[numberOfNeurons];
            Biases = new double[numberOfNeurons];
            for (int i = 0; i < numberOfNeurons; i++)
                Neurons[i] = new Neuron();
        }
    }
}
