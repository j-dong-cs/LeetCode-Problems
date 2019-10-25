public class Solution {
    public int Reverse(int x) {
        int reverse = 0;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            if (reverse > Int32.MaxValue/10 || (reverse == Int32.MaxValue/10 && pop > 7)) return 0;
            if (reverse < Int32.MinValue/10 || (reverse == Int32.MinValue/10 && pop < -8)) return 0; 
            reverse = reverse * 10 + pop;
        }

        return reverse;
    }
}
