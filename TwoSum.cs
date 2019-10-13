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
