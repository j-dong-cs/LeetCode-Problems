/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.

Example 1:

nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:

nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5
*/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] merged = new int[nums1.Length + nums2.Length];
        int midpoint = merged.Length / 2;
        
        for (int i = 0, j = 0, k = 0; i <= midpoint; i++) {
            if ((j < nums1.Length && k < nums2.Length && nums1[j] < nums2[k]) || k == nums2.Length){
                merged[i] = nums1[j];
                j++;
            } else if (k < nums2.Length) {
                merged[i] = nums2[k];
                k++;
            }
        }
        
        if (merged.Length % 2 == 0) {            
            return (double)(merged[midpoint - 1] + merged[midpoint]) / 2;
        } else {
            return (double)merged[midpoint];
        }
    }
}
