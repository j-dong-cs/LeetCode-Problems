/*
Given a string, find the length of the longest substring without repeating characters.

Example 1:

Input: "abcabcbb"
Output: 3 
Explanation: The answer is "abc", with the length of 3. 
Example 2:

Input: "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3. 
             Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/

public class Solution {
    public int LengthOfLongestSubstring(string s) {

/*        HashSet<char> substr = new HashSet<char>();        
        if (s.Length == 1) {
            return 1;
        }
        for (int i = 0; i < s.Length; i++) {
            for (int j = i; j < s.Length; j++) {
                if(!substr.Contains(s[j])) {
                    substr.Add(s[j]);
                } else {
                    if(substr.Count > longest) {
                        longest = substr.Count;
                    }
                    substr.Clear();
                    break;
                }
            }
        }*/
        
        int n = s.Length;
        int longest = 0;
        Dictionary<int, int> substr = new Dictionary<int, int>();
        int i = 0, j = 0;
        
        while (i < n && j < n) {
            if (!substr.ContainsKey(s[j])) {
                substr.Add(s[j], j);
            } else {
                i = Math.Max(substr[s[j]] + 1, i);
                substr[s[j]] = j;
            }
            longest = Math.Max(longest, j - i + 1);
            j++;
        }
        return longest;
    }
}
