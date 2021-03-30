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
public class Solution
{
    private int Index { get; set; }
    private List<int> ret { get; set; }
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
    {
        ret = new List<int>();
        return DFS(root, voyage) ? ret : new List<int> { -1 };
    }

    private bool DFS(TreeNode root, int[] v)
    {
        if (root == null)
            return true;
        if (root.val != v[Index++])
            return false;
        if (root.left != null && root.left.val != v[Index])
        {
            ret.Add(root.val);
            return DFS(root.right, v) && DFS(root.left, v);
        }

        return DFS(root.left, v) && DFS(root.right, v);
    }
}