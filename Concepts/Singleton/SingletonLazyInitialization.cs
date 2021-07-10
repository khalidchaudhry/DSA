using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class SingletonLazyInitialization
    {
        //! lazy initialization
        private static SingletonLazyInitialization _singleInstance;
        private SingletonLazyInitialization()
        {

        }

        public static SingletonLazyInitialization GetInstance()
        {
            //! not thread safe
            if (_singleInstance == null)
            {
                _singleInstance = new SingletonLazyInitialization();
            }

            return _singleInstance;

        }


    }
}
