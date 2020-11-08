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
        Stack<int> st1 = new Stack<int>();
        Stack<int> st2 = new Stack<int>();
        
        while (l1 != null)
        {
            st1.Push(l1.val);
            l1 = l1.next;
        }
        
        while (l2 != null)
        {
            st2.Push(l2.val);
            l2 = l2.next;
        }
        
        ListNode ret = new ListNode(0);
        int carry = 0;
        while (st1.Count > 0 || st2.Count > 0)
        {
            if (st1.Count > 0)
                carry += st1.Pop();
            if (st2.Count > 0)
                carry += st2.Pop();
            
            ret.val = carry % 10;
            ListNode newNode = new ListNode(carry / 10);
            newNode.next = ret;
            carry /= 10;
            ret = newNode;
        }
        
        return ret.val == 0 ? ret.next : ret;
    }

    public ListNode AnotherSolution(ListNode l1, ListNode l2)
    {
        ListNode ret = new ListNode(0);
        ListNode curr = ret;
        List<int> list1 = ConvertListNodeToList(l1);
        List<int> list2 = ConvertListNodeToList(l2);
        int carry = 0, i = list1.Count - 1, j = list2.Count - 1;
    
        while (i >= 0 || j >= 0 || carry > 0)
        {
            if (i >= 0)
                carry += list1[i--];
            
            if (j >= 0)
                carry += list2[j--];
            
            ListNode newNode = new ListNode(carry % 10);
            carry /= 10;
            
            curr.next = newNode;
            curr = curr.next;
        }
        
        return ReverseListNode(ret.next);
    }
    
    private ListNode ReverseListNode(ListNode head)
    {
        ListNode curr = head, prev = null;
        
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        
        return prev;
    }
    
    private List<int> ConvertListNodeToList(ListNode listNode)
    {
        List<int> ret = new List<int>();
        
        while (listNode != null)
        {
            ret.Add(listNode.val);
            listNode = listNode.next;
        }
        
        return ret;
    }
}