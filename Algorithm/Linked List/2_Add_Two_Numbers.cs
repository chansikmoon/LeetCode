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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var ret = new ListNode(0);
        var curr = ret;
        int carry = 0;
        
        while (l1 != null || l2 != null || carry > 0)
        {
            var node = new ListNode(0);
            
            if (l1 != null)
            {
                node.val += l1.val;
                l1 = l1.next;
            }
            
            if (l2 != null)
            {
                node.val += l2.val;
                l2 = l2.next;
            }
            
            node.val += carry;
            carry = node.val / 10;
            node.val %= 10;
            
            curr.next = node;
            curr = curr.next;
        }
        
        return ret.next;
    }
}