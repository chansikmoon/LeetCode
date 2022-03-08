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

    public bool AnotherSolution(ListNode head) {
        if (head == null)
            return false;
        
        var slow = head;
        var fast = head;
        
        while (fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            
            if (slow == fast)
                return true;
        }
        
        return false;
    }
}