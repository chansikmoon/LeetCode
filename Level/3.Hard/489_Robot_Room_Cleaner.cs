/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

class Solution {
    private int[][] directions = new int[][]
    {
        new int[] {-1, 0},
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
    };
    private HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
    private Robot robot;
    
    public void CleanRoom(Robot robot) {
        this.robot = robot;
        Backtracking(0,0,0);
    }
    
    private void Backtracking(int row, int col, int dir)
    {
        visited.Add(new Tuple<int, int>(row, col));
        robot.Clean();
        
        for (int i = 0; i < 4; i++)
        {
            int newDir = (dir + i) % 4;
            int newRow = directions[newDir][0] + row;
            int newCol = directions[newDir][1] + col;
            
            if (!visited.Contains(new Tuple<int, int>(newRow, newCol)) && robot.Move())
            {
                Backtracking(newRow, newCol, newDir);
                GoBack();
            }
            
            robot.TurnRight();
        }
    }
    
    private void GoBack()
    {
        robot.TurnRight();
        robot.TurnRight();
        robot.Move();
        robot.TurnRight();
        robot.TurnRight();
    }
}