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
    public int PseudoPalindromicPaths (TreeNode root) {
        return Helper (root, 0);
        // return BruteForce(root, new Dictionary<int, int>());
    }
    
    // from Lee215
    // https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/discuss/648534/JavaC%2B%2BPython-At-most-one-odd-occurrence
    private int Helper(TreeNode root, int count)
    {
        if (root == null)
            return 0;
        
        count ^= 1 << (root.val - 1);
        int ret = Traverse(root.left, count) + Traverse(root.right, count);
        if (root.left == null && 
            root.right == null && 
            (count & (count - 1)) == 0)
            ret++;
        
        return ret;
    }
    public int BruteForce(TreeNode root, Dictionary<int, int> map)
    {
        if (root == null)
            return 0;
        
        if (!map.ContainsKey(root.val))
            map.Add(root.val, 0);
        
        map[root.val]++;
        
        int ret = 0;
        
        if (root.left == null && root.right == null)
        {
            ret = IsPalindrome(map) ? 1 : 0;
            
            SubtractAndRemove(map, root.val);
            
            return ret;
        }
            
        ret = BruteForce(root.left, map) + BruteForce(root.right, map);
        
        SubtractAndRemove(map, root.val);
        
        return ret;
    }
    
    private bool IsPalindrome(Dictionary<int, int> map)
    {
        bool oneDigitIsOdd = false;
        
        foreach (var kvp in map)
        {
            if (kvp.Value % 2 != 0)
            {
                if (oneDigitIsOdd)
                    return false;
                
                oneDigitIsOdd = true;
            }
        }
        
        return true;
    }
    
    private void SubtractAndRemove(Dictionary<int, int> map, int key)
    {
        map[key]--;
        
        if (map[key] == 0)
            map.Remove(key);
    }
}