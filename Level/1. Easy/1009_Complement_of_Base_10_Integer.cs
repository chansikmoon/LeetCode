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

    public int BitwiseComplement2(int n) {
        if (n == 0)
            return 1;
        
        int num = n, bits = 0;
        
        while (num > 0)
        {
            num >>= 1;
            bits++;
        }
        
        int allOnes = (1 << bits) - 1;
        
        return n ^ allOnes;
    }
}