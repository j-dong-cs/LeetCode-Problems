/*
 * Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.
 *
 * Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
 */
 
 public class Solution {
    public void SortColors(int[] nums) {
        // three-way-partition
        int p0 = 0, cur = 0;
        int p2 = nums.Length - 1;
        
        int temp = 0;
        while (cur <= p2) {
            if (nums[cur] == 0) {
                temp = nums[p0];
                nums[p0++] = nums[cur];
                nums[cur++] = temp;
            } else if (nums[cur] == 2) {
                temp = nums[p2];
                nums[p2--] = nums[cur];
                nums[cur] = temp;
            } else {
                cur++;
            }
        }
    }
    
    public void SortColorsTwoPass(int[] nums) {
        SortedDictionary<int,int> count = new SortedDictionary<int, int>();
        foreach (int n in nums) {
            if (count.ContainsKey(n)) {
                count[n] += 1;
            } else {
                count.Add(n, 1);
            }
        }
        
        int index = 0;
        foreach (var color in count) { 
            for (int i = 0; i < color.Value; i++) {
                nums[index++] = color.Key;
            }
        }
    }
}
