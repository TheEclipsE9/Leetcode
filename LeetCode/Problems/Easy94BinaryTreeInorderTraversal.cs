using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy94BinaryTreeInorderTraversal : IRunnable
    {
        public void Run()
        {
            TreeNode case1 = new TreeNode(
                4,
                new TreeNode(2,
                    new TreeNode(1, null, null),
                    new TreeNode(3, null, null)),
                new TreeNode(6,
                new TreeNode(5, null, null),
                new TreeNode(7, null, null)));

            TreeNode case2 = null;
            TreeNode case3 = new TreeNode(4,null, null);

            var res = InorderTraversal(case1);
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();

            if (root is null)
            {
                return res;
            }

            if (root.left is not null)
            {
                res.AddRange( InorderTraversal(root.left));
            }

            res.Add(root.val);
            if (root.right is not null)
            {
                res.AddRange(InorderTraversal(root.right));
            }

            return res;
        }


        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

    }
}
