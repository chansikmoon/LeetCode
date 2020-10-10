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

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        List<string> ret = new List<string>();
        TraverseTree(root, ret);
        
        return string.Join(",", ret);
    }
    // 2, 1, null, null, 3, null, null
    public void TraverseTree(TreeNode root, List<string> list)
    {
        if (root == null)
        {
            list.Add("null");
            return;
        }
        
        list.Add(root.val.ToString());
        TraverseTree(root.left, list);
        TraverseTree(root.right, list);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        int index = 0;
        return InsertNode(data.Split(','), ref index);
    }
    
    public TreeNode InsertNode(string[] nodes, ref int index)
    {
        if (index >= nodes.Length || nodes[index] == "null")
        {
            index++;
            return null;
        }
            
        int val = ConvertStringToInt(nodes[index++]);
        TreeNode newNode = new TreeNode(val);
        
        newNode.left = InsertNode(nodes, ref index);
        newNode.right = InsertNode(nodes, ref index);
        
        return newNode;
    }
    
    public int ConvertStringToInt(string str)
    {
        int ret = 0;
        
        foreach (char c in str)
            ret = ret * 10 + c - '0';
        
        return ret;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;