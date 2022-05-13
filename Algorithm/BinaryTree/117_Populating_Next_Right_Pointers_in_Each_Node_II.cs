/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) {
            return root;
        }
            
        var q = new Queue<Node>();
        q.Enqueue(root);
        
        while (q.Count > 0) {
            int count = q.Count;
            
            Node right = null;
            
            while (count-- > 0) {
                var curr = q.Dequeue();
                curr.next = right;
                right = curr;
                
                if (curr.right != null) {
                    q.Enqueue(curr.right);
                }
                
                if (curr.left != null) {    
                    q.Enqueue(curr.left);
                }
            }
        }
        
        return root;
    }
}