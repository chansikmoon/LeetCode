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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode ret = new ListNode(0);
        ListNode curr = ret;
        
        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                curr.next = l1;
                l1 = l1.next;
            }
            else
            {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        
        curr.next = l1 == null ? l2 : l1;
        
        return ret.next;
    }
    
    private ListNode BruteForce(ListNode l1, ListNode l2)
    {
        ListNode ret = new ListNode(0);
        ListNode curr = ret;
        
        while (l1 != null || l2 != null)
        {
            int val1 = l1 != null ? l1.val : Int32.MaxValue;
            int val2 = l2 != null ? l2.val : Int32.MaxValue;
            
            if (val1 < val2)
            {
                curr.next = l1;
                l1 = l1.next;
            }
            else
            {
                curr.next = l2;
                l2 = l2.next;
            }
            curr = curr.next;
        }
        
        return ret.next;        
    }
}