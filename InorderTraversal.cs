//Given a binary tree, return the inorder traversal of its nodes' values.

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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> inorder = new List<int>();
        InorderTraversalHelper(inorder, root);
        return inorder;
    }
    
    private void InorderTraversalHelper(List<int> inorder, TreeNode root) {
        if (root == null) {
            return;
        }
        InorderTraversalHelper(inorder, root.left);
        inorder.Add(root.val);
        InorderTraversalHelper(inorder, root.right);
    }
}
