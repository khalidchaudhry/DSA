using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Robinhood
{
    public class RobinhoodScreening
    {
        public void ScreeningMain()
        {
            string[] list = new string[]{"logging=",
                                         "user=logging",
                                         "orders=user,non_existent",
                                         "recommendations=user,orders",
                                         "dashboard=user,orders,recommendations" };

            string[] list2 = new string[] {
                                        "logging=",
                                         "third_party=",
                                         "datastore=logging",
                                         "user=datastore",
                                         "verifications=user,third_party",
                                         "history=user",
                                         "price=third_party",
                                         "orders=user,price,third_party,datastore",
                                         "affiliates=third_party,non_existent",
                                         "recommendations=user,history,orders,affiliates",
                                         "dashboard=user,history,orders,recommendations",
                                         "machine_learning=user,data_platform,history"
          };

            string[] list3 = new string[]{"logging=",
                                         "third_party=",
                                         "datastore=logging",
                                         "user=datastore",
                                         "verifications=user,third_party",
                                         "history=user",
                                         "price=third_party",
                                         "orders=user,price,third_party,datastore",
                                         "affiliates=third_party,non_existent",
                                         "recommendations=user,history,orders,affiliates",
                                         "dashboard=user,history,orders,recommendations",
                                         "machine_learning=user,data_platform,history" };

            string[] list4 = new string[] {
                                                "datastore=",
                                               "user=datastore",
                                               "history=user",
                                               "recommendations=user,history"
            };



            //SubmittedSolution(list4, "dashboard");
            SubmittedSolution(list4, "recommendations");

        }

        public static string[] SubmittedSolution(string[] service_list, string entrypoint)
        {

            Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();           
            Dictionary<string, int> nodeCount = new Dictionary<string, int>();

            foreach (string service in service_list)
            {
                string[] tokens = service.Split('=');
                string src = tokens[0];
                string destinations = tokens[1];
                if (!adjList.ContainsKey(src))
                {
                    adjList.Add(src, new List<string>());
                }
                if (!string.IsNullOrEmpty(destinations))
                {
                    string[] neighbors = destinations.Split(',');
                    foreach (string neighbor in neighbors)
                    {
                        if (adjList.ContainsKey(neighbor))
                        {
                            adjList[src].Add(neighbor);
                        }
                    }
                }
            }
            Solve(adjList, entrypoint, nodeCount);
            string[] result = new string[nodeCount.Count];
            int idx = 0;
            nodeCount = nodeCount.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var keyValue in nodeCount)
            {
                result[idx++] = $"{keyValue.Key}*{keyValue.Value}";
            }

            return result;
        }
        private static void Solve(Dictionary<string, List<string>> adjList, string entryPoint, Dictionary<string, int> nodeCount)
        {
            if (!nodeCount.ContainsKey(entryPoint))
            {
                nodeCount.Add(entryPoint, 0);
            }
            ++nodeCount[entryPoint];

            if (adjList.ContainsKey(entryPoint))
            {
                foreach (string neighbor in adjList[entryPoint])
                {
                    Solve(adjList, neighbor, nodeCount);
                }
            }
        }
    }
}
