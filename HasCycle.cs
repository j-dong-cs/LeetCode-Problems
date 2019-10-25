/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        /*ISet<ListNode> existNodes = new HashSet<ListNode>();
        while (head != null) {
            if (!existNodes.Add(head)) {
                return true;
            } 
            head = head.next;
        }
        return false;*/
        
        if (head == null || head.next == null) return false;
        ListNode cur = head;
        ListNode pre = head.next;
        while (cur != pre) {
            if (pre == null || pre.next == null) {
                return false;
            }
            cur = cur.next;
            pre = pre.next.next;
        }
        return true;
    }
}
