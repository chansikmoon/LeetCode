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
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        var secondHalfHead = GetSecondHalfLinkedListHead(head);
        var head2 = ReverseLinkedList(secondHalfHead);

        while (head != null && head2 != null)
        {
            if (head.val != head2.val)
                return false;

            head = head.next;
            head2 = head2.next;
        }

        return true;
    }

    private ListNode ReverseLinkedList(ListNode head)
    {
        ListNode prev = null;

        while (head != null)
        {
            var tmp = head.next;
            head.next = prev;
            prev = head;
            head = tmp;
        }

        return prev;
    }

    private ListNode GetSecondHalfLinkedListHead(ListNode head)
    {
        int n = GetLinkedListLength(head);
        n = n / 2 + n % 2;
        while (n-- > 0)
            head = head.next;
        return head;
    }

    private int GetLinkedListLength(ListNode head)
    {
        int n = 0;

        while (head != null)
        {
            n++;
            head = head.next;
        }

        return n;
    }
}