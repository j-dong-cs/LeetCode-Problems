/*
 * You are given coins of different denominations and a total amount of money amount. 
 * Write a function to compute the fewest number of coins that you need to make up 
 * that amount. If that amount of money cannot be made up by any combination of the 
 * coins, return -1.
 */
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        
        for (int i = 1; i <= amount; i++) {
            dp[i] = Int32.MaxValue;
            for (int j = 0; j < coins.Length; j++) {
                if (i >= coins[j] && dp[i - coins[j]] != Int32.MaxValue) {
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
                }
            }
        }
        
        return dp[amount] == Int32.MaxValue ? -1 : dp[amount];
    }
}
