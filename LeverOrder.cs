// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> preorder = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        if (root != null) {
            q.Enqueue(root);
        }
        TreeNode cur;
        while (q.Count != 0) {
            int size = q.Count;
            IList<int> level = new List<int>();
            for (int i = 0; i < size; i++) {
                cur = q.Dequeue();
                level.Add(cur.val);
                if (cur.left != null) {
                    q.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    q.Enqueue(cur.right);
                }
            }
            preorder.Add(level);
        }
        return preorder;
    }
}
