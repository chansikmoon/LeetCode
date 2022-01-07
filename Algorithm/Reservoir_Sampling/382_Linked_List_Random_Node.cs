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

 // https://en.wikipedia.org/wiki/Reservoir_sampling
 
 public class Solution {
    Random rand = new Random();
    ListNode head;
    /** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */
    public Solution(ListNode head) {
        this.head = head;
    }
    
    /** Returns a random node's value. */
    public int GetRandom() {        
        ListNode curr = head;
        int n = 1, ret = curr.val;
        
        while (curr.next != null)
        {
            curr = curr.next;
            n++;
            
            if (rand.Next(n) == 0)
                ret = curr.val;
        }
        
        return ret;
    }
}


/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */

public class Solution1 {
    private Dictionary<int, int> map;
    private Random rand;

    public Solution(ListNode head) {
        rand = new Random();
        map = new Dictionary<int, int>();
        int key = 0;
        
        while (head != null)
        {
            map.Add(key++, head.val);
            head = head.next;
        }
    }
    
    public int GetRandom() {
        int index = rand.Next(map.Count);
        
        return map[index];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */