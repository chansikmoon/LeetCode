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
    public void ReorderList(ListNode head) {
        var secondHalf = GetSecondHalf(head);
        var reversedCurr = ReverseList(secondHalf);
        var curr = head;
        
        while (curr != null && reversedCurr != null)
        {
            var next = curr.next;
            var reversedNext = reversedCurr.next;
            
            curr.next = reversedCurr;
            curr.next.next = next;
            
            curr = next;
            reversedCurr = reversedNext;
        }
    }
    
    private ListNode GetSecondHalf(ListNode head)
    {
        var slow = head;
        var fast = head;
        
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var ret = slow.next;
        slow.next = null;
        
        return ret;
    }
    
    private ListNode ReverseList(ListNode curr)
    {
        ListNode prev = null;
        
        while (curr != null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        
        return prev;
    }
}