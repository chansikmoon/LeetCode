public class Solution {
    public bool MakeEqual(string[] words) {
        if (words.Length == 1)
            return true;
        
        var count = new int[26];
        
        foreach (var word in words)
        {
            foreach (char c in word)
            {
                int idx = c - 'a';
                count[idx]++;
            }
        }

        for (int i = 0; i < count.Length; i++)
        {
            if(count[i] == 0)
                continue;
            else if (count[i] % words.Length != 0)
                return false;
        }
        
        return true;
    }
}