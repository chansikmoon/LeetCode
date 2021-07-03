/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    private int buffIndex = 0;
    private int buffCount = 0;
    private char[] buff = new char[4];
    public int Read(char[] buf, int n) {
        int index = 0;
        
        while (index < n)
        {
            if (buffIndex == 0)
                buffCount = Read4(buff);
            
            if (buffCount == 0)
                break;
            
            while (index < n && buffIndex < buffCount)
                buf[index++] = buff[buffIndex++];
            
            if (buffIndex >= buffCount)
                buffIndex = 0;
        }
        
        return index;
    }
}