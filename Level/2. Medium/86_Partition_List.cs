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
    public ListNode Partition(ListNode head, int x) {
        var lessList = new ListNode();
        var laterList = new ListNode();
        var lessCurr = lessList;
        var laterCurr = laterList;
        
        while (head != null)
        {
            if (head.val < x)
            {
                lessCurr.next = head;
                lessCurr = lessCurr.next;
            }
            else
            {
                laterCurr.next = head;
                laterCurr = laterCurr.next;
            }
                
            head = head.next;
        }
        
        laterCurr.next = null;
        lessCurr.next = laterList.next;
        
        return lessList.next;
    }
}