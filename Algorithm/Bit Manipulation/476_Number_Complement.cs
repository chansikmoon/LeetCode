public class Solution {
    public int FindComplement(int num) {
        int numOfBits = (int) Math.Log(num, 2);
        numOfBits += 1;
        
        int allOnes = (1 << numOfBits) - 1;
        
        return num ^ allOnes;
    }
}