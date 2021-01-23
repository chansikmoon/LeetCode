public class Solution {
    public bool CloseStrings(string word1, string word2) {
        // Cleaner
        if (word1.Length != word2.Length)
            return false;
        
        int[] charCount1 = new int[26], charExist1 = new int[26]; 
        int[] charCount2 = new int[26], charExist2 = new int[26];
        
        for (int i = 0; i < word1.Length; i++)
        {
            charCount1[word1[i]-'a']++;
            charExist1[word1[i]-'a'] = 1;
            
            charCount2[word2[i]-'a']++;
            charExist2[word2[i]-'a'] = 1;
        }

        Array.Sort(charCount1);
        Array.Sort(charCount2);
        
        return charCount1.SequenceEqual(charCount2) && 
            charExist1.SequenceEqual(charExist2);
    }

    public bool BruteForce(string word1, string word2) 
    {
        if (word1.Length != word2.Length)
            return false;
        
        var arr1 = new int[26];
        var arr2 = new int[26];
        
        for (int i = 0; i < word1.Length; i++)
        {
            arr1[word1[i]-'a']++;
            arr2[word2[i]-'a']++;
        }
        
        bool flag = true;
        for (int i = 0; i < 26; i++)
            flag &= arr1[i] > 0 == arr2[i] > 0;
        
        Array.Sort(arr1);
        Array.Sort(arr2);
        
        for (int i = 0; i < 26; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        
        return flag;
    }
}