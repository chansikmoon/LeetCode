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
    public int ClosestValue(TreeNode root, double target) {
        int ret = root.val;
        while (root != null)
        {
            if (Math.Abs(root.val - target) < Math.Abs(ret - target))
                ret = root.val;
            
            root = root.val > target ? root.left : root.right;
        }
        
        return ret;
    }
}