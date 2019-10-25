public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) {
            return s;
        }
        
        int curRow = 0;
        string[] zigzag = new string[numRows];
        bool goingDown = false;
        
        foreach (char c in s) {
            zigzag[curRow] += c;
            if (curRow == 0 || curRow == numRows - 1) {
                goingDown = !goingDown;
            }
            curRow += goingDown ? 1 : -1;
        }
        string answer = "";
        foreach (string row in zigzag) {
            answer += row;
        }
        return answer;
    }
}
