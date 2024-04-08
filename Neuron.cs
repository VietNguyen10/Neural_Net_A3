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
        /// <summary>
		/// The value of the neuron
		/// </summary>
		public Byte activation;

        /// <summary>
        /// The 'offset' of the neuron
        /// </summary>
        public SByte bias;

        /// <summary>
        /// The multiplier to modify the bias and weights by when learning
        /// </summary>
        public Single toDescend;


    }
}
