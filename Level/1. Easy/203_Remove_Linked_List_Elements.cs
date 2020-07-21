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
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null)
            return head;
        
        ListNode c = head, p = head;
        
        while (c != null)
        {
            if (c.val == val)
            {
                p.next = c.next;
            }
            else
            {
                p = c;
            }

            c = c.next;
        }
        
        return head.val == val ? head.next : head;
    }
}