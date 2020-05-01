using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class PermutationsInPlace
    {
        //https://medium.com/@kevingxyz/permutation-in-place-8528581a5553
        public void Permute(char[] A, int[] P)
        {
            for (int i = 0; i < A.Length; i++)
            {
                //We look at P to see what is the new index
                int index_to_swap = P[i];
                //Check index if it has already been swapped before
                while (index_to_swap < i)
                {
                    index_to_swap = P[index_to_swap];
                }
                Swap(A,i,index_to_swap);
            }
        }
        private void Swap(char[] A, int i, int j)
        {
            char temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

    }
}
