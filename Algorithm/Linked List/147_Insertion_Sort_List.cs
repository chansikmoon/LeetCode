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
    public ListNode InsertionSortList(ListNode head) {
        if (head == null) return head;
        
        ListNode dummy = new ListNode(0);
        ListNode prev = dummy;
        ListNode curr = head;
        ListNode next = null;
        
        while (curr != null)
        {
            next = curr.next;
            
            while (prev.next != null && prev.next.val < curr.val)
                prev = prev.next;
            
            curr.next = prev.next;
            prev.next = curr;
            curr = next;
            prev = dummy;
        }
        
        return dummy.next;
    }
}