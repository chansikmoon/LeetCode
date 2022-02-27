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
    private Dictionary<int, int> left = new Dictionary<int, int>();
    private int maxDepth = 0;
    public int WidthOfBinaryTree(TreeNode root) {
        DFS(root, 0, 0);
        return maxDepth;
    }
    
    private void DFS(TreeNode root, int level, int idx) {
        if (root == null)
            return;
        
        if (!left.ContainsKey(level))
            left.Add(level, idx);
        
        maxDepth = Math.Max(maxDepth, idx - left[level] + 1);
        
        DFS(root.left, level + 1, idx * 2);
        DFS(root.right, level + 1, idx * 2 + 1);       
    }
}