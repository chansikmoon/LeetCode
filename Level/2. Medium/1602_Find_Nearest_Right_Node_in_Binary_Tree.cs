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
    public TreeNode FindNearestRightNode(TreeNode root, TreeNode u) {
        if (root == null)
            return null;
        
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            var size = q.Count;
            
            while (size-- > 0)
            {
                var currNode = q.Dequeue();
                
                if (currNode.val == u.val)
                    return size > 0 ? q.Dequeue() : null;
                
                EnqueueChildNode(currNode.left, q);
                EnqueueChildNode(currNode.right, q);
            }
        }
        
        return null;
    }
    
    private void EnqueueChildNode(TreeNode root, Queue<TreeNode> q)
    {
        if (root != null)
            q.Enqueue(root);
    }
}