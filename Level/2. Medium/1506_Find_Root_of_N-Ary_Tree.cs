/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public Node FindRoot(List<Node> tree) {
        if (tree == null || tree.Count == 0)
            return null;
        
        long sum = 0;
        
        foreach (Node node in tree)
        {
            sum += node.val;
            
            foreach (Node child in node.children)
                sum -= child.val;
        }
        
        foreach (Node node in tree)
            if (node.val == sum)
                return node;
        
        return null;
    }
}