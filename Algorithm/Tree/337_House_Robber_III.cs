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
    public int Rob(TreeNode root) {
      // BruteForce
      // return Math.Max(DFS(root, true), DFS(root, false));
      int[] ret = DFS(root);
      return Math.Max(ret[0], ret[1]);
    }
    
    public int[] DFS(TreeNode root)
    {
      if (root == null)
        return new int[2];

      int[] left = DFS(root.left);
      int[] right = DFS(root.right);
      int[] ret = new int[2];

      // index 0 - not rob this node
      // index 1 - rob + not robbed left and right
      ret[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
      ret[1] = root.val + left[0] + right[0];

      return ret;
    }
    public int BruteForce(TreeNode root, bool prev)
    {
        if (root == null)
            return 0;
        
        int ret = DFS(root.left, false) + DFS(root.right, false);
        
        if (!prev)
        {
            ret = Math.Max(ret, root.val + DFS(root.left, true) + DFS(root.right, true));
        }
        
        return ret;
    }
}

public class Solution1 {
    public int Rob(TreeNode root) {
        var ret = Helper(root);
        return ret[1];
    }
    
    // ret[0] = exclude root
    // ret[1] = include root
    public int[] Helper(TreeNode root)
    {
        if (root == null)
            return new int[2];
        
        var left = Helper(root.left);
        var right = Helper(root.right);
        var ret = new int[2];
        
        ret[0] = left[1] + right[1];
        ret[1] = Math.Max(root.val + left[0] + right[0], ret[0]);
        
        return ret;
    }
}