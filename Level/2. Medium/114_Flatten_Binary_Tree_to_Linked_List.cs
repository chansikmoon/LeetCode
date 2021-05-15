/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public void Flatten(TreeNode root)
    {
        if (root == null)
            return;

        var node = root;

        while (node != null)
        {
            if (node.left != null)
            {
                var rightMost = node.left;
                while (rightMost.right != null)
                    rightMost = rightMost.right;

                rightMost.right = node.right;
                node.right = node.left;
                node.left = null;
            }

            node = node.right;
        }
    }
}