public class Solution {
    public int AddDigits(int num) {    
        return DigitalRoot(num);
    }
    
    private int DigitalRoot(int num)
    {
        // num == 18
        // 17 % 9 => 8 + 1 = 9
        // Revisited 2/8/2022
        return num == 0 ? 0 : 1 + (num - 1) % 9;
    }
    
    private int BruteForce(int num)
    {
        while (num > 9)   
        {
            int sum = 0;
            
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            
            num = sum;
        }
        
        return num;
    }
}