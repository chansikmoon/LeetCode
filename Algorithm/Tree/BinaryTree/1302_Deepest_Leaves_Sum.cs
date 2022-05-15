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

// Revisited 05/15/2022
public class Solution
{
    public int DeepestLeavesSum(TreeNode root)
    {
        int targetDepth = GetDeepestDepth(root);
        return GetSumOfDeepestDepth(root, 1, targetDepth);
    }

    private int GetDeepestDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return Math.Max(GetDeepestDepth(root.left), GetDeepestDepth(root.right)) + 1;
    }

    private int GetSumOfDeepestDepth(TreeNode root, int depth, int target)
    {
        if (root == null)
            return 0;

        if (depth == target)
            return root.val;

        return GetSumOfDeepestDepth(root.left, depth + 1, target) +
            GetSumOfDeepestDepth(root.right, depth + 1, target);
    }
}