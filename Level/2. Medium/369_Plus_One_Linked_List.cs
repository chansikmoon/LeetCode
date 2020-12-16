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
    public ListNode PlusOne(ListNode head) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode lastNotNine = dummy, curr = head;

        while (curr != null)
        {
            if (curr.val != 9)
                lastNotNine = curr;

            curr = curr.next;
        }
        
        lastNotNine.val++;
        curr = lastNotNine.next;

        while (curr != null)
        {
            curr.val = 0;
            curr = curr.next;
        }

        return dummy.val == 1 ? dummy : dummy.next;
    }

    public ListNode BruteForce(ListNode head) 
    {
        head = Reverse(head);
        ListNode curr = head, prev = null;
        int carry = 1;
        
        while (curr != null && carry > 0)
        {
            curr.val += carry;
            carry = curr.val / 10;
            curr.val %= 10;
            prev = curr;
            curr = curr.next;
        }
        
        if (carry > 0)
            prev.next = new ListNode(carry);
        
        return Reverse(head);
    }

    public ListNode Reverse(ListNode head) 
    {
        ListNode curr = head, prev = null;
        
        while (curr != null)
        {
            ListNode tmp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = tmp;
        }
        
        return prev;
    }
}