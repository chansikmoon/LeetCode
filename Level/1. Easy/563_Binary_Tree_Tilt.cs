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
    public int FindTilt(TreeNode root) {
        List<int> ret = new List<int>();
        Traverse(root, ret);
        
        return ret.Sum();
    }
    
    public int Traverse(TreeNode root, List<int> tilt)
    {
        if (root == null)
            return 0;
        
        int left = Traverse(root.left, tilt);
        int right = Traverse(root.right, tilt);
        
        tilt.Add(Math.Abs(left - right));
        
        return root.val + left + right;
    }
}