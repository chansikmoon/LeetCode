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
        if (head == null) return;
        ListNode reorderHead = new ListNode(0), reorder = reorderHead;
        ListNode ret = head, reversedSecondHalf = GetReversedSecondHalf(head);
        
        while (head != null && reversedSecondHalf != null)
        {
            ListNode newNode = new ListNode(head.val);
            ListNode newNode1 = new ListNode(reversedSecondHalf.val);
            
            head = head.next;
            reversedSecondHalf = reversedSecondHalf.next;
            
            reorder.next = newNode;
            reorder = reorder.next;
            
            reorder.next = newNode1;
            reorder = reorder.next;
        }
        
        if (head != null)
            reorder.next = head;
        
        // 1 -> null
        ret.next = null;
        
        // 1 -> 0 -> 1 -> 4 -> 2 -> 3
        ret.next = reorderHead.next.next;
        
        // 1 -> 4 -> 2 -> 3
    }
    
    private ListNode GetReversedSecondHalf(ListNode head)
    {
        ListNode tortoise = head, hare = head;
        
        while (hare.next != null && hare.next.next != null)
        {
            tortoise = tortoise.next;
            hare = hare.next.next;
        }
        
        ListNode ret = tortoise.next;
        tortoise.next = null;
        
        return ReverseListNode(ret);
    }
    
    private ListNode ReverseListNode(ListNode head)
    {
        ListNode prev = null;
            
        while (head != null)
        {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        
        return prev;
    }
}