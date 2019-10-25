/*
 * You are given a perfect binary tree where all leaves are on the same level, 
 * and every parent has two children. The binary tree has the following definition:
 * Populate each next pointer to point to its next right node. If there is no next 
 * right node, the next pointer should be set to NULL.
 * Initially, all next pointers are set to NULL.
 */ 

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node(){}
    public Node(int _val,Node _left,Node _right,Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
}
*/
public class Solution {
    public Node Connect(Node root) {
        if (root == null) return root;
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        
        while (q.Count > 0) {
            int size = q.Count;

            Node cur = null;
            for (int i = 0; i < size; i++) {
                cur = q.Dequeue();
                cur.next = (i == size - 1) ? null : q.Peek();
                if (cur.left != null) q.Enqueue(cur.left);
                if (cur.right != null) q.Enqueue(cur.right);
            }
        }
        
        return root;
    }
}C
