namespace Models
{
    public class Activity
    {
        public string ID;
        public string desc;
        public string ammount;
        public string activityID;
        public string activityName;
        public string activityTypeID;
        public string activityTypeName;
        static public string[] type = { "Income", "Expense" };
    }
}
