public class WordDictionary {
    private TrieNode Trie { get; set; }
    public WordDictionary() {
        Trie = new TrieNode();
    }
    
    public void AddWord(string word) {
        var node = Trie;
        
        foreach (var c in word)
        {
            int idx = c - 'a';
            
            if (node.Children[idx] == null)
            {
                node.Children[idx] = new TrieNode();
            }
            
            node = node.Children[idx];
        }
        
        node.IsWord = true;
    }
    
    public bool Search(string word) {
        return Traverse(Trie, word, 0);
    }
    
    private bool Traverse(TrieNode node, string word, int idx) {
        if (idx >= word.Length) 
        {
            return node.IsWord;
        }
        
        if (word[idx] == '.')
        {
            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null && Traverse(node.Children[i], word, idx + 1)) 
                {
                    return true;
                }
            }
        }
        else 
        {
            int i = word[idx] - 'a';
            if (node.Children[i] != null && Traverse(node.Children[i], word, idx + 1))
            {
                return true;
            }
        }
        
        return false;
    }
}

public class TrieNode {
    public TrieNode[] Children { get; set; }
    public bool IsWord { get; set; }
    
    public TrieNode() {
        Children = new TrieNode[26];
        IsWord = false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */