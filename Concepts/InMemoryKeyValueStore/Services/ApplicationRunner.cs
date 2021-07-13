using InMemoryKeyValueStore.Entities;
using InMemoryKeyValueStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Services
{
    public class ApplicationRunner
    {

        IPrint _print;
        KeyValueStore _keyValueStore;
        public ApplicationRunner(KeyValueStore store, IPrint print)
        {
            _keyValueStore = store;
            _print = print;
        }

        public void Run()
        {
            List<(string attributeName, string attributeValue)> list = new List<(string attributeName, string attributeValue)>()
            {
                ("title","SDE-Bootcamp"),
                ("price","30000.00"),
                ("enrolled","false"),
                ("estimated_time","30")
            };
            try
            {
                _keyValueStore.Put("sde_bootcamp", list);
                _print.Print(_keyValueStore.Get("sde_bootcamp"));

            }
            catch (Exception ex)
            {
                _print.Print(ex.Message);
            }

            _print.Print(_keyValueStore.Keys());

            List<(string attributeName, string attributeValue)> list2 = new List<(string attributeName, string attributeValue)>()
            {
                ("title","SDE-KickStart"),
                ("price","40000.00"),
                ("enrolled","true"),
                ("estimated_time","8")
            };
            try
            {
                _keyValueStore.Put("sde_kickstart", list2);
                _print.Print(_keyValueStore.Get("sde_kickstart"));
            }
            catch (Exception ex)
            {
                _print.Print(ex.Message);
            }

            _print.Print(_keyValueStore.Keys());

            try
            {
                _keyValueStore.Delete("sde_bootcamp");
                _print.Print(_keyValueStore.Get("sde_bootcamp"));
            }
            catch (Exception ex)
            {
                _print.Print(ex.Message);
            }
            try
            {
                _keyValueStore.Put("sde_bootcamp", list);
            }
            catch (Exception ex)
            {
                _print.Print(ex.Message);
            }

            _print.Print(_keyValueStore.Search("price", "30000.00"));
            _print.Print(_keyValueStore.Search("enrolled", "true"));



        }
    }
}
