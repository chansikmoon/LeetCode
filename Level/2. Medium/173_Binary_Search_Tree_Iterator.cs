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
public class BSTIterator {
    public Stack<int> st;
    public BSTIterator(TreeNode root) {
        st = new Stack<int>();
        
        Traverse(root);
    }
    
    private void Traverse(TreeNode root)
    {
        if (root == null)
            return;
        Traverse(root.right);
        st.Push(root.val);
        Traverse(root.left);
    }
    
    public int Next() {
        return st.Pop();
    }
    
    public bool HasNext() {
        return st.Count > 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */