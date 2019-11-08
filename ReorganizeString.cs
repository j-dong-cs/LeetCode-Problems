/*
 * Given a string S, check if the letters can be rearranged so that two characters that are adjacent to each other are not the same.
 *
 * If possible, output any possible result.  If not possible, return the empty string.
 */

public class Solution {
    public string ReorganizeString(string S) {
        int size = S.Length;
        int[] chars = new int[26];
        foreach (char c in S) {
            chars[c-'a'] += 100;
        }
        for (int i = 0; i < chars.Length; i++) {
            chars[i] += i;
        }
        chars = chars.OrderByDescending(c => c).ToArray(); // sort array in ascending order
        
        char[] answer = new char[size];
        int index = 0;
        foreach (int code in chars) {
            if (code >= 100) {
                int count = code / 100;
                char c = (char)('a' + code%100);
                if (count > (size + 1)/2) return "";
                for (int i = 0; i < count; i++) {
                    if (index >= size) index = 1;
                    answer[index] = c;
                    index += 2;
                //Console.WriteLine(new string(answer));
                }
            }
        }
        
        return new string(answer);
    }
}
