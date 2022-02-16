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
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null)
            return head;
        
        ListNode node = head.next;
        head.next = SwapPairs(head.next.next);
        node.next = head;
        
        return node;
    }
}

/*
head = 1
node = 2
-------------
head = 3
node = 4
-------------
head = null
return null
-------------
head = 3
node = 4
head.next = (from above, null)
node.next = head
return node (4 -> 3 -> null)
-------------
head = 1
node = 2
head.next = (4 -> 3 -> null)
node.next = head (1 -> 4 -> 3 -> null)
return node (2 -> 1 -> 4 -> 3 -> null)

*/