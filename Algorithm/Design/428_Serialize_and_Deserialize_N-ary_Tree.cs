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

public class Codec {
    // Encodes a tree to a single string.
    public string serialize(Node root) {
        var ret = new List<int>();
        serializeHelper(root, ret);
        
        // Console.WriteLine(string.Join(",", ret));
        return ret.Count == 0 ? "" : string.Join(",", ret);
    }
    
    private void serializeHelper(Node root, List<int> list)
    {
        if (root == null)
            return;
        
        list.Add(root.val);
        list.Add(root.children.Count);
        
        foreach (var child in root.children)
            serializeHelper(child, list);
    }
	
    // Decodes your encoded data to tree.
    public Node deserialize(string data) {
        if (string.IsNullOrWhiteSpace(data))
            return null;
        
        var q = SplitStringAndConvertToQueue(data);
        return deserializeHelper(q);
    }
    
    private Queue<int> SplitStringAndConvertToQueue(string data)
    {
        var splits = data.Split(',');
        var q = new Queue<int>();
        
        foreach (var split in splits)
        {
            int num = 0;
            
            foreach (char c in split)
            {
                num = num * 10 + (c - '0');
            }
            
            q.Enqueue(num);
        }
        
        return q;
    }
    
    private Node deserializeHelper(Queue<int> q)
    {
        var val = q.Dequeue();
        var count = q.Dequeue();
        
        var newNode = new Node(val, new List<Node>());
        for (int i = 0; i < count; i++)
            newNode.children.Add(deserializeHelper(q));
        
        return newNode;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));