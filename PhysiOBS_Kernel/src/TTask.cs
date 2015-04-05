using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PhysiOBS_Kernel
{
    public class TPeriod
    {
        public string ID;
        public String name;
        public Double start;
        public Double stop;
        public String comments;
    }

    public class TTask: TPeriod
    {
        public Boolean succeed;

        public TTask()
        {
            ID = "";
            name="";
            succeed = false;
            comments = "";
        }
        
        public TTask(TTask t)
        {
            ID = t.ID;
            name = t.name;
            start = t.start;
            stop = t.stop;
            comments = t.comments;
        }      
    }



    public class TTaskList : List<TTask>
    {
        public int ID;
        public TTaskList()
        {
            ID = 0;
        }

        public TTask GetTaskByName(String name)
        {
            foreach (TTask t in this)
            {
                if (t.name == name.ToLower())
                    return t;
            }
            return null;
        }

        public TTask GetTaskByID(String ID)
        {
            foreach (TTask t in this)
            {
                if (t.ID == ID)
                    return t;
            }
            return null;
        }
    }
}
