public class Solution {
    public int CalculateTime(string k, string w) {
        var arr = new int[26];
        for (int i = 0; i < k.Length; i++)
        {
            arr[k[i] - 'a'] = i;
        }
        
        int ret = 0;
        int finger = 0;
        
        for (int i = 0; i < w.Length; i++)
        {
            int next = arr[w[i] - 'a'];
            ret += Math.Abs(next - finger);
            finger = next;
        }
        
        return ret;
    }
}