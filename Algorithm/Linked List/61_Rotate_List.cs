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
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null) return null;
        if (head.next == null) return head;
        
        int lengthOfNodes = 0;
        ListNode curr = head, prev = head;
        
        while (curr != null)
        {
            curr = curr.next;
            lengthOfNodes++;
        }
        
        for (int i = 0; i < k % lengthOfNodes; i++)
        {
            prev = head;
            curr = head;
            
            // h ==> head
            // p ==> prev
            // c ==> curr
            
            //                p
            //                     c
            // 1 -> 2 -> 3 -> 4 -> 5 -> null
            while (curr.next != null)
            {
                prev = curr;
                curr = curr.next;
            }

            //                p
            // h                           c
            // 1 -> 2 -> 3 -> 4 -> null    5 -> null
            prev.next = null;

            //                p
            // c    h                       
            // 5 -> 1 -> 2 -> 3 -> 4 -> null
            curr.next = head;

            //                p
            // c&h                           
            //  5  -> 1 -> 2 -> 3 -> 4 -> null
            head = curr;
        }
        
        return head;
    }

    // This is really messy. My initial thoughts.
    private ListNode BruteForce(ListNode head, int k)
    {
        if (head == null) return head;
        int n = 0;
        ListNode first = head, second = head;
        
        // find the length of nodes
        while (first != null)
        {
            first = first.next;
            n++;
        }
        
        int secondHalf = n - (k % n);
        
        // find the second half starting point
        while (secondHalf > 0)
        {
            first = second;
            second = second.next;
            secondHalf--;
        }
        
        // make the end of the first half .next null
        first.next = null;

        // find the end of the second half and make it to point to the beginning of the first half
        ListNode tempSecond = second;
        while (tempSecond != null && tempSecond.next != null)
            tempSecond = tempSecond.next;
        
        if (tempSecond != null) tempSecond.next = head;
        
        return second != null ? second : head;
    }
}