/*
 * Given a binary tree, find its maximum depth.
 * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
 * Note: A leaf is a node with no children.
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
    
    private int answer;
    
    public int MaxDepth(TreeNode root) {
        MaxDepthHelper(root, 0);
        return answer;
    }
    
    private void MaxDepthHelper(TreeNode root, int depth) {
        if (root == null) {
            return 0;
        }
        // current node is a leaf
        if (root.left == null && root.right == null) {
            return 1;
        }
        MaxDepthHelper(root.left, depth+1);
        MaxDepthHelper(root.right, depth+1);
    }
}
