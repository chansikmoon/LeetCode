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
    public TreeNode ConvertBST(TreeNode root) {
        DFS(root, 0);
        
        return root;
    }
    
    private int DFS(TreeNode root, int sum)
    {
        if (root == null)
            return sum;
        
        root.val += DFS(root.right, sum);;
        
        return DFS(root.left, root.val);;
    }
}