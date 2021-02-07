public class Solution {
    public int[] ShortestToChar(string s, char c) {
        int n = s.Length, pos = -s.Length;
        var ret = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            if (s[i] == c)
                pos = i;
            ret[i] = i - pos;
        }
        
        for (int i = pos; i >= 0; i--)
        {
            if (s[i] == c)
                pos = i;
            ret[i] = Math.Min(ret[i], pos - i);
        }
        
        return ret;
    }
    
    private int[] BruteForce(string s, char c) {
        var q = new Queue<int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
                q.Enqueue(i);
        }
        
        var ret = new int[s.Length];
        for (int i = 0, prev = Int32.MaxValue; i < s.Length; i++)
        {
            if (q.Count > 0 && q.Peek() < i)
                prev = q.Dequeue();
                
            int next = q.Count > 0 ? q.Peek() : Int32.MaxValue;
            
            ret[i] = Math.Min(next - i, Math.Abs(prev - i));
        }
        
        return ret;
    }
}