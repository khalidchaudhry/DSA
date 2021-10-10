using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _948
    {
        public int BagOfTokensScore(int[] tokens, int power)
        {
            int score = 0;
            Array.Sort(tokens);
            int left = 0;
            int right = tokens.Length - 1;

            while (left <= right)
            {
                if (power >= tokens[left])
                {
                    ++score;
                    power -= tokens[left];
                    ++left;
                }
                else
                {
                    //! we can only gain power if score >=1
                    //!left!=right means that we are at last turn and there is no point playing as u are going 
                    //! to loose the score anway so we are going to skip it 
                    if (score >= 1 && left != right)
                    {
                        --score;
                        power += tokens[right];
                    }
                    --right;
                }
            }
            return score;
        }

    }
}
