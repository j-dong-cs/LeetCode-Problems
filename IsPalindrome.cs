public class Solution {
    /*public bool IsPalindrome(int x) {
        if (x < 0) return false; // negative int is not palindrome
        return IsPalindromeHelper(x.ToString());
    }
    
    private bool IsPalindromeHelper(string s) {
        if (s.Length == 1 || s.Length == 0) {
            return true;
        }
        if (s[0] != s[s.Length-1]) {
            return false;
        }
        return IsPalindromeHelper(s.Substring(1, s.Length - 2));
    }*/
    
    public bool IsPalindrome(int x) {
        if (x < 0 || (x % 10 == 0 && x != 0)) return false; // negative number is not palindrome
        int reverse = 0;
        while (x > reverse) {
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return x == reverse || x == reverse/10;
    }
}
