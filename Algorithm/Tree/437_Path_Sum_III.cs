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
    private int target;
    private int count = 0;
    
    public int PathSum(TreeNode root, int sum) {
        target = sum;
        
        Begin(root);
        
        return count;
    }
    
    private void Begin(TreeNode root)
    {
        if (root == null) return;
        
        Traverse(root, 0);
        Begin(root.left);
        Begin(root.right);
    }
    
    private void Traverse(TreeNode root, int sum)
    {
        if (root == null) return;
        
        sum += root.val;
        
        if (sum == target) count++;
        
        Traverse(root.left, sum);
        Traverse(root.right, sum);
    }
}