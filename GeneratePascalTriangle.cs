/*
 * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
 */
 
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> triangle = new List<IList<int>>();
        if (numRows == 0) return triangle;
        
        triangle.Add(new List<int>());
        triangle[0].Add(1); // first num in each row is always 1
        
        for (int rowNum = 1; rowNum < numRows; rowNum++) {
            IList<int> row = new List<int>();
            row.Add(1); // first num in each row is always 1
            IList<int> preRow = triangle[rowNum - 1];
            
            for (int i = 1; i< rowNum; i++) {
                row.Add(preRow[i] + preRow[i-1]);
            }
            row.Add(1); // last num in each row is always 1
            triangle.Add(row);
        }
        return triangle;
    }
}
