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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) return new TreeNode(val);
        
        if (root.val < val) root.right = InsertIntoBST(root.right, val);
        else root.left = InsertIntoBST(root.left, val);
        return root;
    }
    
    private TreeNode Iterative(TreeNode root, int val)
    {
        if (root == null) return new TreeNode(val);
        
        TreeNode parent = root, curr = root;
        
        while (curr != null)
        {
            parent = curr;
            curr = curr.val < val ? curr.right : curr.left;
        }
        
        TreeNode newNode = new TreeNode(val);
        
        if (parent.val < newNode.val)
            parent.right = newNode;
        else
            parent.left = newNode;
        
        return root;
    }
}