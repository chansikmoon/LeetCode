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
    public int SumOfLeftLeaves(TreeNode root) {
        
    }

    public int IterativeSolution(TreeNode root)
    {
        int sum = 0;
        if (root == null) return sum;
        Stack<TreeNode> st = new Stack<TreeNode>();
        st.Push(root);

        while (st.Count > 0)
        {
            TreeNode node = st.Pop();

            if (node.left != null)
            {
                if (node.left.left == null && node.left.right == null)
                    sum += node.left.val;
                else
                    st.Push(node.left);
            }

            if (node.right != null && (node.right.left != null || node.right.right != null))
                st.Push(node.right);
        }

        return sum;
    }

    public int RecursiveSolution(TreeNode root)
    {
        int sum = 0;
        if (root == null) return sum;

        if (root.left != null && root.left.left == null && root.left.right == null)
            sum += root.left.val;

        return sum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
    }
}