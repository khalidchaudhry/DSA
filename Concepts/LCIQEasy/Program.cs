using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            _937 ReorderDatainLogFiles = new _937();

            string[] logs = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };

            //ReorderDatainLogFiles.ReorderLogFiles(logs);
            */
            /*
            _953 alienSorted = new _953();
            string[] words = new string[] { "apple", "app" };
            string order = "abcdefghijklmnopqrstuvwxyz";
            Console.Write(alienSorted.IsAlienSorted(words,order));
            */

            //_994 RottingOranges = new _994();

            //const  int  rows = 3;
            //var array = new int[rows][]
            //    {
            //        new int[]{2, 1, 1 },
            //        new int[]{1, 1, 0 },
            //        new int[]{0, 1, 1}
            //   };

            //    RottingOranges.OrangesRotting(array);
            /*
                    3
                   / \
                  4   5
                 / \
                1   2

                 4 
                / \
               1   2


            */
            //var t = new TreeNode(3);

            //t.left = new TreeNode(4);
            //t.left.left = new TreeNode(1);
            //t.left.right = new TreeNode(2);
            ////t.left.right.left = new TreeNode(0);

            //t.right = new TreeNode(5);

            //var t2 = new TreeNode(4);
            //t2.left = new TreeNode(1);
            //t2.right = new TreeNode(2);
            //_572 treeSubset = new _572();
            //treeSubset.IsSubtree(t,t2);


            String paragraph = "a.";//"Bob hit a ball, the hit BALL flew far after it was hit.";
            String[] banned = new String[] { };
            _819 mostCommonWord=new _819();

            Console.WriteLine(mostCommonWord.MostCommonWord2(paragraph, banned));

            Console.Read();


        }
    }
}
