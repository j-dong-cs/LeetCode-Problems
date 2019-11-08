/*
 * Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
 * get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
 * put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, 
 * it should invalidate the least recently used item before inserting a new item.
 * The cache is initialized with a positive capacity.
 */

public class LRUCache {
    
    private Dictionary<int, DLinkNode> cache;
    private DLinkNode head, tail;
    
    private int capacity;
    private int count;

    public LRUCache(int capacity) {
        cache = new Dictionary<int, DLinkNode>();
        
        head = new DLinkNode();
        head.pre = null;
        
        tail = new DLinkNode();
        tail.next = null;
        
        head.next = tail;
        tail.pre = head;
        
        this.capacity = capacity;
        count = 0;
    }
    
    public int Get(int key) {
        DLinkNode node;
        if (cache.TryGetValue(key, out node)) {
            MoveToHead(node); // move the most recently used node to the front
            return node.val;
        } else { // if no existing key
            return -1;
        }
    }
    
    public void Put(int key, int val) {
        DLinkNode newNode;
        
        if (!cache.TryGetValue(key, out newNode)) { // add in newNode
            newNode = new DLinkNode(key, val);
            this.cache.Add(key, newNode);
            AddToHead(newNode);
            count++;
            
            if (count > capacity) {
                DLinkNode last = RemoveFromTail();
                cache.Remove(last.key);
                count--;
            }
        } else { // update value if key exists
            newNode.val = val;
            MoveToHead(newNode);
        }
    }
    
    // always add node the the front which represents the most recently used node
    private void AddToHead(DLinkNode node) {
        node.next = head.next;
        node.pre = head;
            
        head.next.pre = node;
        head.next = node;
    }
        
    // always remove node from the tail which represents the least recently used node
    private DLinkNode RemoveFromTail() {
        DLinkNode last = tail.pre;
        Remove(last);
        return last;
    }
        
    private void Remove(DLinkNode node) {
        node.next.pre = node.pre;
        node.pre.next = node.next;
    }
        
    // move node (most recently used one) to the head
    private void MoveToHead(DLinkNode node) {
        Remove(node);
        AddToHead(node);
    }
     
    // Dictionary<int, DLinkNode> & Double Linked List
    private class DLinkNode {
        public int key;
        public int val;
        
        public DLinkNode pre;
        public DLinkNode next;
        
        public DLinkNode() {
            key = 0;
            val = 0;
            pre = null;
            next = null;
        }
        
        public DLinkNode(int key, int val) {
            this.key = key;
            this.val = val;
            pre = null;
            next = null;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
