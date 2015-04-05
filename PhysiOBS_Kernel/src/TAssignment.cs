using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysiOBS_Kernel
{
    public class TAssignment
    {
        public String algname;
        public String signalname;
        public int order;
                
        public TAssignment()//constructor
         {
            algname = "";
            signalname = "";
            order = 0;
         }
    
        public TAssignment(TAssignment a)
        {
            algname = a.algname;
            signalname = a.signalname;
            order = a.order;
        }
    
    }

    public class TAssignmentList : List<TAssignment>
    {
        public TAssignmentList()
        {
        }

        public TAssignment GetAssignmentBySignalName(String sn)
        {
            foreach (TAssignment a in this)
            {
                if (a.signalname == sn)
                    return a;
            }
            return null;
        }

    }

   








}
