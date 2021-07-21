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
        MemoryKeyValueStore _keyValueStore;
        public ApplicationRunner(MemoryKeyValueStore store, IPrint print)
        {
            _keyValueStore = store;
            _print = print;
        }

        public void Run()
        {
            List<AttributePair> list = new List<AttributePair>()
            {
                new AttributePair("title","SDE-Bootcamp"),
                new AttributePair("price","30000.00"),
                new AttributePair("enrolled","false"),
                new AttributePair("estimated_time","30")
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

            List<AttributePair> list2 = new List<AttributePair>()
            {
                new AttributePair("title","SDE-KickStart"),
                new AttributePair("price","40000.00"),
                new AttributePair("enrolled","true"),
                new AttributePair("estimated_time","8")
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
