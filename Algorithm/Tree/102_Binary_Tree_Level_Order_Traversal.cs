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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var ret = new List<IList<int>>();
        Traverse(ret, root, 0);

        return ret;
    }

    public void Traverse(List<IList<int>> list, TreeNode root, int depth)
    {
        if (root == null)
            return;

        if (list.Count <= depth)
            list.Add(new List<int>());

        Traverse(list, root.left, depth + 1);
        list[depth].Add(root.val);
        Traverse(list, root.right, depth + 1);
    }
}