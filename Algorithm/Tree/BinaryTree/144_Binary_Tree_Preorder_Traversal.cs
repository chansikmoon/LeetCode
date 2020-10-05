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
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> ret = new List<int>();
        if (root == null) return ret;
        Stack<TreeNode> st = new Stack<TreeNode>();
        st.Push(root);
        
        while (st.Count > 0)
        {
            TreeNode node = st.Pop();
            ret.Add(node.val);
            if (node.right != null) st.Push(node.right);
            if (node.left != null) st.Push(node.left);
        }
        
        return ret;
    }

    // Recursive solution
    public void Recursive(List<int> ret, TreeNode root)
    {
        if (root == null) return;

        ret.Add(root.val);
        Recursive(ret, root.left);
        Recursive(ret, root.right);
    }
}