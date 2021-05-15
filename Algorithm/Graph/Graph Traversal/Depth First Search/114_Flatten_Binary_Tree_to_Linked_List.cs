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

    private TreeNode Helper(TreeNode root, TreeNode prev)
    {
        if (root == null)
            return prev;
        prev = Helper(root.right, prev);
        prev = Helper(root.left, prev);
        root.right = prev;
        root.left = null;

        return root;
    }
}