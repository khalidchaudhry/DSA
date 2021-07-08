using SplitWise.Entities;
using SplitWise.Services;
using SplitWise.Services.Interfaces;
using SplitWise.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Factory
{
    public class SplitStrategyFactory
    {
        private readonly ExactSplitStrategy _exactSplitStrategy;
        private readonly EqualSplitStrategy _equalSplitStrategy;
        private readonly PercentagSplitStrategy _percentageSplitStrategy;

        //! Does not make sense to pass classes inside constructors.we can simply use new EqualSplitStrategy()
        public SplitStrategyFactory(ExactSplitStrategy exactSplitStrategy,
                                    EqualSplitStrategy equalSplitStrategy,
                                    PercentagSplitStrategy percentageSplitStrategy)
        {
            _equalSplitStrategy = equalSplitStrategy;
            _exactSplitStrategy = exactSplitStrategy;
            _percentageSplitStrategy = percentageSplitStrategy;
        }

        //! Why not creating it as a static method? There is no state in it ?
        public ISplitStrategy GetSplitStrategy(string input)
        {
            input = input.ToLower();
            if (input.Contains(Constants.EQUAL_SPLIT_STRATEGY))
            {
                return _equalSplitStrategy;
            }
            else if (input.Contains(Constants.EXACT_SPLIT_STRATEGY))
            {
                return _exactSplitStrategy;
            }
            else if (input.Contains(Constants.PERCENTAGE_SPLIT_STRATEGY))
            {
                return _percentageSplitStrategy;
            }
            else
            {
                throw new NotSupportedException("Provided split strategy is not supported");
            }

        }



    }
}
