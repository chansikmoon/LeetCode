// Learn from Lee's solution
// https://leetcode.com/problems/maximum-frequency-stack/discuss/163410/C%2B%2BJavaPython-O(1)
// revisited on 03/19/2022
public class OptimalFreqStack {
    private Dictionary<int, int> freqMap;
    private Dictionary<int, Stack<int>> freqToStackMap;
    private int mostFreqNum;
    
    public OptimalFreqStack() {
        mostFreqNum = 0;
        freqMap = new Dictionary<int, int>();
        freqToStackMap = new Dictionary<int, Stack<int>>();
    }
    
    public void Push(int x) {
        if (!freqMap.ContainsKey(x))
            freqMap.Add(x, 0);
        
        mostFreqNum = Math.Max(mostFreqNum, ++freqMap[x]);
        
        if (!freqToStackMap.ContainsKey(freqMap[x]))
            freqToStackMap.Add(freqMap[x], new Stack<int>());
        
        freqToStackMap[freqMap[x]].Push(x);
    }
    
    public int Pop() {
        int ret = freqToStackMap[mostFreqNum].Pop();
        
        freqMap[ret]--;
        
        if (freqToStackMap[mostFreqNum].Count == 0)
            mostFreqNum--;
        
        return ret;
    }
}

// Brute force solution
public class FreqStack {
    private int mostFreq;
    private Dictionary<int, int> freqMap;
    private Stack<int> st;
    
    public FreqStack() {
        this.mostFreq = 0;
        this.freqMap = new Dictionary<int, int>();
        this.st = new Stack<int>();        
    }
    
    public void Push(int x) {
        this.st.Push(x);
        
        if (!this.freqMap.ContainsKey(x))
            this.freqMap.Add(x, 0);
        
        this.freqMap[x]++;
        this.mostFreq = Math.Max(this.mostFreq, this.freqMap[x]);
    }
    
    public int Pop() {
        var tmpSt = new Stack<int>();
        
        while (this.freqMap[this.st.Peek()] != this.mostFreq)
            tmpSt.Push(this.st.Pop());
        
        int ret = this.st.Pop();
        
        while (tmpSt.Count > 0)
            this.st.Push(tmpSt.Pop());
        
        UpdateFreqMap(ret);
        UpdateMostFreq();
        
        return ret;
    }
    
    private void UpdateFreqMap(int key)
    {
        this.freqMap[key]--;
        
        if (this.freqMap[key] == 0)
            this.freqMap.Remove(key);
    }
    
    private void UpdateMostFreq()
    {
        this.mostFreq = 0;
        
        foreach (var kvp in this.freqMap)
        {
            this.mostFreq = Math.Max(this.mostFreq, kvp.Value);
        }
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */