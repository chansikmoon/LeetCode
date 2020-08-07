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
public class Solution {
    public int MaxAncestorDiff(TreeNode root) {
        return Traverse(root, root.val, root.val);
    }
    
    private int Traverse(TreeNode root, int max, int min)
    {
        if (root == null) return max - min;
        
        max = Math.Max(root.val, max);
        min = Math.Min(root.val, min);
        
        return Math.Max(Traverse(root.left, max, min), Traverse(root.right, max, min));
    }
}