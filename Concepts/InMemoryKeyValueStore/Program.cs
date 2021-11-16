using InMemoryKeyValueStore.Entities;
using InMemoryKeyValueStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //! Requirement
            /*
              1. The key will always be a string.
              2. The value would be an object/map. The object would have attributes and corresponding values.
              Example => "sde_bootcamp": { "title": "SDE-Bootcamp", "price": 30000.00, "enrolled": false, "estimated_time": 30 }
              3. Each attribute key would be a string and the attribute values could be string, integer, double or boolean.
              4. The key-value store should be thread-safe.
              5. Supported functions
                 1.  get(String key) => Should return the value (object with attributes and their values). 
                 2.  Return null if key not present
                 3   search(String attributeKey, String attributeValue) => Returns a list of keys that have the given attribute key, value pair.
                 4.  put(String key, List<Pair<String, String>> listOfAttributePairs) => Adds the key and the attributes to the key-value store. If the key already exists then the value is replaced.
                 5.  delete(String key) => Deletes the key, value pair from the store.
                 6.  keys() => Return a list of all the keys
            6. The value object should override the toString method to print the object as a comma-separated list of key-value pairs for the attributes.
               Example: attribute1: attribute_value_1, attribute2: attribute_value_2, attribute3: attribute_value_3
            8. The data type of an attribute should get fixed after its first occurrence. 
               Example: Once we encounter an attribute age with an integer value then any entry with an age attribute having a non-integer value should 
               result in an exception.  
            9. Nothing should be printed inside any of these methods. All scanning and printing should happen in the Driver/Main class only. 
               Exception Handling should also happen in the Driver/Main class.
               
             */
            //! Entities 
            /*
                 Value -->
                     AttributeValue
                     Type:

                 KeyValueStore
                      Map-   
                             Key:  Key
                             Value:Map<Key: attributeName Value: Value

              */
            //!Services 
            /*
                 Parse ---> Will parse the input string to Value 
                 Print---->
                 ExceptionHandler
              */

            ConsolePrint consolePrint = new ConsolePrint();
            MemoryKeyValueStore keyValueStore = new MemoryKeyValueStore();           
            ApplicationRunner runner = new ApplicationRunner(keyValueStore, consolePrint);
            runner.Run();
            Console.ReadLine();



        }
    }
}
