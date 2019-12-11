/*
 * There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.
 * Given the ball's start position, the destination and the maze, find the shortest distance for the ball to stop at the destination. The distance is defined by the number of empty spaces traveled by the ball from the start position (excluded) to the destination (included). If the ball cannot stop at the destination, return -1.
 * The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The start and destination coordinates are represented by row and column indexes.
 */
 
 public class Solution {
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        int row = maze.Length;
        int col = maze[0].Length;
        int[,] distance = new int[row,col];
        int[][] dirs = new int[4][] { new int[2]{0, 1}, new int[2]{0, -1}, new int[2]{1, 0}, new int[2]{-1, 0}};
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(start);        
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                distance[i, j] = int.MaxValue;
            }
        }
        distance[start[0], start[1]] = 0;
        
        while (queue.Count > 0) {
            int[] s = queue.Dequeue();
            foreach (int[] dir in dirs) {
                int x = s[0] + dir[0];
                int y = s[1] + dir[1];
                int steps = 0;
                while (x >= 0 && y >= 0 && x < row && y < col && maze[x][y] == 0) {
                    x += dir[0];
                    y += dir[1];
                    steps++;
                }
                if (distance[s[0],s[1]] + steps < distance[x - dir[0],y - dir[1]]) {
                    queue.Enqueue(new int[]{x - dir[0], y - dir[1]});
                    distance[x - dir[0], y - dir[1]] = distance[s[0], s[1]] + steps;
                }
            }
            
        }
        
        return distance[destination[0], destination[1]] == int.MaxValue ? -1 : distance[destination[0], destination[1]];
    }
}
