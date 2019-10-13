/*
1. Two Sum
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {        
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i+1; j < nums.Length; j++) {
                if (nums[j] == target - nums[i]) {
                    return new int[] {i, j};
                }
            }
        }
        throw new ArgumentException("No two sum solution");
    }
//    public int[] TwoSum(int[] nums, int target) {
//        Dictionary<int, int> dic = new Dictionary<int, int>();
//        for (int i = 0; i < nums.Length; i++) {
//            dic.Add(i, nums[i]);   
//        }
//        
//        for (int i = 0; i < nums.Length; i++) {
//            int complement = target - nums[i];
//            if (dic.ContainsValue(complement)) {
//                foreach (KeyValuePair<int, int> kvp in dic) {
//                    if (kvp.Value == complement && kvp.Key != i) {
//                        return new int[] {i, kvp.Key};
//                    }
//                }
//            }
//            
//        }
//        throw new ArgumentException("No two sum solution");
//    }
}
