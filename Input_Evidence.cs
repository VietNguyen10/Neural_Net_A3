using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal class Input_Evidence
    {
        public int value { get; set;}
        public int weight { get; private set;}

        public Input_Evidence(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
        }

    }
}
