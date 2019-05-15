using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTYS_Mobilay_Magazasi
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
