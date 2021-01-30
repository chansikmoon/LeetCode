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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var map = new Dictionary<int, Dictionary<int, List<int>>>();
        
        Traverse(root, map, 0, 0);
        
        var ret = new List<IList<int>>();
        
        foreach (var col in map.Keys.OrderBy(x => x))
        {
            var tmp = new List<int>();
            foreach (var row in map[col].Keys.OrderBy(x => x))
            {
                foreach (var num in map[col][row])
                    tmp.Add(num);
            }
            
            ret.Add(tmp);
        }
        
        return ret;
    }
    
    private void Traverse(TreeNode root, Dictionary<int, Dictionary<int, List<int>>> map, int row, int col)
    {
        if (root == null)
            return;
        
        if (!map.ContainsKey(col))
            map.Add(col, new Dictionary<int, List<int>>());
        
        if (!map[col].ContainsKey(row))
            map[col].Add(row, new List<int>());
        
        map[col][row].Add(root.val);
        
        Traverse(root.left, map, row + 1, col - 1);
        Traverse(root.right, map, row + 1, col + 1);
    }
}