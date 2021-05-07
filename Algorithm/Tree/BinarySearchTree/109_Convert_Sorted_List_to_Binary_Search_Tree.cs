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
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    // TC: O(nlogn)
    // SC: O(log n)    
    public TreeNode SortedListToBST(ListNode head)
    {
        return Helper(head, null);
    }

    public TreeNode Helper(ListNode head, ListNode tail)
    {
        if (head == tail)
            return null;

        var tor = head;
        var hare = head;
        // n times
        while (hare != tail && hare.next != tail)
        {
            tor = tor.next;
            hare = hare.next.next;
        }

        // half
        var root = new TreeNode(tor.val);
        root.left = Helper(head, tor);
        root.right = Helper(tor.next, tail);

        return root;
    }
    // TC: O(n)
    // SC: O(n)    
    public TreeNode BruteForce(ListNode head)
    {
        var list = new List<int>();

        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }

        return BruteForceHelper(list, 0, list.Count - 1);
    }

    private TreeNode BruteForceHelper(List<int> list, int l, int r)
    {
        if (l > r)
            return null;

        int isEven = (r - l + 1) % 2 ^ 1;
        int m = l + (r - l) / 2 + isEven;
        var root = new TreeNode(list[m]);

        root.left = BruteForceHelper(list, l, m - 1);
        root.right = BruteForceHelper(list, m + 1, r);

        return root;
    }
}