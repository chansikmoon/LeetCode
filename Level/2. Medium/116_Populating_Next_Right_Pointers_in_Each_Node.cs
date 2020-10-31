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
        if (root == null) return root;
        
        Node pre = root, curr = null;
        
        while (pre.left != null)
        {
            curr = pre;
            
            while (curr != null)
            {
                curr.left.next = curr.right;
                curr.right.next = curr.next != null ? curr.next.left : null;
                curr = curr.next;
            }
            
            pre = pre.left;
        }
        
        return root; 
    }
    
    public Node RecursiveSolution(Node root)
    {
        Connect(root, null);
        return root;
    }
    
    public void Connect(Node root, Node next)
    {
        if (root == null) return;
        
        root.next = next;
        
        Connect(root.left, root.right);
        Connect(root.right, next != null ? next.left : null);
    }
}