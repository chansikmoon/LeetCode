public class Solution {
    private int[][] directions = new int[4][]{
        new int[]{-1, 0},
        new int[]{0, 1},
        new int[]{1, 0},
        new int[]{0, -1},
    };
    
    public int OrangesRotting(int[][] grid) {
        int numOfRows = grid.Length, numOfCols = grid[0].Length, days = 0, totalOranges = 0, orangeCount = 0;
        Queue<int[]> rottonOranges = new Queue<int[]>();
        
        for (int row = 0; row < numOfRows; row++)
        {
            for (int col = 0; col < numOfCols; col++)
            {
                if (grid[row][col] == 2)
                    rottonOranges.Enqueue(new int[]{row, col});
                if (grid[row][col] != 0)
                    totalOranges++;
            }
        }
        
        while (rottonOranges.Count > 0)
        {
            int count = rottonOranges.Count;
            orangeCount += count;
            
            while (count-- > 0)
            {
                int[] coor = rottonOranges.Dequeue();
                
                foreach (int[] dir in directions)
                {
                    int row = coor[0] + dir[0], col = coor[1] + dir[1];
                    
                    if (row < 0 || row >= numOfRows || col < 0 || col >= numOfCols || grid[row][col] != 1)
                        continue;
                    
                    grid[row][col] = 2;
                    rottonOranges.Enqueue(new int[]{row, col});
                }                
            }
            
            if (rottonOranges.Count > 0)
                days++;
        }
        
        return totalOranges == orangeCount ? days : -1;
    }
}