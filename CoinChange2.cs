/*
 * You are given coins of different denominations and a total amount of money. 
 * Write a function to compute the number of combinations that make up that 
 * amount. You may assume that you have infinite number of each kind of coin.
 */
public class Solution {
    public int Change(int amount, int[] coins) {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        
        foreach (int coin in coins) {
            for (int i = coin; i <= amount; i++) {
                dp[i] += dp[i-coin];
            }
        }
        
        return dp[amount];
    }
}
