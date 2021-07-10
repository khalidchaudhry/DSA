using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class DoubleCheckThreadSafeLazyInitialization
    {
        private static DoubleCheckThreadSafeLazyInitialization _instance;

        private DoubleCheckThreadSafeLazyInitialization()
        {

        }
        public static DoubleCheckThreadSafeLazyInitialization GetInstance()
        {
            if (_instance == null)
            {
                lock (_instance)
                {
                    if (_instance == null)
                    {
                        _instance = new DoubleCheckThreadSafeLazyInitialization();
                    }

                }
            }
            return _instance;
        }

    }
}
