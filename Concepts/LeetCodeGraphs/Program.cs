using LeetCodeGraphs.Easy;
using LeetCodeGraphs.Medium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs
{
    class Program
    {
        static void Main(string[] args)
        {


            //int[][] paths = new int[][]
            //{
            //   //new int[] { 1, 2},
            //   //new int[] { 3, 4},
            //   //new int[] { 3,1},
            //   //new int[] { 4,1},
            //   //new int[] { 1,3},
            //   //new int[] { 2,4}
            //};


            //_1042 FlowerPlanting = new _1042();

            //var result = FlowerPlanting.GardenNoAdj(10000, paths);

            //int N = 2;
            //int[][] trust = new int[][]
            //{
            //    new int[]{1,2 }
            //};

            //int N = 3;
            //int[][] trust = new int[][]
            //{
            //    new int[]{1,3},
            //    new int[]{2,3}
            //};

            //int N = 3;
            //int[][] trust = new int[][]
            //{
            //    new int[]{1,3},
            //    new int[]{2,3},
            //    new int[]{3,1}
            //};

            //int N = 3;
            //int[][] trust = new int[][]
            //{
            //    new int[]{1,2},
            //    new int[]{2,3}            
            //};

            //int N = 4;
            //int[][] trust = new int[][]
            //{
            //    new int[]{1,3},
            //    new int[]{1,4},
            //    new int[] {2,3},
            //    new int[]{2, 4},
            //    new int[]{4, 3 }

            //};


            //_997 townJudge = new _997();

            //townJudge.FindJudge(N, trust);

            //string[] grid = new string[] 
            //{ " /",
            //  "/ "
            //};

            //_959 RegionsBySlashes = new _959();

            //var ans=RegionsBySlashes.RegionsBySlashes(grid);

            //_399 Division = new _399();

            //List<IList<string>> equations = new List<IList<string>>
            //{
            //    new List<string>{ "a", "b" },
            //    new List<string>{ "b", "c"}
            //};

            //double[] values = new double[] { 2.0, 3.0 };

            //List<IList<string>> queries = new List<IList<string>>
            //{
            //    new List<string>{ "a", "c" },
            //    new List<string>{ "b", "a"},
            //    new List<string>{ "a", "e"},
            //    new List<string>{ "a", "a"},
            //    new List<string>{ "x", "x"},
            //};


            //var result=Division.CalcEquation(equations,values,queries);

            //_332 It = new _332();
            //IList<IList<string>> tickets = new List<IList<string>>
            //{
            //    new List<string>{ "MUC", "LHR" },
            //    new List<string>{ "JFK", "MUC" },
            //    new List<string>{ "SFO", "SJC" },
            //    new List<string>{ "LHR", "SFO" }                
            //};

            //var result=It.FindItinerary2(tickets);

            //int numCourses = 2;
            //int[][] prerequisites = new int[][]
            //{
            //    new int[]{1,0},
            //    new int[]{2}
            //};


            //_207 CourseSchedule = new _207();
            //CourseSchedule.CanFinish2(numCourses, prerequisites);

            //_743 SortedNodeTest = new _743();

            //SortedNodeTest.SortedSetTest();

            //_210 CourseSchedule = new _210();

            //int numCourses = 4;
            //int[][] prerequisites = new int[][]
            //{
            //   new int[]{1, 0 },
            //   new int[]{2, 0 },
            //   new int[]{3, 1 },
            //   new int[]{3, 2 }
            //};
            //CourseSchedule.FindOrder(numCourses, prerequisites);

            //_310 MinHeight = new _310();
            //int n = 6;
            //int[][] edges = new int[5][]
            //{
            //    new int[]{0,3 },
            //    new int[]{1,3 },
            //    new int[]{2,3 },
            //    new int[]{4,3 },
            //    new int[]{5,4 },
            //};

            //MinHeight.FindMinHeightTrees(n,edges);

            //int[][] graph = new int[4][]
            //{
            //    new int[]{1,3 },
            //    new int[]{0,2 },
            //    new int[]{1,3},
            //    new int[]{0,2 },

            //};

            //_785 Bipartite = new _785();

            //Bipartite.IsBipartite(graph);

            //_684 RedundantConnection = new _684();

            //int[][] edges = new int[3][]
            //{
            //    new int[]{ 1,2},
            //    new int[]{1,3 },
            //    new int[]{2,3 },
            //};


            //RedundantConnection.FindRedundantConnection(edges);


            //_802 EventualSafe = new _802();

            //int[][] graph = new int[5][]
            //{
            //    new int[]{0},
            //    new int[]{2,3,4 },
            //    new int[]{3,4},
            //    new int[]{0,4},
            //    new int[]{}
            //};


            //EventualSafe.EventualSafeNodes0(graph);


            //_261 GraphValidTree = new _261();
            //int n = 5;
            //int[][] edges = new int[][]
            //{
            //    new int[]{0,1},
            //    new int[]{1,2},
            //    new int[]{2,3},
            //    new int[]{1,3},
            //    new int[]{1,4}
            //};


            //var result = GraphValidTree.ValidTree1(5, edges);

            //_841 KeyAndRooms = new _841();
            //List<IList<int>> rooms = new List<IList<int>>()
            //{
            //    new List<int>(){1},
            //    new List<int>(){2},
            //    new List<int>() { 3 },
            //    new List<int>(){ }
            //};
            //List<IList<int>> rooms = new List<IList<int>>()
            //{
            //    new List<int>(){1,3},
            //    new List<int>(){3,0,1},
            //    new List<int>(){2},
            //    new List<int>(){0}
            //};

            //var answer = KeyAndRooms.CanVisitAllRooms0(rooms);

            //_200 ConnectedIslands = new _200();
            //char[][] grid = new char[][]
            //{
            //  new char[]{'1','1','1','1','0' },
            //  new char[]{'1','1','0','1','0' },
            //  new char[]{'1','1','0','0','0' },
            //  new char[]{'0','0','0','0','0' }
            //};

            //var ans = ConnectedIslands.NumIslands(grid);

            //_323 ConnectedComponents = new _323();
            //int n = 5;
            //int[][] edges = new int[][]
            //{
            //    new int[]{0,1 },
            //    new int[]{1,2 },
            //    new int[]{3,4 }
            //};
            //var ans = ConnectedComponents.CountComponents2(n, edges);


            //_547 CloseFriends = new _547();

            //int[][] M = new int[][]
            //{
            //    new int[]{1,1,0},
            //    new int[]{1,1,1 },
            //    new int[]{0,1,1 }
            //};
            //var ans=CloseFriends.FindCircleNum(M);

            _130 SurrondedRegions = new _130();
            char[][] grid = new char[][]
            {
              new char[]{'X','X','X','X' },
              new char[]{'X','O','O','X'},
              new char[]{'X','X','O','X'},
              new char[]{'X','O','X','X'}
            };
            SurrondedRegions.Solve(grid);


            Console.ReadKey();

        }
    }
}
