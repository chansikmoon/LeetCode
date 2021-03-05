/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null)
            return null;
        
        var currA = headA;
        var currB = headB;
        
        while (currA != currB)
        {
            currA = currA == null ? headB : currA.next;
            currB = currB == null ? headA : currB.next;
        }
        
        return currA;
    }
}