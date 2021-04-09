/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (root == null)
            return null;

        TreeNode ret = null;

        if (root.val <= p.val)
            return InorderSuccessor(root.right, p);
        else
            ret = InorderSuccessor(root.left, p);

        return ret == null ? root : ret;
    }
}