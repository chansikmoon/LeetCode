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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return GetChild(preorder, inorder, 0, inorder.Length - 1, 0);
    }
    
    private TreeNode GetChild(int[] preorder, int[] inorder, int left, int right, int pIndex)
    {
        if (pIndex >= preorder.Length || left > right)
            return null;
        
        var root = new TreeNode(preorder[pIndex]);
        
        int currRoot = 0;
        for (; currRoot <= right; currRoot++)
        {
            if (inorder[currRoot] == root.val)
                break;
        }
        
        root.left = GetChild(preorder, inorder, left, currRoot - 1, pIndex + 1);
        root.right = GetChild(preorder, inorder, currRoot + 1, right, pIndex + currRoot - left + 1);
            
        return root;
    }
}