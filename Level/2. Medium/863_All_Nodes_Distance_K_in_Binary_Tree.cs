/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        var ret = new List<int>();
        SearchKDistanceNodes(root, ret, target.val, k);
        return ret;
    }
    
    private void SearchKDistanceNodes(TreeNode root, List<int> ret, int target, int k)
    {
        var adjList = GetAdjList(root);
        
        if (k == 0)
        {
            ret.Add(target);
            return ;
        }
        
        var seen = new HashSet<int>();
        var q = new Queue<int>();
        q.Enqueue(target);
        seen.Add(target);
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                int node = q.Dequeue();
                seen.Add(node);
                
                if (k == 0)
                {
                    ret.Add(node);
                }
                else
                {
                    foreach (var next in adjList[node])
                        if (seen.Add(next))
                            q.Enqueue(next);    
                }
            }
            
            k--;
        }
        
        return;
    }
    
    private Dictionary<int, List<int>> GetAdjList(TreeNode root)
    {
        var adjList = new Dictionary<int, List<int>>();
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                var node = q.Dequeue();
                
                if (!adjList.ContainsKey(node.val))
                    adjList.Add(node.val, new List<int>());
                
                if (node.left != null)
                {
                    adjList[node.val].Add(node.left.val);
                    
                    if (!adjList.ContainsKey(node.left.val))
                        adjList.Add(node.left.val, new List<int>());
                    
                    adjList[node.left.val].Add(node.val);
                    
                    q.Enqueue(node.left);
                }
                
                if (node.right != null)
                {
                    adjList[node.val].Add(node.right.val);
                    
                    if (!adjList.ContainsKey(node.right.val))
                        adjList.Add(node.right.val, new List<int>());
                    
                    adjList[node.right.val].Add(node.val);
                    
                    q.Enqueue(node.right);
                }
            }
        }
        
        return adjList;
    }
}