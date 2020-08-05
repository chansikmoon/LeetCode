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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        Dictionary<string, int> countMap = new Dictionary<string, int>();
        List<TreeNode> ans = new List<TreeNode>();
        DFS(countMap, ans, root);
        
        return ans;
    }
    
    private string DFS(Dictionary<string, int> countMap, List<TreeNode> ans, TreeNode root)
    {
        if (root == null)
            return "#";
        
        string key = string.Format("{0},{1},{2}", root.val, 
                                   DFS(countMap, ans, root.left), DFS(countMap, ans, root.right));
        
        if (!countMap.ContainsKey(key))
            countMap.Add(key, 0);
        
        countMap[key]++;
        
        if (countMap[key] == 2)
            ans.Add(root);
        
        return key;
    }
}