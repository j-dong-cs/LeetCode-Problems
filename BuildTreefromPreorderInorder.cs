/*
 * Given preorder and inorder traversal of a tree, construct the binary tree.
 *
 * Note:
 * You may assume that duplicates do not exist in the tree.
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
    int[] inorder;
    int[] preorder;
    int preIndex;
    Hashtable inorderTable;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        this.inorder = inorder;
        this.preorder = preorder;
        preIndex = 0;
        inorderTable = new Hashtable();
        
        int i = 0;
        foreach (int val in inorder) {
            inorderTable.Add(val, i++);
        }
        
        return BuildTreeHelper(0, preorder.Length - 1);
    }
    
    private TreeNode BuildTreeHelper(int in_left, int in_right) {
        if (in_left > in_right) {
            return null;
        }
        
        int val = preorder[preIndex];
        TreeNode root = new TreeNode(val);
        preIndex++;
        int index = (int)inorderTable[val];
        root.left = BuildTreeHelper(in_left, index - 1);
        root.right = BuildTreeHelper(index + 1, in_right);
        
        return root;
    }
}
