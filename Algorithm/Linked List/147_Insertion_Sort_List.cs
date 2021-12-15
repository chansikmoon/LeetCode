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
        var dummy = new ListNode();
        var prev = dummy;
        var curr = head;
        
        while (curr != null)
        {
            var next = curr.next;
            
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