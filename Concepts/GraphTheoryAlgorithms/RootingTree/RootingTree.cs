using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.RootingTree
{
    /*
      Sometimes it’s useful to root an undirected
      tree to add structure to the problem you’re
      trying to solve.      
     */
    public static class RootingTree
    {

        public static TreeNode RootTree(List<List<int>> graph, int rootId)
        {
            TreeNode root = new TreeNode(rootId);
            return BuildTree(graph, root);
        }

        // Do dfs to construct rooted tree.
        private static TreeNode BuildTree(List<List<int>> graph, TreeNode node)
        {
            // loop over all the neighbours of the  node which become the children of the current node
            foreach (int childId in graph[node.Id])
            {
                // Ignore adding an edge pointing back to parent.
                if (node.Parent != null && childId == node.Parent.Id)
                {
                    continue;
                }

                TreeNode child = new TreeNode(childId, node);
                node.AddChildren(new List<TreeNode> { child });

                BuildTree(graph, child);
            }
            return node;
        }
    }

    public class TreeNode
    {
        //Unique integer id to identify this node.
        private readonly int id;
        //  Pointer to parent TreeNode reference. Only the
        // root node has a null parent TreeNode reference.
        private TreeNode parent;
        // List of pointers to child TreeNodes.
        private List<TreeNode> children;
        public int Id
        {
            get => id;
        }


        public TreeNode Parent
        {
            get => parent;
        }

        public List<TreeNode> Children
        {
            get => children;
        }

        public TreeNode(int id) : this(id, null)
        {

        }
        public TreeNode(int id, TreeNode parent)
        {
            this.id = id;
            this.parent = parent;
            children = new List<TreeNode>();
        }

        public void AddChildren(List<TreeNode> nodes)
        {
            foreach (TreeNode node in nodes)
            {
                children.Add(node);
            }
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        // Only checks id equality not subtree equality.

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TreeNode treeNode = (TreeNode)obj;
                return Id == treeNode.Id;
            }
        }

    }
}
