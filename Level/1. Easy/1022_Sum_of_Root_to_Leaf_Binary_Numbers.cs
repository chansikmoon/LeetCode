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
        return traverse(root, 0);
    }
    
    public int traverse(TreeNode root, int val)
    {
        val <<= 1;
        
        if (root.val == 1)
            val += 1;
        
        if (root.left == null && root.right == null)
            return val;
        
        int ret = 0;
        
        if (root.left != null)
            ret += traverse(root.left, val);
        
        if (root.right != null)
            ret += traverse(root.right, val);
        
        return ret;
    }
}