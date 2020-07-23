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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> retval = new List<IList<int>>();
        Traversal(root, 1, retval);
        return retval;
    }
    
    private void Traversal(TreeNode root, int depth, List<IList<int>> retval)
    {
        if (root == null)
            return;
        
        if (depth > retval.Count)
            retval.Add(new List<int>());
        
        if (depth % 2 == 1)
            retval[depth - 1].Add(root.val);
        else
            retval[depth - 1].Insert(0, root.val);
        
        Traversal(root.left, depth + 1, retval);
        Traversal(root.right, depth + 1, retval);
    }
}