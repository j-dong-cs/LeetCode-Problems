public class Solution {
    public int MyAtoi(string str) {
        str = str.Trim();
        if (str == null || str == string.Empty) return 0;
        // first non-white char is not number or '+' or '-'
        if (!Char.IsDigit(str[0]) && (str[0] != '-') && (str[0] != '+')) {
            return 0;
        }
    
        bool negative = false;
        int answer = 0;
        int size = str.Length;
        if (str[0] == '-') {
            negative = true;
            str = str.Substring(1);
            size--;
        } else if (str[0] == '+') {
            str = str.Substring(1);
            size--;
        }
        
        // string starts with number
        for (int i = 0; i < size; i++) {
            if (!Char.IsDigit(str[0])) break; // stop when encounter non-digit character
            int pop = (int)Char.GetNumericValue(str[0]) * (negative ? -1 : 1);
            if (answer < Int32.MinValue/10 || (answer == Int32.MinValue/10 && pop < -8)) {
                return Int32.MinValue;
            }
            if (answer > Int32.MaxValue/10 || (answer == Int32.MaxValue/10 && pop > 7)) {
                return Int32.MaxValue;
            }
            answer = answer * 10 + pop;
            str = str.Substring(1);
        }
        return answer;
    }
}
