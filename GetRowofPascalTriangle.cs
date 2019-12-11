/* 
 * Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
 * Note that the row index starts from 0.
 */

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        IList<IList<int>> triangle = new List<IList<int>>();
        triangle.Add(new List<int>());
        triangle[0].Add(1); // row @ index = 0
                
        for (int i = 1; i <= rowIndex; i++) {
            IList<int> row = new List<int>();
            row.Add(1);
            IList<int> preRow = triangle[i-1];
            
            for (int j = 1; j < i; j++) {
                row.Add(preRow[j] + preRow[j-1]);
            }
            row.Add(1);
            triangle.Add(row);
        }
        
        return triangle[rowIndex];
    }
}
