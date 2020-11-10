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
        return DFS(root, root.val, root.val);
    }
    
    // We have to eventually check all nodes and update max and min until the leaf node. 
    // Then we return the maximum difference from subtrees.
    private int DFS(TreeNode root, int max, int min)
    {
        if (root == null) return max - min;
        
        max = Math.Max(root.val, max);
        min = Math.Min(root.val, min);
        
        return Math.Max(Traverse(root.left, max, min), Traverse(root.right, max, min));
    }

    private int BruteForce(TreeNode root)
    {
        return Math.Max(BruteForceDFS(root.left, root.val, root.val), BruteForceDFS(root.right, root.val, root.val));
    }

    private int BruteForceDFS(TreeNode root, int max, int min)
    {
        if (root == null) return 0;
        
        int left = BruteForceDFS(root.left, Math.Max(max, root.val), Math.Min(min, root.val));
        int right = BruteForceDFS(root.right, Math.Max(max, root.val), Math.Min(min, root.val));
        int curr = Math.Max(Math.Abs(root.val - max), Math.Abs(root.val - min));
        
        return Math.Max(curr, Math.Max(left, right));
    }
}