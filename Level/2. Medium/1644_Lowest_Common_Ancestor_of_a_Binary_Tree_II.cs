/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    private int Count { get; set; }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        Count = 0;

        var ret = LCAHelper(root, p, q);

        return Count == 2 ? ret : null;
    }

    private TreeNode LCAHelper(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
            return null;

        var left = LCAHelper(root.left, p, q);
        var right = LCAHelper(root.right, p, q);

        if (root == p || root == q)
        {
            Count++;
            return root;
        }

        return left == null ? right : right == null ? left : root;
    }
}