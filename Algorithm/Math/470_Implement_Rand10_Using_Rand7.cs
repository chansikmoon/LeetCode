/**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
public class Solution : SolBase {
    // Time Complexity: O(1), The possibility to pick a number is 1 / p. P is 40 / 49 and each time Rand7() gets called twice. 1 / (40 / 49) * 2. 
    // 49/40 * 2 = 2.45 calls of Rand7() per Rand10()
    public int Rand10() {
        int Rand40 = 40;

        while (Rand40 >= 40)
        {
            // (Rand7() - 1) * 7 + Rand7() - 1;
            // 0 ~ 48 and we discard 40 ~ 48 because 41 - 49 is not multiple of 10.
            // Only need 0 ~ 39
            Rand40 = (Rand7() - 1) * 7 + Rand7() - 1;
        }
            
        // Rand40() % 10 + 1 gives Rand10();
        return Rand40 % 10 + 1;
    }
}