using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysiOBS_Kernel
{
    public class TCriticalPoint: IComparable<TCriticalPoint>
    {
        public String name;
        public Double time;
        public String Bar;
        public object obj;
             
                
        public TCriticalPoint()
         {
             name = "";
             time = 0;
             Bar = "";
             obj = null;
         }

        public TCriticalPoint(TCriticalPoint c)
        {
            name = c.name;
            time = c.time;
            Bar = c.Bar;
            obj = c.obj;
        }

        public int CompareTo(TCriticalPoint P)
        {
            return this.time.CompareTo(P.time);
        }    
     
    }


    public class TCriticalPointsList : List<TCriticalPoint>
    {
        public TCriticalPointsList()
        {
           
        }

        public void update(TPeriod t)
        {
            bool first = true;
            if (t != null)
            {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    if (this[i].obj.Equals((object)t))
                    {
                        this[i].time = (first ? t.start : t.stop);
                        first = false;
                    }
                }
            }              
            this.Sort();
        }

        public void clear_points(String S)
        {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    if (this[i].Bar == S)
                    {
                        this.RemoveAt(i);
                    }
                }
        }   

        public void clear_emotion(TEmotion E)
        {
            foreach (TCriticalPoint CP in this)
            {
                    if (CP.obj==E)
                    {
                        this.Remove(CP);
                        break;
                    }
            }
            foreach (TCriticalPoint CP in this)
            {
                if (CP.obj == E)
                {
                    this.Remove(CP);
                    break;
                }
            }
        }
        
        public void find_emotion(String Emotion)
        {

        }

        public TCriticalPoint GetNextPoint(double x, string bar="")
        {
            foreach(TCriticalPoint cp in this)
                if (cp.time > x)
                {
                    if (bar == "") return cp;
                    if (bar == cp.Bar) return cp;
                }
            return null;    
        }

        public TCriticalPoint GetPreviousPoint(double x, string bar="")
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (((TCriticalPoint)this[i]).time < x) 
                {
                   if (bar == "") return (TCriticalPoint)this[i];
                   if (bar == ((TCriticalPoint)this[i]).Bar) return (TCriticalPoint)this[i];
                }
            }
            return null;
        }
    }

}
