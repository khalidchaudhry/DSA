using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class ThreadSafeSingletonLazyInitialization
    {
        private static ThreadSafeSingletonLazyInitialization _instance;
        private ThreadSafeSingletonLazyInitialization()
        {

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ThreadSafeSingletonLazyInitialization GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ThreadSafeSingletonLazyInitialization();
            }
            return _instance;
        }


    }
}
