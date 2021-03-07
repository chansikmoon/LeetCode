public class MyHashMap {
    private const int CAPACITY = 100000;
    private List<(int, int)>[] chain = new List<(int, int)>[CAPACITY];
    /** Initialize your data structure here. */
    public MyHashMap() {
        
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) {
        int hashKey = key % CAPACITY;
        chain[hashKey] = chain[hashKey] ?? new List<(int, int)>();
        
        for (int i = 0; i < chain[hashKey].Count; i++)
        {
            if (chain[hashKey][i].Item1 == key)
            {
                chain[hashKey][i] = (key, value);
                return;
            }
        }
        
        chain[hashKey].Add((key, value));
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) {
        int hashKey = key % CAPACITY;
        chain[hashKey] = chain[hashKey] ?? new List<(int, int)>();
        
        for (int i = 0; i < chain[hashKey].Count; i++)
        {
            if (chain[hashKey][i].Item1 == key)
            {
                return chain[hashKey][i].Item2;
            }
        }
        
        return -1;
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key) {
        int hashKey = key % CAPACITY;
        chain[hashKey] = chain[hashKey] ?? new List<(int, int)>();
        
        for (int i = 0; i < chain[hashKey].Count; i++)
        {
            chain[hashKey].RemoveAt(i);
            return;
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */