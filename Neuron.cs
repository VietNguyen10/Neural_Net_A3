using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    /// <summary>
    /// Neural network basic neuron class
    /// </summary>
    internal class Neuron
    {
        private readonly IActivation _activation;
        public double Value { get; set; }
        public double Error { get; set; }
        public Neuron(IActivation activation)
        {
            _activation = activation;
        }

        public void Activation()
        {
            Value = _activation.Activate(Value);
        }

    }
}
