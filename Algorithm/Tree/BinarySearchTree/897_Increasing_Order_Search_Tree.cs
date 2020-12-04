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
    public TreeNode IncreasingBST(TreeNode root) {
        return Helper(root, null);
    }
    
    public TreeNode Helper(TreeNode root, TreeNode tail)
    {
        if (root == null)
            return tail;
        
        TreeNode ret = Helper(root.left, root);
        root.left = null;
        root.right = Helper(root.right, tail);
        
        return ret;
    }
}