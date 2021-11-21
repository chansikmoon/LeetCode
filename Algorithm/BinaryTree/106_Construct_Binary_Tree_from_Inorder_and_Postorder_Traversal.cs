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
    private int postOrderIndex;
    private int inOrderIndex;
    
    public TreeNode BuildTree(int[] inorder, int[] postOrder) {
        postOrderIndex = postOrder.Length - 1;
        inOrderIndex = inorder.Length - 1;
        
        return buildTree(inorder, postOrder, null);
    }
    
    private TreeNode buildTree(int[] inorder, int[] postOrder, TreeNode parent)
    {
        if (postOrderIndex < 0)
            return null;
        
        TreeNode root = new TreeNode(postOrder[postOrderIndex--]);
        
        if (inorder[inOrderIndex] != root.val)
            root.right = buildTree(inorder, postOrder, root);
        
        inOrderIndex--;
        
        if (parent == null || inorder[inOrderIndex] != parent.val)
            root.left = buildTree(inorder, postOrder, parent);
        
        return root;
    }
}