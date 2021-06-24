/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        // l    p    c
        // 1 -> 2 -> 3 -> 4 -> 5 -> null
        // l          p    c
        // 1 -> 2 <-> 3    4 -> 5 -> null
        // l               p    c
        // 1 -> 2 <-> 3 <- 4    5 -> null
        // l.next.next = curr
        // l -> 2 -> 5
        //        <- 3  <- 4
        // l.next = prev
        // 1 -> 4 -> 3 -> 2 -> 5 -> null
        
        var dummy = new ListNode(0);
        dummy.next = head;
        var begin = dummy;
        
        for (int i = 0; i < left - 1; i++)
            begin = begin.next;
        
        var prev = begin.next;
        var curr = prev.next;
        
        for (int i = 0; i < right - left; i++)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
            
        if (begin.next != null)
            begin.next.next = curr;
        
        begin.next = prev;
        
        return dummy.next;
    }

    public ListNode BruteForce(ListNode head, int left, int right) {
        var list = new List<ListNode>();
        
        var curr = head;
        
        while (curr != null)
        {
            var next = curr.next;
            curr.next = null;
            list.Add(curr);
            curr = next;
        }
        
        list.Reverse(left - 1, right - left + 1);
        
        for (int i = 1; i < list.Count; i++)
            list[i - 1].next = list[i];
        
        return list[0];
    }
}