public class Solution {
    public string AlphabetBoardPath(string target) {
        int x = 0, y = 0;
        StringBuilder ret = new StringBuilder();
        
        for (int i = 0; i < target.Length; i++)
        {
            int ch = target[i] - 'a';
            int targetX = ch / 5;
            int targetY = ch % 5;
            
            // left
            if (targetY < y)
                ret.Append('L', y - targetY);
            // up
            if (targetX < x)
                ret.Append('U', x - targetX);
            // down
            if (targetX > x)
                ret.Append('D', targetX - x);
            // right
            if (targetY > y)
                ret.Append('R', targetY - y);
            
            
            ret.Append("!");
            x = targetX;
            y = targetY;
        }
        
        return ret.ToString();
    }
}