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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        Dictionary<int, Dictionary<int,List<int>>> map = new Dictionary<int, Dictionary<int,List<int>>>();
        
        Traverse(root, map, 0, 0);
        
        List<IList<int>> ans = new List<IList<int>>();

        foreach (var xkvp in map.OrderBy(x => x.Key))
        {
            List<int> tmp = new List<int>();
            
            foreach (var ykvp in map[xkvp.Key].OrderBy(y => y.Key))
                foreach (int val in ykvp.Value.OrderBy(z => z))
                    tmp.Add(val);

            ans.Add(tmp);
        }

        return ans;
    }
    
    private void Traverse(TreeNode root, Dictionary<int, Dictionary<int, List<int>>> map, int x, int y)
    {
        if (root == null) return;
        
        if (!map.ContainsKey(x))
            map.Add(x, new Dictionary<int, List<int>>());
        
        if (!map[x].ContainsKey(y))
            map[x].Add(y, new List<int>());
        
        map[x][y].Add(root.val);
        
        Traverse(root.left, map, x - 1, y + 1);
        Traverse(root.right, map, x + 1, y + 1);
    }
}