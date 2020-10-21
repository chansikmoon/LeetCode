/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        return BFSCloneGraph(node);
    }
    
    public Node DFSCloneGraph(Node node)
    {
        if (node == null)
            return null;
        
        if (visited.ContainsKey(node))
            return visited[node];
        
        Node cloneNode = new Node(node.val);
        visited.Add(node, cloneNode);
        
        foreach (Node neighbor in node.neighbors)
        {
            cloneNode.neighbors.Add(CloneGraph(neighbor));
        }
        
        return cloneNode;
    }
    
    public Node BFSCloneGraph(Node node)
    {
        if (node == null)
            return null;
        
        Queue<Node> q = new Queue<Node>();
        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        q.Enqueue(node);
        map.Add(node, new Node(node.val));
        
        while (q.Count > 0)
        {
            Node curr = q.Dequeue();
            
            foreach (Node neighbor in curr.neighbors)
            {
                if (!map.ContainsKey(neighbor))
                {
                    map.Add(neighbor, new Node(neighbor.val));
                    q.Enqueue(neighbor);
                }
                
                map[curr].neighbors.Add(map[neighbor]);
            }
        }
        
        return map[node];
    }
}