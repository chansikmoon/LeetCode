/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null)
            return false;
        
        var tortoise = head;
        var hare = head.next;
        
        while (hare.next != null && hare.next.next != null)
        {
            if (tortoise == hare)
                return true;
            tortoise = tortoise.next;
            hare = hare.next.next;
        }
        
        return false;
    }
}