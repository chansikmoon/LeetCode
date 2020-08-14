public class CombinationIterator {
    private Queue<string> q = new Queue<string>();
    
    public CombinationIterator(string characters, int combinationLength) {
        GenerateCombination(characters, "", 0, combinationLength, characters.Length);            
    }
    
    private void GenerateCombination(string str, string s, int index, int k, int n)
    {
        if (s.Length == k)
        {
            q.Enqueue(s);
            return;
        }
        
        for (int i = index; i < n; i++)
            GenerateCombination(str, s + str[i], i + 1, k, n);
    }
    
    public string Next() {
        return q.Dequeue();
    }
    
    public bool HasNext() {
        return q.Count > 0;
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * string param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */