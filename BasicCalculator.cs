public class Solution {
    public int Calculate(string s) {
        // remove white space
        s = s.Replace(" ", "");
        
        StringBuilder sb = new StringBuilder();
        Stack<string> exp = new Stack<string>();
        
        int result = 0;
        foreach (char c in s) {
            if (!Char.IsWhiteSpace(c)) {
                if (Char.IsDigit(c)) {
                    sb.Append(c);
                } else {
                    string right_str = sb.ToString();
                    Eval(right_str, exp);
                    sb.Clear();
                    exp.Push(c + "");
                }
            }
        }
        
        Eval(sb.ToString(), exp);
        
        while (exp.Count > 0) {
            int num = int.Parse(exp.Pop());
            if (exp.Count > 0) {
                string sign = exp.Pop();
                if (sign == "+") {
                    result += num;
                } else { // "-"
                    result += -num;
                }
            } else {
                result += num;
            }
        }
        return result;
    }
    
    private void Eval(string right_str, Stack<string> exp) {
        if (exp.Count > 0 && (exp.Peek() == "*" || exp.Peek() == "/")) {
            string sign = exp.Pop();
            int left_num = int.Parse(exp.Pop());
            int right_num = int.Parse(right_str);
            int result = 0;
            if (sign == "*") {
                result = left_num * right_num;
            } else if (sign == "/") {
                result = left_num / right_num;
            }
            exp.Push(result + "");
        } else { // "+" or "-"
            exp.Push(right_str);
        }
    }
}
