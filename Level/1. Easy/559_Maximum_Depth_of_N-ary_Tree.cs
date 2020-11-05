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

public class Solution {
    public int MaxDepth(Node root) {
        return Iterative(root);
    }
    
    public int Recursive(Node root)
    {
        if (root == null) return 0;
        
        int ret = 0;
        
        foreach (Node child in root.children)
        {
            ret = Math.Max(ret, MaxDepth(child));
        }
        
        return ret + 1;
    }
    
    public int Iterative(Node root)
    {
        if (root == null) return 0;
        
        Queue<Node> q = new Queue<Node>();
        
        q.Enqueue(root);
        int depth = 0;
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            for (int i = 0; i < size; i++)
            {
                Node node = q.Dequeue();
                foreach (Node child in node.children)
                    q.Enqueue(child);
            }
            
            depth++;
        }
        
        return depth;
    }
}