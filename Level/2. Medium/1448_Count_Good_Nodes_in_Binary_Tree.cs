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
    public int GoodNodes(TreeNode root)
    {
        return Helper(root, root.val);
    }

    public int Helper(TreeNode root, int max)
    {
        if (root == null)
            return 0;

        int left = Helper(root.left, Math.Max(root.val, max));
        int right = Helper(root.right, Math.Max(root.val, max));

        return (root.val >= max ? 1 : 0) + left + right;
    }
}