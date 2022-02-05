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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0)
            return null;
        
        return Merge(lists, 0, lists.Length - 1);
    }
    // TC: O(n log n), n is the total # of nodes
    // SC: O(n)
    private ListNode BruteForce(ListNode[] lists)
    {
        var allValues= new List<int>();
        
        foreach (var list in lists)
        {
            var curr = list;
            
            while (curr != null)
            {
                allValues.Add(curr.val);
                curr = curr.next;
            }
        }
        
        var sortedValues = allValues.OrderBy(x => x).ToList();
        var ret = new ListNode(0);
        var head = ret;
        foreach (var num in sortedValues)
        {
            var tmp = new ListNode(num);
            head.next = tmp;
            head = head.next;
        }
        
        return ret.next;
    }
    
    // TC: O(N log k), k is the # of linked lists
    // SC: O(1)
    private ListNode Merge(ListNode[] lists, int left, int right)
    {
        if (left == right)
            return lists[left];
        
        int mid = left + (right - left) / 2;
        ListNode l1 = Merge(lists, left, mid);
        ListNode l2 = Merge(lists, mid+1, right);
        
        return MergeTwoList(l1, l2);
    }
    
    private ListNode MergeTwoList(ListNode l1, ListNode l2)
    {
        var ret = new ListNode(-1);
        var cur = ret;
        
        var cur1 = l1;
        var cur2 = l2;
        
        while (cur1 != null && cur2 != null)
        {
            if (cur1.val <= cur2.val)
            {
                cur.next = cur1;
                cur1 = cur1.next;
            }
            else
            {
                cur.next = cur2;
                cur2 = cur2.next;
            }
            
            cur = cur.next;
        }
        
        if (cur1 != null)
            cur.next = cur1;
        
        if (cur2 != null)
            cur.next = cur2;
        
        return ret.next;
    }

    // Update: 02/04/2022 Daily Question
    private ListNode MergeSort(ListNode[] list, int left, int right) {
        if (left == right)
            return list[left];
        
        int mid = left + (right - left) / 2;
        var l1 = MergeSort(list, left, mid);
        var l2 = MergeSort(list, mid + 1, right);
        return Merge(l1, l2);
    }
    
    private ListNode Merge(ListNode h1, ListNode h2) {
        var head = new ListNode();
        var curr = head;
        
        while (h1 != null && h2 != null) {
            var newNode = new ListNode();
            
            if (h1.val <= h2.val) {
                newNode.val = h1.val;
                h1 = h1.next;
            }
            else {
                newNode.val = h2.val;
                h2 = h2.next;
            }
            
            curr.next = newNode;
            curr = curr.next;
        }
        
        if (h1 != null) {
            curr.next = h1;
        }
        
        
        if (h2 != null) {
            curr.next = h2;
        }
        
        return head.next;
    }

}