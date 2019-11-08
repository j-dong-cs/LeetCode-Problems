public class Logger {
    private Dictionary<string, int> jobTracker;
    
    /** Initialize your data structure here. */
    public Logger() {
        jobTracker = new Dictionary<string, int>();
    }
    
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        // no existing job -> print
        if (!jobTracker.ContainsKey(message)) {
            jobTracker[message] = timestamp;
            return true;
        } else { // existing job -> check last timestamp -> diff > 10 -> update timestamp & print (ohterwise not print)
            if (timestamp - jobTracker[message] >= 10) {
                jobTracker[message] = timestamp;
                return true;
            }
            return false;
        }
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
