using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.GeekForGeeks
{
    public class ExpressionTreeEvaluation
    {
        public static void ExpressionTreeEvaluationMain()
        {
            Node root = new Node("+");
            root.left = new Node("*");
            root.right = new Node("-");

            root.left.left = new Node("5");
            root.left.right = new Node("4");

            root.right.left = new Node("100");
           // root.right.right = new Node("20");

            ExpressionTreeEvaluation evaluate = new ExpressionTreeEvaluation();

            var result = evaluate.ArithemticExpressionTreeEvaluation(root);
        }


        public double ArithemticExpressionTreeEvaluation(Node root)
        {
            if (root.left == null && root.right == null)
            {
                return double.Parse(root.data);
            }

            double left = ArithemticExpressionTreeEvaluation(root.left);
            double right = ArithemticExpressionTreeEvaluation(root.right);
            double ans = double.PositiveInfinity;
            switch (root.data)
            {
                case "+":
                    ans = left + right;
                    break;
                case "-":
                    ans = left - right;
                    break;
                case "*":
                    ans = left * right;
                    break;
                case "/":
                    ans = left / right;
                    break;
                default:
                    break;
            }

            return ans;

        }

        public class Node
        {
            public Node(string data)
            {
                this.data = data;
                left = null;
                right = null;
            }

            public string data;
            public Node left;
            public Node right;
        }

    }
}
