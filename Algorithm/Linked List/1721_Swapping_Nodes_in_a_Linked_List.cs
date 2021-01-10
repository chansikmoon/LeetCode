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
    public ListNode SwapNodes(ListNode head, int k) {
        // Thought of this method but I just solved in harder way first.
        List<ListNode> list = new List<ListNode>();
        ListNode curr = head;
        
        while (curr != null)
        {
            list.Add(curr);
            curr = curr.next;
        }
        
        int kthValue = list[k-1].val;
        list[k-1].val = list[list.Count-k].val;
        list[list.Count-k].val = kthValue;
        
        for (int i = list.Count - 1; i > 0; i--)
        {
            list[i-1].next = list[i];
        }
        
        list[list.Count-1].next = null;
    
        return list[0];
    }
    
    // I did not know swaping value is allowed.
    public ListNode BruteForce(ListNode head, int k)
    {
        int totalNumOfNodes = 0, K = k;
        ListNode curr = head;
        
        while (curr != null)
        {
            totalNumOfNodes++;
            curr = curr.next;
        }
        
        int kthFromLast = totalNumOfNodes - k + 1;
        if (kthFromLast == k)
            return head;
        if (kthFromLast < k)
        {
            int tmp = k;
            k = kthFromLast;
            kthFromLast = tmp;
        }   
        
        ListNode firstNode = head;
        ListNode firstTmp = null;
        for (int i = k - 1; i > 0; i--)
        {
            firstTmp = firstNode;
            firstNode = firstNode.next;
        }
        
        ListNode lastNode = head;
        ListNode lastTmp = null;
        
        for (int i = kthFromLast - 1; i > 0; i--)
        {
            lastTmp = lastNode;
            lastNode = lastNode.next;
        }
        
        if (firstTmp != null)
            firstTmp.next = lastNode;
        
        if (lastTmp != null)
            lastTmp.next = firstNode;
        
        ListNode firstNodeNextTmp = firstNode.next;
        ListNode lastNodeNextTmp = lastNode.next;

        firstNode.next = lastNodeNextTmp;
        lastNode.next = firstNodeNextTmp == lastNode ? firstNode : firstNodeNextTmp;
        
        return k == 1 ? lastNode : head;        
    }
}