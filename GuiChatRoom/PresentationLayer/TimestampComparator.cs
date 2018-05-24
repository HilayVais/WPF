using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;

namespace GuiChatRoom
{
   public class TimestampComparator : IComparer<Message>
    {
        public int Compare(Message m1, Message m2)
        {
            return timeCompare(m1.GetTime(),m2.GetTime());
        }
        public int timeCompare(DateTime d1,DateTime d2)
        {
            return d1.CompareTo(d2);
        }
    }
}
