public class Solution {
    public bool IsRobotBounded(string instructions) {
        int x = 0, y = 0, dir = 0;
        var dirs = new int[4, 2] {
            {0, 1},
            {-1, 0},
            {0, -1},
            {1, 0},
        };
        
        foreach (char ins in instructions)
        {
            if (ins == 'L')
            {
                dir = (dir + 1) % 4;
            }
            else if (ins == 'R')
            {
                dir = (dir + 3) % 4;
            }
            else 
            {
                x += dirs[dir, 0];
                y += dirs[dir, 1];
            }
        }
        
        return (x == 0 && y == 0) || dir > 0;
    }
}