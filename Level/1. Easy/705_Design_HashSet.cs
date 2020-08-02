public class MyHashSet {
    private Bucket[] hashSet;
    private int keyRange;
    
    /** Initialize your data structure here. */
    public MyHashSet() {    
        this.keyRange = 500;
        this.hashSet = new Bucket[this.keyRange];
        
        for (int i = 0; i < this.keyRange; i++)
            this.hashSet[i] = new Bucket();
    }
    
    private int HashFunction(int key)
    {
        return key % this.keyRange;
    }
    
    public void Add(int key) {
        int hashValue = HashFunction(key);
        this.hashSet[hashValue].Insert(key);
    }
    
    public void Remove(int key) {
        int hashValue = HashFunction(key);
        this.hashSet[hashValue].Remove(key);
    }
    
    /** Returns true if this set contains the specified element */
    public bool Contains(int key) {
        int hashValue = HashFunction(key);
        return this.hashSet[hashValue].Contains(key);
    }
}

public class Bucket{
    private LinkedList<int> bucket;
    
    public Bucket()
    {
        this.bucket = new LinkedList<int>();
    }
    
    public void Insert(int key)
    {
        if (!bucket.Contains(key))
            bucket.AddFirst(key);
    }
    
    public void Remove(int key)
    {
        bucket.Remove(key);
    }
    
    public bool Contains(int key)
    {
        return bucket.Contains(key);
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */