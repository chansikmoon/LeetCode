public class Solution {
    public class TrieNode
    {
        public int Index { get; set; }
        public List<int> ListOfPalindromeIndex { get; set; }
        public TrieNode[] Next { get; set; }

        public TrieNode ()
        {
            this.Index = -1;
            this.ListOfPalindromeIndex = new List<int>();
            this.Next = new TrieNode[26];
        }
        
        public void AddPalindromeIndex(int index)
        {
            this.ListOfPalindromeIndex.Add(index);
        }
        
        public void SetIndex(int index)
        {
            this.Index = index;
        }
    }
    
    public void AddWord(TrieNode root, string word, int index)
    {
        for (int i = word.Length - 1; i >= 0; i--)
        {
            int nextIdx = word[i] - 'a';
            
            if (root.Next[nextIdx] == null)
                root.Next[nextIdx] = new TrieNode();
            
            if (IsPalindrome(word, 0, i))
                root.AddPalindromeIndex(index);
            
            root = root.Next[nextIdx];
        }
        
        root.AddPalindromeIndex(index);
        root.SetIndex(index);
    }
    
    public void SearchWord(List<IList<int>> ret, TrieNode root, string word, int index)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (root.Index >= 0 && root.Index != index && IsPalindrome(word, i, word.Length - 1))
                ret.Add(new List<int>() { index, root.Index } );
            
            root = root.Next[word[i] - 'a'];
            
            if (root == null)
                return;
        }
        
        foreach (var list in root.ListOfPalindromeIndex)
        {
            if (list == index) continue;
            ret.Add(new List<int>() { index, list });
        }
        
        return;
    }
    
    public IList<IList<int>> PalindromePairs(string[] words) {
        var root = new TrieNode();
        
        for (int i = 0; i < words.Length; i++)
            AddWord(root, words[i], i);
        
        var ret = new List<IList<int>>();
        
        for (int i = 0; i < words.Length; i++)
            SearchWord(ret, root, words[i], i);
        
        return ret;
    }
    
    private bool IsPalindrome(string str, int left, int right)
    {
        while (left < right)
        {
            if (str[left++] != str[right--])
                return false;
        }
        
        return true;
    }
}