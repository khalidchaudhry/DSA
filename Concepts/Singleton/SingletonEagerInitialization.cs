using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class SingletonEagerInitialization
    {
       //! Eager initialization
        private static readonly SingletonEagerInitialization _singleInstance =new SingletonEagerInitialization();
        private SingletonEagerInitialization()
        {
            
        }
        
        public static SingletonEagerInitialization GetInstance()
        {
            return _singleInstance;
        }
    }
}
