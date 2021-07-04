using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDivideAndConquer.Hard
{
    public class _273
    {


    }

    //https://www.youtube.com/watch?v=BPS7p0SS4ZI&t=1s
    
    public class Solution
    {
        Dictionary<int, string> _numberWord;
        List<(int range, string word)> _rangeWord;

        public Solution()
        {
            _numberWord = new Dictionary<int, string>()
        {
           {0,""}, //! Appending zero because in case of 100,1000,1M and Billion , there will be exact match 
           {1,"One"},
           {2,"Two"},
           {3,"Three"},
           {4,"Four"},
           {5,"Five"},
           {6,"Six"},
           {7,"Seven"},
           {8,"Eight"},
           {9,"Nine"},
           {10,"Ten"},
           {11,"Eleven"},
           {12,"Twelve"},
           {13,"Thirteen"},
           {14,"Fourteen"},
           {15,"Fifteen"},
           {16,"Sixteen"},
           {17,"Seventeen"},
           {18,"Eighteen"},
           {19,"Nineteen"},
           {20,"Twenty"},
           {30,"Thirty"},
           {40,"Forty"},
           {50,"Fifty"},
           {60,"Sixty"},
           {70,"Seventy"},
           {80,"Eighty"},
           {90,"Ninety"}
        };

            _rangeWord = new List<(int range, string word)>()
        {
            (1000000000,"Billion"),
            (1000000,"Million"),
            (1000,"Thousand"),
            (100,"Hundred")
        };

        }
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";
            return Solve(num);
        }
        private string Solve(int num)
        {
            if (_numberWord.ContainsKey(num))
                return _numberWord[num];

            StringBuilder sb = new StringBuilder();

            if (num < 100)
            {
                sb.Append(Solve(num / 10 * 10));
                sb.Append(" ");
                sb.Append(Solve(num % 10));
            }
            else
            {
                foreach ((int range, string word)  in _rangeWord)
                {
                    if (num < range)
                        continue;

                    sb.Append(Solve(num /range));
                    sb.Append(" ");
                    sb.Append(word);
                    sb.Append(" ");
                    sb.Append(Solve(num % range));
                    break;
                }
            }
            //! Trimming it because in case of an exact match  like 100,1000, 1M and billion we are appending space at end
            return sb.ToString().Trim(); 
        }

    }


}
