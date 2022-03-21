public class Solution {
    public IList<int> PartitionLabels(string S) {
        var last = new int[26];
        for (int i = 0; i < S.Length; i++)
            last[S[i] - 'a'] = i;
        
        var ret = new List<int>();
        int lastMaxIndex = 0, index = 0;
        for (int i = 0; i < S.Length; i++)
        {
            lastMaxIndex = Math.Max(lastMaxIndex, last[S[i] - 'a']);
            
            if (lastMaxIndex == i)
            { 
                ret.Add(lastMaxIndex - index + 1);
                index = i + 1;
            }
        }
        
        return ret;
    }
}