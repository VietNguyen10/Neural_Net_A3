using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal interface IActivation
    {
        double Activate(double[] inputs, int index);

        double Derivative(double[] inputs, int index);

        Activation.ActivationType GetActivationType();
    }
}
