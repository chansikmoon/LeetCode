public class Solution {
    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        return DFS(maze, start[0], start[1], destination, maze.Length, maze[0].Length);
    }

    private bool DFS(int[][] maze, int i, int j, int[] dest, int n, int m)
    {
        if (maze[i][j] == 2) return false;

        if (i == dest[0] && j == dest[1]) return true;

        maze[i][j] = 2;

        int up = i - 1, down = i + 1, left = j - 1, right = j + 1;

        // Up
        while (up >= 0 && maze[up][j] != 1) up--;
        if (DFS(maze, up + 1, j, dest, n, m)) return true;

        // right
        while (right < m && maze[i][right] != 1) right++;
        if (DFS(maze, i, right - 1, dest, n, m)) return true;

        // down
        while (down < n && maze[down][j] != 1) down++;
        if (DFS(maze, down - 1, j, dest, n, m)) return true;

        // left
        while (left >= 0 && maze[i][left] != 1) left--;
        if (DFS(maze, i, left + 1, dest, n, m)) return true;

        return false;
    }
}