public class StreamChecker {
    public TrieNode trie;
    public StringBuilder sb;
    
    public StreamChecker(string[] words) {
        trie = new TrieNode();
        sb = new StringBuilder();
        
        foreach (string word in words)
        {
            TrieNode root = trie;
            
            for (int i = word.Length - 1; i >= 0; i--)
            {
                if (root.next[word[i] - 'a'] == null)
                    root.next[word[i] - 'a'] = new TrieNode();
                
                root = root.next[word[i] - 'a'];
            }
            
            root.completed = true;
        }
    }
    
    public bool Query(char letter) {
        sb.Append(letter);
        TrieNode root = trie;
        
        for (int i = sb.Length - 1; i >= 0 && root != null; i--)
        {
            root = root.next[sb[i] - 'a'];
            if (root != null && root.completed)
                return true;
        }
        
        return false;
    }
}

public class TrieNode {
    public bool completed;
    public TrieNode[] next;
    
    public TrieNode()
    {
        completed = false;
        next = new TrieNode[26];
    } 
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */