/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

// Revisited 05/17/2022
public class Solution {
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        if (original == null)
            return null;
        
        if (original == target)
            return cloned;
        
        return GetTargetCopy(original.left, cloned.left, target) ?? 
               GetTargetCopy(original.right, cloned.right, target);
    }
}