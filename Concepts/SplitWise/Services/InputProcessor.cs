using SplitWise.Services.Interfaces;
using System;
using System.Linq;

namespace SplitWise.Services
{
    public class InputProcessor: IInputProcessor
    {
        
        public InputProcessor()
        {
                
        }
        public void Process(string inputLine)
        {
            if (IsValid(inputLine))
            {
               
                if (inputLine.IndexOf("Expense", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                   
                    

                }
                else
                {
                    //! else Balance viewer

                }

            }
            else
            {
                throw new InvalidOperationException("Input is not valid");  
            }

        }

        private bool IsValid(string inputLine)
        {

            return true;  
        }


    }
}
