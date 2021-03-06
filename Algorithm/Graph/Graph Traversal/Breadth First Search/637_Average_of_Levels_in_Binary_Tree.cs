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
    public IList<double> AverageOfLevels(TreeNode root) {
        var ret = new List<double>();
        if (root == null)
            return ret;
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            int size = q.Count, numOfNodes = 0;
            double sum = 0;
            
            while (size-- > 0)
            {
                var node = q.Dequeue();
                numOfNodes++;
                sum += (double)node.val;
                
                if (node.left != null)
                    q.Enqueue(node.left);
                
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            
            ret.Add(sum / numOfNodes);
        }
        
        return ret;
    }
}