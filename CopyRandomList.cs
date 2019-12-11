/*
 * A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
 * Return a deep copy of the list.
 */

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
}
*/
public class Solution {
    // old -> new
    Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    
    public Node CopyRandomList(Node head) {
        if (head == null) return null;
        
        Node oldNode = head;
        Node newNode = new Node(oldNode.val, null, null);
        visited.Add(oldNode, newNode);
        
        while (oldNode != null) {
            newNode.random = GetClonedNode(oldNode.random);
            newNode.next = GetClonedNode(oldNode.next);
            
            oldNode = oldNode.next;
            newNode = newNode.next;
        }
        
        return visited[head];
    }
    
    public Node GetClonedNode (Node node) {
        if (node != null) {
            if (visited.ContainsKey(node)) {
                return visited[node];
            } else {
                visited.Add(node, new Node(node.val, null, null));
                return visited[node];
            }
        }
        return null;
    }
}
