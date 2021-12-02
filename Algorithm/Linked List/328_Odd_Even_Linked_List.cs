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
    public ListNode OddEvenList(ListNode head) {
        if (head == null)
            return head;
        ListNode curr = head;
        ListNode prev = null;
        ListNode secondHead = new ListNode();
        ListNode sCurr = secondHead;
        int count = 1;
        
        while (curr != null)
        {
            var next = curr.next;
            
            if ((count % 2) == 0)
            {
                sCurr.next = curr;
                sCurr = sCurr.next;
                sCurr.next = null;
                prev.next = next;
            }
            else
            {
                prev = curr;    
            }
            
            curr = next;
            count++;
        }
        
        prev.next = secondHead.next;
        
        return head;
    }
}