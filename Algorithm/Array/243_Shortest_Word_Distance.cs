public class Solution {
    public int ShortestDistance(string[] words, string word1, string word2) {
        int index1 = -1, index2 = -1, ret = Int32.MaxValue;
        
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == word1)
                index1 = i;
            
            if (words[i] == word2)
                index2 = i;
            
            if (index1 >= 0 && index2 >= 0)
                ret = Math.Min(ret, Math.Abs(index1 - index2));
        }
        
        return ret;
    }
}