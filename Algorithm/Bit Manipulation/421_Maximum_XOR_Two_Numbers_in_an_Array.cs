public class Solution {
    public int FindMaximumXOR(int[] nums) {
        Trie root = new Trie();
        
        foreach (int num in nums)
        {
            Trie node = root;
            for (int i = 31; i >= 0; i--)
            {
                int curBit = (num & 1 << i) == 0 ? 0 : 1;
                if (node.children[curBit] == null)
                    node.children[curBit] = new Trie();
                node = node.children[curBit];
            }
        }
        
        int max = Int32.MinValue;;
        
        foreach (int num in nums)
        {
            Trie node = root;
            int curSum = 0;
            for (int i = 31; i >= 0; i--)
            {
                int curBit = (num & 1 << i) == 0 ? 0 : 1;
                if (node.children[curBit ^ 1] != null)
                {
                    curSum += (1 << i);
                    node = node.children[curBit ^ 1];
                }
                else
                    node = node.children[curBit];
            }
            
            max = Math.Max(max, curSum);
        }
        
        return max;
    }
}

public class Trie
{
    public Trie[] children;
    
    public Trie()
    {
        this.children = new Trie[2];
    }
}