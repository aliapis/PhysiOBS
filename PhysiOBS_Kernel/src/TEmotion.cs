using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysiOBS_Kernel //Na vgazw to src apo tin katalixi!!!
{

    public class TEmotionProperties
    {
        public string name;
        public string color;
        public int order;

        public TEmotionProperties()
        {
         name="";
         color="";
         order=0;
       }

    }

    public static class TEmotionPropertiesList
    {
        public static List<TEmotionProperties> EPL;
        public static int height=7;

        static TEmotionPropertiesList()
        {
            EPL = new List<TEmotionProperties>();
            setProperties("Anger", "Red", 0);
            setProperties("Anxiety", "Orange", 1);
            setProperties("Happiness", "Green", 2);
            setProperties("Uncertainty", "Blue", 3);
            setProperties("Upset", "OrangeRed", 4);
            setProperties("Nervousness", "Coral", 5);
        }

        private static void setProperties(string name, string color, int order)
        {
            TEmotionProperties EP = new TEmotionProperties();
            EP.name = name;
            EP.color = color;
            EP.order = order;
            EPL.Add(EP);
        }
        public static TEmotionProperties GetPropertiesByName(string name)
        {
            foreach (TEmotionProperties EP in EPL)
            {
                if (EP.name == name) return EP;
            }
            return null;
        }

    }

    public class TEmotion:TPeriod
    {
        string ID;

        public TEmotion()
        {
            ID = "";
            name="";
            comments = "";
        }
        
        public TEmotion(TEmotion te)
        {
            ID = te.ID;
            name = te.name;
            start = te.start;
            stop = te.stop;
            comments = te.comments;
        }

        public TEmotionProperties GetProperties()
        {
            return TEmotionPropertiesList.GetPropertiesByName(this.name);
        }
  
    }

    public class TEmotionList : List<TEmotion>
    {
        public int AI_ID;
        public TEmotionList()
        {
            AI_ID = 0;
        }
        
        public TEmotion GetEmotionByID(string ID)
        {
            foreach(TEmotion e in this)
                if (e.ID==ID)
                    return e;
            return null;
        }

    }
}
