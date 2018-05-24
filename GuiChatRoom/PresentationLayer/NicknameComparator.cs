using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;

namespace GuiChatRoom
{
    public class NicknameComparator : IComparer<Message>
    {
        public int Compare(Message m1, Message m2)
        {
            return CompareNick(m1.GetUser().GetNickname(),m2.GetUser().GetNickname());
        }
        public int CompareNick(String nick1,String nick2)
        {
            return nick1.CompareTo(nick2);
        }
    }
}
