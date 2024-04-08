using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal interface ICost
    {
        double CostFunction(double[] predictedOutputs, double[] expectedOutputs);

        double CostDerivative(double predictedOutput, double expectedOutput);

        Cost.CostType CostFunctionType();
    }
}

