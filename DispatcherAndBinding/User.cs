using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherAndBinding
{
    public class User
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string nickname;
        private string groupID;

        public User(string nickname, string groupID)
        {
            this.nickname = nickname;
            this.groupID = groupID;
        }

        public Message SendMessage(string msg, ChatRoom c1)
        {
            if (msg.Length > 150)
                return null;
            CommunicationLayer.IMessage message =
            CommunicationLayer.Communication.Send(c1.url, this.groupID, this.nickname, msg);
            Message m = new Message(message, this, groupID);

            DBmanager.AddMessagetoDB(message);
            DBmanager.AddMessagetoDB2(message);
            return m;
        }

        public string GetNickname()
        {
            return this.nickname;
        }

        public string GetGroupID()
        {
            return this.groupID;
        }
    }
}
