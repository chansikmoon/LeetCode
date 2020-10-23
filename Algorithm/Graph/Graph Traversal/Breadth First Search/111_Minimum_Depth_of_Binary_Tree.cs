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
    // O(n) for both
    // BFS is better in this case. 
    // If the left subTree has 100 depth and the right subTree has only 1 depth then the DFS solution iterates all left subTrees before it realizes that the right subTree has only 1 depth.
    
    public int MinDepth(TreeNode root) {
        return DFSMinDepth(root);
    }
    
    private int DFSMinDepth(TreeNode root)
    {
        if (root == null) return 0;
        
        if (root.left == null && root.right == null)
            return 1;
        
        int left = Int32.MaxValue, right = Int32.MaxValue;
        if (root.left != null)
            left = DFSMinDepth(root.left);
        
        if (root.right != null)
            right = DFSMinDepth(root.right);
            
            
        return Math.Min(left, right) + 1;
    }
    
    private int BFSMinDepth(TreeNode root)
    {
        if (root == null) return 0;
        int depth = 1;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            // the # of nodes in the current depth
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode currNode = q.Dequeue();
                if (currNode.left == null && currNode.right == null)
                    return depth;
                if (currNode.left != null)
                    q.Enqueue(currNode.left);
                if (currNode.right != null)
                    q.Enqueue(currNode.right);
            }
            
            depth++;
        }
        
        return depth;
    }
}