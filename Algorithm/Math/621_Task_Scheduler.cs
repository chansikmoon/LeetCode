public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] freq = new int[26];
        foreach (char task in tasks)
            freq[task - 'A']++;
        
        int mostFreq = 0, nMostFreq = 0;
        foreach (int f in freq)
            mostFreq = Math.Max(mostFreq, f);
        
        foreach (int f in freq)
            if (f == mostFreq)
                nMostFreq++;
        
        return Math.Max(tasks.Length, (mostFreq - 1) * (n + 1) + nMostFreq);
    }
}