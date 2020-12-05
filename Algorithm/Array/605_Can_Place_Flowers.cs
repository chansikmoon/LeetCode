public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int ret = 0;
        
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0 &&
               (i == 0 || flowerbed[i - 1] == 0) &&
               (flowerbed.Length - 1 == i || flowerbed[i + 1] == 0))
            {
                flowerbed[i++] = 1;
                ret++;
            }
            
            if (ret >= n)
                return true;
        }
        
        return false;
    }
}