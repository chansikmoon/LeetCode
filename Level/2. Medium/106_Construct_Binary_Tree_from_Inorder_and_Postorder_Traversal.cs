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
    
    private TreeNode buildTree(int[] inorder, int[] postOrder, TreeNode end)
    {
        if (postOrderIndex < 0)
            return null;
        
        TreeNode n = new TreeNode(postOrder[postOrderIndex--]);
        
        if (inorder[inOrderIndex] != n.val)
            n.right = buildTree(inorder, postOrder, n);
        
        inOrderIndex--;
        
        if ((end == null) || (inorder[inOrderIndex] != end.val))
            n.left = buildTree(inorder, postOrder, end);
        
        return n;
    }
}