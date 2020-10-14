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
    public ListNode SortList(ListNode head) {
        return MergeSort(head);
    }
    
    private ListNode MergeSort(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        
        ListNode mid = GetMid(head);
        ListNode left = MergeSort(head);
        ListNode right = MergeSort(mid);
        
        return Merge(left, right);
    }
    
    private ListNode Merge(ListNode left, ListNode right)
    {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;
        
        while (left != null && right != null)
        {
            if (left.val < right.val)
            {
                tail.next = left;
                left = left.next;
                tail = tail.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
                tail = tail.next;
            }
        }
        
        tail.next = left != null ? left : right;
        
        return dummy.next;
    }
    
    private ListNode GetMid(ListNode fast)
    {
        ListNode slow = fast;
        
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        ListNode ret = slow.next;
        slow.next = null;
        
        return ret;
    }
}