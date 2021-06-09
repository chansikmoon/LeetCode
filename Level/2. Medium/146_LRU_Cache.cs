public class Cache
{
    public int Key { get; private set; }
    public int Value { get; private set; }
    public Cache(int key, int val)
    {
        Key = key;
        Value = val;
    }
    
    public void UpdateValue(int val)
    {
        Value = val;
    }
}

public class LRUCache {
    private Dictionary<int, LinkedListNode<Cache>> map;
    private LinkedList<Cache> lru;
    private int _capacity;
    
    public LRUCache(int capacity) {
        _capacity = capacity;
        map = new Dictionary<int, LinkedListNode<Cache>>();
        lru = new LinkedList<Cache>();
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key))
            return -1;
        
        var node = map[key];
        lru.Remove(node);
        lru.AddFirst(node);
        
        return node.Value.Value;
    }
    
    public void Put(int key, int value) {
        if (!map.ContainsKey(key))
        {
            var newCache = new Cache(key, value);
            var newNode = new LinkedListNode<Cache>(newCache);
            
            map.Add(key, newNode);
            lru.AddFirst(newNode);
            
            if (lru.Count > _capacity)
            {
                var toRemove = lru.Last;
                map.Remove(toRemove.Value.Key);
                lru.RemoveLast();
            }
        }
        else
        {
            var node = map[key];
            lru.Remove(node);
            node.Value.UpdateValue(value);
            lru.AddFirst(node);    
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */