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
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root.left, Int64.MinValue, root.val) &&
            IsValidBST(root.right, root.val, Int64.MaxValue);
    }
    
    public bool IsValidBST(TreeNode root, long minVal, long maxVal)
    {
        if (root == null)
            return true;
        if (minVal >= root.val || maxVal <= root.val)
            return false;
        
        return IsValidBST(root.left, minVal, root.val) && IsValidBST(root.right, root.val, maxVal);
    }
}