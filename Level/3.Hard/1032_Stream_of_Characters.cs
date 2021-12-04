public class StreamChecker {
    private TrieNode root { get; set; }
    private StringBuilder sb { get; set; }

    public StreamChecker(string[] words) {
        root = new TrieNode();
        sb = new StringBuilder();
        
        foreach (var word in words)
        {
            var node = root;
            
            for (int i = word.Length - 1; i >= 0; i--)
            {
                int idx = word[i] - 'a';
                
                if (node.children[idx] == null)        
                    node.children[idx] = new TrieNode();
                
                node = node.children[idx];
            }
            
            node.isCompleted = true;
        }
    }
    
    public bool Query(char letter) {
        sb.Append(letter);
        var node = root;
        
        for (int i = sb.Length - 1; i >= 0 && node != null; i--)
        {
            int idx = sb[i] - 'a';
            node = node.children[idx];
            
            if (node != null && node.isCompleted)
                return true;
        }
            
        return false;
    }
}

public class TrieNode 
{
    public bool isCompleted { get; set; }
    public TrieNode[] children { get; set; }
    
    public TrieNode()
    {
        isCompleted = false;
        children = new TrieNode[26];
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */