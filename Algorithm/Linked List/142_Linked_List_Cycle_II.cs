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
    public ListNode DetectCycle(ListNode head) {
        if (head == null || head.next == null)
            return null;
        
        ListNode tortoise = head, hare = head;
        
        while (hare != null && hare.next != null)
        {
            tortoise = tortoise.next;
            hare = hare.next.next;
            
            if (tortoise == hare)
                break;
        }
        
        if (hare == null || hare.next == null)
            return null;
        
        tortoise = head;
        
        while (tortoise != hare)
        {
            tortoise = tortoise.next;
            hare = hare.next;
        }
        
        return hare;
    }
}