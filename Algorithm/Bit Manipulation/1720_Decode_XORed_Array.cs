public class Solution {
    public int[] Decode(int[] encoded, int first) {
        var ret = new int[encoded.Length + 1];
        ret[0] = first;
        
        for (int i = 1; i < ret.Length; i++)
        {
            ret[i] = encoded[i-1] ^ ret[i-1];
        }
        
        return ret;
    }
}