using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Altimetrik.OpenIntervue
{
    public static class FindTreeNode
    {
        public class TreeNode
        {
            public int Value;
            public TreeNode? Left;
            public TreeNode? Right;

            public TreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public static TreeNode BuildTree(int[] values)
        {
            if (values.Length == 0 || values[0] == -1)
                return null;

            Console.WriteLine("Sample Input ==>> " + string.Join(" ", values));

            TreeNode root = new TreeNode(values[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();
                // Left child
                if (i < values.Length && values[i] != -1)
                {
                    current.Left = new TreeNode(values[i]);
                    queue.Enqueue(current.Left);
                }
                i++;
                // Right child
                if (i < values.Length && values[i] != -1)
                {
                    current.Right = new TreeNode(values[i]);
                    queue.Enqueue(current.Right);
                }
                i++;
            }
            return root;
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
