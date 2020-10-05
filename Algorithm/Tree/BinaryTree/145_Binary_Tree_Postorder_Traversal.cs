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
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> ret = new List<int>();
        // Recursive(ret, root);
        if (root == null) return ret;
        
        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode prev = null;
        
        while (root != null || st.Count > 0)
        {
            if (root != null)
            {
                st.Push(root);
                root = root.left;
            }
            else
            {
                root = st.Peek();
                if (root.right == null || root.right == prev)
                {
                    ret.Add(root.val);
                    prev = st.Pop();
                    root = null;
                }
                else
                    root = root.right;
            }
        }
        
        return ret;
    }
    
    private void Recursive(List<int> ret, TreeNode root)
    {
        if (root == null) return;
        
        Recursive(ret, root.left);
        Recursive(ret, root.right);
        ret.Add(root.val);
    }
}