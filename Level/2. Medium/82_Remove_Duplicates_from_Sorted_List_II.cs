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
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode ret = new ListNode(0);
        ListNode retCurr = ret;
        ListNode curr = head;
        
        while (curr != null)
        {
            ListNode next = curr.next;
            bool duplicate = false;
            while (next != null && curr.val == next.val)
            {
                duplicate = true;
                next = next.next;
            }
            
            if (!duplicate)
            {
                curr.next = null;
                retCurr.next = curr;
                retCurr = retCurr.next;
            }
            
            curr = next;
        }
        
        return ret.next;
    }

    public ListNode AnotherVersion(ListNode head)
    {
        if (head == null)
            return null;

        ListNode ret = new ListNode(0);
        ListNode prev = ret;
        ListNode curr = head;
        prev.next = head;

        while (curr != null)
        {
            while (curr.next != null && curr.val == curr.next.val)
                curr = curr.next;

            if (prev.next == curr)
                prev = prev.next;
            else
                prev.next = curr.next;
            
            curr = curr.next;
        }

        return ret = ret.next;
    }
}