public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products, (a, b) => string.Compare(a, b));
        var trie = new Trie();
        var node = trie;
        
        foreach (var p in products)
        {
            node = trie;
            foreach(var c in p)
            {
                int idx = c - 'a';
                
                var next = node.GetNextNode(idx);
                next.AddWord(p);
                
                node = next;
            }
        }
        
        var ret = new List<IList<string>>();
        node = trie;
        
        foreach (var c in searchWord)
        {
            int idx = c - 'a';
            
            var next = node.GetNextNode(idx);
            ret.Add(next.GetTopThreeSuggestions());
            
            node = next;
        }
        
        return ret;
    }
}

public class Trie
{
    private List<string> words;
    private Trie[] children;
    
    public Trie()
    {
        words = new List<string>();
        children = new Trie[26];
    }
    
    public Trie GetNextNode(int i)
    {
        if (children[i] == null)
            children[i] = new Trie();
        
        return children[i];
    }
    
    public void AddWord(string word)
    {
        if (words.Count < 3)
            words.Add(word);
    }
    
    public List<string> GetTopThreeSuggestions()
    {
        return words;
    }
}