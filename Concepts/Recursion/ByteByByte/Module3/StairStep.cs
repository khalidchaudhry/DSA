using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module3
{
    public class StairStep
    {
        public List<List<int>> StairSteps(int n)
        {
            return StairSteps(n, 0);

        }

        private List<List<int>> StairSteps(int n, int currentStep)
        {
            List<List<int>> result = new List<List<int>>();
            if (currentStep == n)
            {
                result.Add(new List<int>());
                return result;
            }

            if (currentStep > n)
            {
                return new List<List<int>>();
            }
            
            result.AddRange(StairSteps(n, currentStep + 1));
            result.AddRange(StairSteps(n, currentStep + 2));
            result.AddRange(StairSteps(n, currentStep + 3));

            foreach (List<int> l in result)
            {
                l.Insert(0,currentStep);
            }

            return result;
        }
    }
}
