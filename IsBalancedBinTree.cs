/*
 * Given a binary tree, determine if it is height-balanced.
 * For this problem, a height-balanced binary tree is defined as:
 *
 * a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
 */

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsBalanced(TreeNode root) {
        if (root == null) return true;
        return Math.Abs(GetMaxHeight(root.left) - GetMaxHeight(root.right)) < 2 && IsBalanced(root.left) && IsBalanced(root.right);
    }
    
    private int GetMaxHeight(TreeNode root) {
        if (root == null) {
            return 0;
        }
        return 1 + Math.Max(GetMaxHeight(root.left), GetMaxHeight(root.right));
    }
}
