public class TrieNode
{
    public TrieNode[] Children { get; set; } 
    public int value { get; set; }
    
    public TrieNode()
    {
        this.Children = new TrieNode[26];
        this.value = 0;
    }
}
public class MapSum {
    private TrieNode Root { get; set; }
    /** Initialize your data structure here. */
    public MapSum() {
        Root = new TrieNode();
    }
    
    public void Insert(string key, int val) {
        var currNode = Root;
        
        foreach (var c in key)
        {
            int idx = c - 'a';
            if (currNode.Children[idx] == null)
            {
                currNode.Children[idx] = new TrieNode();
            }
            
            currNode = currNode.Children[idx];
        }
        
        currNode.value = val;
    }
    
    public int Sum(string prefix) {
        var currNode = Root;
        
        foreach (var c in prefix)
        {
            int idx = c - 'a';
            if (currNode.Children[idx] == null)
            {
                return 0;
            }
            else
            {
                currNode = currNode.Children[idx];
            }
        }
        
        return DFS(currNode);
    }
    
    private int DFS(TrieNode root)
    {
        int sum = 0;
        
        if (root == null)
            return sum;
        
        foreach (var child in root.Children)
        {
            sum += DFS(child);
        }
        
        return sum + root.value;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */