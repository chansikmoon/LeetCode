public class Solution {
    public int BitwiseComplement(int N) {
        // find the total length of bits + 1; 
        // 8 = log2(8) + 1 => 4.
        // 1 << 4 = 10000
        int l = (int) Math.Log(N, 2) + 1;
        
        // 16(10000) - 1 = 15 (1111)
        int bitmask = (1 << l) - 1;
        
        // N = 1000 bitmask = 1111
        // N ^ bitmask = 111
        return N ^ bitmask;
    }
}