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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> ret = new List<int>();
        // Recursive(ret, root);
        if (root == null) return ret;
        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode curr = root;
        
        while (curr != null || st.Count > 0)
        {
            while (curr != null)
            {
                st.Push(curr);
                curr = curr.left;
            }
            
            curr = st.Pop();
            ret.Add(curr.val);
            curr = curr.right;
        }
        
        return ret;
    }
    
    private void Recursive(List<int> ret, TreeNode root)
    {
        if (root == null) return;
        
        Recursive(ret, root.left);
        ret.Add(root.val);
        Recursive(ret, root.right);
    }
}