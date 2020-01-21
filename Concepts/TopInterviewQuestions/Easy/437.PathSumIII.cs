using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _437
    {
        public void  PathSum(TreeNode root, int sum)
        {
            Stack<int> stk = new Stack<int>();
            PrintAllPathsSum(root, stk);
            
        }

        private void PrintAllPathsSum(TreeNode node,Stack<int> stk)
        {
            if (node == null)
            {
                return;
            }


            stk.Push(node.val);
            CheckAllSum(stk);

            
            
            PrintAllPathsSum(node.left,stk);
            PrintAllPathsSum(node.right, stk);
            stk.Pop();
        }
        private void CheckAllSum(Stack<int> stk)
        {
            int target = 7;
            int totalSum = 0;

            List<int> path = new List<int>();
           
            foreach (var val in stk)
            {
                Console.WriteLine(val);
                totalSum += val;
                path.Add(val);
                if (totalSum == target)
                {
                    path.ForEach(e => Console.Write($"{e}-->"));
                    Console.WriteLine();
                }
            }
            


        }

                     
    }
}
