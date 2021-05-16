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
    private int camera = 0;
    private int MONITORED_NO_CAM = 0;
    private int MONITORED_WITH_CAM = 1;
    private int CAMERA_REQUIRED = 2;

    public int MinCameraCover(TreeNode root)
    {
        if (root == null)
            return 0;

        int r = Helper(root);
        // root's children are monitored but no cam. Therefore, this root node needs a camera.
        return camera + (r == CAMERA_REQUIRED ? 1 : 0);
    }

    private int Helper(TreeNode root)
    {
        if (root == null)
            return MONITORED_NO_CAM;

        int left = Helper(root.left);
        int right = Helper(root.right);

        // leaves
        if (left == MONITORED_NO_CAM && right == MONITORED_NO_CAM)
            return CAMERA_REQUIRED;

        if (left == CAMERA_REQUIRED || right == CAMERA_REQUIRED)
        {
            camera++;
            return MONITORED_WITH_CAM;
        }

        return MONITORED_NO_CAM;
    }
}