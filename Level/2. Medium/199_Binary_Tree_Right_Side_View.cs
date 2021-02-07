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
    public IList<int> RightSideView(TreeNode root) {
        var ret = new List<int>();
        // DFS(root, ret, 0);
        // ret;

        if (root == null)
            return ret;
        
        // BFS
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                var curr = q.Dequeue();
                
                if (size == 0)
                    ret.Add(curr.val);
                
                if (curr.left != null)
                    q.Enqueue(curr.left);
                
                if (curr.right != null)
                    q.Enqueue(curr.right);
            }
        }
        
        return ret;
    }

    private void DFS(TreeNode root, List<int> ret, int depth)
    {
        if (root == null)
            return;
        
        if (ret.Count == depth)
            ret.Add(root.val);
        
        DFS(root.right, ret, depth + 1);
        DFS(root.left, ret, depth + 1);
    }
}