/*Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
 *
 * Each row must contain the digits 1-9 without repetition.
 * Each column must contain the digits 1-9 without repetition.
 * Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition.
 */
 
 public class Solution {
    public bool IsValidSudoku(char[][] board) {
        Dictionary<int,int>[] rows = new Dictionary<int,int>[9];
        Dictionary<int,int>[] cols = new Dictionary<int,int>[9];
        Dictionary<int,int>[] boxes = new Dictionary<int,int>[9];
        for (int i = 0; i < 9; i++) {
            rows[i] = new Dictionary<int, int>();
            cols[i] = new Dictionary<int, int>();
            boxes[i] = new Dictionary<int, int>();
        }
        
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] != '.') {
                    int n = int.Parse(board[i][j]+"");
                    if (!rows[i].ContainsKey(n)) {
                        rows[i].Add(n, 1);
                    } else {
                        rows[i][n] += 1; 
                    }
                    
                    if (!cols[j].ContainsKey(n)) {
                        cols[j].Add(n, 1);
                    } else {
                        cols[j][n] += 1;
                    }
                    
                    int boxIndex = (i/3) * 3 + j/3;
                    if (!boxes[boxIndex].ContainsKey(n)) {     
                        boxes[boxIndex].Add(n, 1);
                    } else {
                        boxes[boxIndex][n] += 1;
                    } 
                    if (rows[i][n] > 1 || cols[j][n] > 1 || boxes[boxIndex][n] > 1) return false;
                }
            }
        }
        
        return true;
    }
}
