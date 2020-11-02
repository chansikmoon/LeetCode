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
    public int GetDecimalValue(ListNode head) {
        int ret = 0;
        
        // 1 -> 0 -> 0 -> 1 -> 0 -> 0
        // 
        // 1:   0 | 1
        // 0:   2 | 0
        // 0:   4 | 0
        // 1:   8 | 1
        // 0:  18 | 0
        // 0:  36 | 0
        
        while (head != null)
        {
            ret = (ret << 1) | head.val;
            head = head.next;
        }
        
        return ret;
    }
}