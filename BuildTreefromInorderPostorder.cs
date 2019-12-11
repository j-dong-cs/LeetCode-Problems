/*
 * Given inorder and postorder traversal of a tree, construct the binary tree.
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
    int[] postorder;
    Hashtable inorderTable;
    int postIndex;
    
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        // Initialize inorder and postorder array
        this.inorder = inorder;
        this.postorder = postorder;
        postIndex = postorder.Length - 1;
        // construct a hashtable for inorder travese: value -> index
        inorderTable = new Hashtable();
        int i = 0;
        foreach (int val in inorder) {
            inorderTable.Add(val, i++);
        }
        return BuildTreeHelper(0, inorder.Length - 1);
    }
    
    public TreeNode BuildTreeHelper(int in_left, int in_right) {     
        // return null if current node has no subtree
        if (in_left > in_right) {
            return null;
        }
        // Pick the last index in postorder and assign it as the current root
        int val = postorder[postIndex];
        TreeNode root = new TreeNode(val);
        
        // Look for the index of root in inorder
        int index = (int)inorderTable[val];
        postIndex--;
        // Construct the left and right subtrees
        root.right = BuildTreeHelper(index + 1, in_right);
        root.left = BuildTreeHelper(in_left, index-1);
        
        return root;
    }
}
