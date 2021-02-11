/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null)
            return head;
        
        var curr = head;
        while (curr != null)
        {
            var newNode = new Node(curr.val);
            newNode.next = curr.next;
            curr.next = newNode;
            curr = curr.next.next;
        }
        
        curr = head;
        while (curr != null)
        {
            curr.next.random = curr.random != null ? curr.random.next : null;
            curr = curr.next.next;
        }
        
        var oldList = head;
        var newList = head.next;
        var newHead = head.next;
        
        while (oldList != null)
        {
            oldList.next = oldList.next.next;
            newList.next = newList.next != null ? newList.next.next : null;
            oldList = oldList.next;
            newList = newList.next;
        }
        
        return newHead;
    }
}