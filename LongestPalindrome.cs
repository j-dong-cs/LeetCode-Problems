public class Solution {
    /*public string LongestPalindrome(string s) {
        string answer = "";
        int n = s.Length;
        for (int i = n; i > 0; i--) {
            for (int j = 0; j <= n-i; j++) {
                if (isPalindrome(s.Substring(j, i).ToLower())) {
                    return s.Substring(j, i);
                }
            }
        }
        return answer;
    }
    private bool isPalindrome(string s) {
        if (s.Length == 1 || s.Length == 0) {
            return true;
        }
        if (s[0] != s[s.Length-1]) {
            return false;
        }
        return isPalindrome(s.Substring(1, s.Length-2));
    }*/
    
    public string LongestPalindrome(string s) {
        // empty or single char
        if (s.Length <= 1) {
            return s;
        }
        // create a new array to chars including all positions
        string T = String.Empty;
        for (int i = 0; i < s.Length; i++) {
            T += "#";
            T += s[i];
        }
        T += "#";
        
        int[] P = new int[T.Length];
        int C = 0, R = -1, rad = -1; // center, right boundary of current palindrome
        int center = 0, max = 0; // center and length of longest palindrome
        
        for (int i = 0; i < T.Length; i++) {
            if (i <= R) {
                rad = Math.Min(R-i, P[2*C-i]);
            } else {
                rad = 0;
            }
            // extend right boundary
            while (i+rad<T.Length && i-rad>=0 && T[i-rad]==T[i+rad]) {
                rad++;
            }            
            P[i] = rad - 1;
            if (i + rad - 1 > R) {
                C = i;
                R = i + rad - 1;
            }
            
            // locate the center and length of longest palindrome
            if (P[i] > max) {
                max = P[i];
                center = i;
            }
        }
    
        return T.Substring(center-(2*max+1)/2, 2*max+1).Replace("#", "");
    }
}
