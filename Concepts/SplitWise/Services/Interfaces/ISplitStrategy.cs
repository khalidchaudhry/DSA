using SplitWise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Services.Interfaces
{
    //! Where i should place  it  under services or entities ?
    public interface ISplitStrategy
    {
        Expense Split(string line);

    }
}
