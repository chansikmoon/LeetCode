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
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        if (root == null)
            return null;
        
        if (d == 1)
        {
            return new TreeNode(v, root, null);
        }
        else if (d == 2)
        {
            root.left = new TreeNode(v, root.left, null);
            root.right = new TreeNode(v, null, root.right);
        }
        else
        {
            root.left = AddOneRow(root.left, v, d-1);
            root.right = AddOneRow(root.right, v, d-1);
        }
        
        return root;
    }

    public TreeNode BFS(TreeNode root, int v, int d) {
        if (root == null)
            return null;
        
        if (d == 1)
            return new TreeNode(v, root, null);
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                var node = q.Dequeue();
                
                if (d-1==1)
                {
                    node.left = new TreeNode(v, node.left, null);
                    node.right = new TreeNode(v, null, node.right);
                }
                else
                {
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
            }
            
            d--;
        }
        
        return root;
    }
}