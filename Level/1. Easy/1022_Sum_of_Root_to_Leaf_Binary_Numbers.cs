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
    public int SumRootToLeaf(TreeNode root) {
        return DFS(root, 0);
    }
    
    private int DFS(TreeNode root, int num)
    {
        num <<= 1;
        num |= root.val;
        
        if (root.left == null && root.right == null)
            return num;
        
        int left = 0, right = 0;
        
        if (root.left != null)
            left = DFS(root.left, num);
        
        if (root.right != null)
            right = DFS(root.right, num);
        
        return left + right;
    }
}