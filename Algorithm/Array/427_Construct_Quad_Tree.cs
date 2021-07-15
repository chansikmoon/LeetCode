/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    public Node Construct(int[][] grid) {
        int rows = grid.Length - 1, cols = grid[0].Length -1;
        return Construct(grid, 0, cols, 0, rows);
    }
    
    private Node Construct(int[][] grid, int left, int right, int top, int bottom)
    {
        Node root = null;
        
        if (Check(grid, left, right, top, bottom))
        {
            root = new Node(grid[top][left] == 1, true);
        }
        else
        {
            int rowMiddle = top + (bottom - top) / 2;
            int colMiddle = left + (right - left) / 2;
            
            root = new Node(
                false, 
                false, 
                Construct(grid, left, colMiddle, top, rowMiddle),
                Construct(grid, colMiddle + 1, right, top, rowMiddle),
                Construct(grid, left, colMiddle, rowMiddle + 1, bottom),
                Construct(grid, colMiddle + 1, right, rowMiddle + 1, bottom)
            );
        }
        
        return root;
    }
    
    private bool Check(int[][] grid, int left, int right, int top, int bottom)
    {
        int val = grid[top][left];
        
        for (int i = top; i <= bottom; i++)
        {
            for (int j = left; j <= right; j++)
                if (grid[i][j] != val)
                    return false;
        }
        
        return true;
    }
}