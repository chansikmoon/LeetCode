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
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        var st1 = new Stack<TreeNode>();
        var st2 = new Stack<TreeNode>();
        var ret = new List<int>();
        
        while (root1 != null || root2 != null || st1.Count > 0 || st2.Count > 0) {
            while (root1 != null) {
                st1.Push(root1);
                root1 = root1.left;
            }
            
            while (root2 != null) {
                st2.Push(root2);
                root2 = root2.left;
            }
            
            if (st2.Count == 0 || st1.Count > 0 && st1.Peek().val <= st2.Peek().val) {
                root1 = st1.Pop();
                ret.Add(root1.val);
                root1 = root1.right;
            }
            else {
                root2 = st2.Pop();
                ret.Add(root2.val);
                root2 = root2.right;
            }
        }
        
        return ret;
    }

    public IList<int> RecursivelyGetAllElements(TreeNode root1, TreeNode root2) {
        var ret = new List<int>();
        DFS(ret, root1);
        DFS(ret, root2);
        return ret.OrderBy(x => x).ToList();
    }
    
    private void DFS(List<int> ret, TreeNode head)
    {
        if (head == null)
            return;
        
        DFS(ret, head.left);
        ret.Add(head.val);
        DFS(ret, head.right);
    }
}