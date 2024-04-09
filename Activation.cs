using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal class Activation
    {
        public enum ActivationType
        {
            Sigmoid,
            TanH,
            ReLU,
            SiLU,
        }

        public static IActivation GetActivationFromType(ActivationType type)
        {
            switch (type)
            {
                case ActivationType.Sigmoid:
                    return new Sigmoid();
                case ActivationType.TanH:
                    return new TanH();
                case ActivationType.ReLU:
                    return new ReLU();
                case ActivationType.SiLU:
                    return new SiLU();
                default:
                    Console.Write("Unhandled activation type");
                    return new Sigmoid();
            }
        }

        internal class Sigmoid : IActivation
        {
            public double Activate(double input)
            {
                return 1.0 / (1.0 + Math.Exp(-input));
            }
        }

        internal class TanH : IActivation
        {
            public double Activate(double input)
            {
                return Math.Tanh(input);
            }
        }

        internal class ReLU : IActivation
        {
            public double Activate(double input)
            {
                return Math.Max(0, input);
            }
        }

        internal class SiLU : IActivation
        {
            public double Activate(double input)
            {
                return input * (1.0 / (1.0 + Math.Exp(-input)));
            }
        }

    }
}
