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
    /*
    dummy -> 1 -> 2 -> 3 -> 4 -> 5 -> null
      s      s    s    s
      f      f    f    f    f    f      f
    
    */
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var ret = new ListNode(0);
        ret.next = head;
        var slow = ret;
        var fast = ret;

        for (int i = 0; i <= n; i++)
            fast = fast.next;

        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;

        return ret.next;
    }

    public ListNode BruteForce(ListNode head, int n)
    {
        var list = new List<ListNode>();

        while (head != null)
        {
            var tmp = head;
            list.Add(tmp);
            head = head.next;
            tmp.next = null;
        }

        list.RemoveAt(list.Count - n);

        for (int i = 1; i < list.Count; i++)
            list[i - 1].next = list[i];

        return list.Count > 0 ? list[0] : null;
    }
}