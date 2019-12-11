/*
 * There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.
 * Given the ball's start position, the destination and the maze, determine whether the ball could stop at the destination.
 * The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The start and destination coordinates are represented by row and column indexes.
 */

public class Solution {
    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        int row = maze.Length;
        int col = maze[0].Length ;
        bool[,] visited = new bool[row, col];
        int[][] dirs = new int[4][]{new int[2]{0, 1}, new int[2]{0, -1}, new int[2]{1, 0}, new int[2]{-1, 0}};
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(start);
        visited[start[0],start[1]] = true;
        while (queue.Count > 0) {
            int[] s = queue.Dequeue();
            if (s[0] == destination[0] && s[1] == destination[1]) return true;
            // Console.WriteLine($"({s[0]}, {s[1]})");
            foreach (int[] dir in dirs) {
                int x = s[0]+dir[0];
                int y = s[1]+dir[1];
                while (x >= 0 && y >= 0 && x < row && y < col && maze[x][y] == 0) {
                    x += dir[0];
                    y += dir[1];
                }
                if (!visited[x - dir[0], y - dir[1]]) {
                    queue.Enqueue(new int[] {x - dir[0], y - dir[1]});
                    visited[x - dir[0], y - dir[1]] = true;
                }
            }
        }
        return false;
    }
}
