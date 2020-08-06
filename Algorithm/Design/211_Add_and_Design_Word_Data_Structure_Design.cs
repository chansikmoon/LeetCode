public class WordDictionary {
    public TrieNode trie;

    /** Initialize your data structure here. */
    public WordDictionary() {
        trie = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        TrieNode root = trie;
        
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            
            // new character
            if (root.next[index] == null)
                root.next[index] = new TrieNode();
            
            root = root.next[index];
        }
        
        root.completed = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Traverse(word, 0, trie);
    }
    
    private bool Traverse(string word, int index, TrieNode root)
    {
        if (index >= word.Length)
            return root.completed;
        
        if (word[index] == '.')
        {
            // find next possible
            for (int i = 0; i < 26; i++)
            {
                if (root.next[i] != null && Traverse(word, index + 1, root.next[i]))
                    return true;
            }
        }
        else
        {
            int i = word[index] - 'a';
                
            if (root.next[i] != null && Traverse(word, index + 1, root.next[i]))
                return true;
        }
        
        return false;
    }
}

public class TrieNode
{
    public bool completed;
    public TrieNode[] next;
    
    public TrieNode()
    {
        completed = false;
        next = new TrieNode[26];
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */