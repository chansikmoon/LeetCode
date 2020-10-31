/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Codec {
    // Encodes an n-ary tree to a binary tree.
    public TreeNode encode(Node root) {
        if (root == null)
            return null;
        
        TreeNode ret = new TreeNode(root.val);
        if (root.children.Count > 0)
            ret.left = encode(root.children[0]);
        
        TreeNode cur = ret.left;
        
        for (int i = 1; i < root.children.Count; i++)
        {
            cur.right = encode(root.children[i]);
            cur = cur.right;
        }
        
        return ret;
    }
    

    // Decodes your binary tree to an n-ary tree.
    public Node decode(TreeNode root) {
        if (root == null)
            return null;
        
        Node ret = new Node(root.val, new List<Node>());
        TreeNode cur = root.left;
        while (cur != null)
        {
            ret.children.Add(decode(cur));
            cur = cur.right;
        }
        
        return ret;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(root));