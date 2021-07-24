using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Entities.Interfaces
{
    public interface IKeyValueStore
    {
        string Get(string key);
        List<string> Search(string attributeKey, string attributeValue);

        void Put(string key, List<AttributePair> listOfAttributePairs);

        void Delete(string key);

        string Keys();
        

      
    }
}
