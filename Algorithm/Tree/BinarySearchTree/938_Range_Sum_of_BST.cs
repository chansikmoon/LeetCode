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
    public int RangeSumBST(TreeNode root, int L, int R) {
        if (root == null) return 0;
        
        int ret = root.val >= L && root.val <= R ? root.val : 0;
        
        return ret + RangeSumBST(root.left, L, R) + RangeSumBST(root.right, L, R);
    }
}