using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;


namespace GuiChatRoom
{
    public class GroupComparator : IComparer<Message>
    {
       public   int Compare(Message m1, Message m2)
        {
            return groupCompare(m1.GetUser().GetGroupID(),m2.GetUser().GetGroupID());      
        }
        public int groupCompare(string g1,string g2)
        {
            return g1.CompareTo(g2);
        }
    }
}
