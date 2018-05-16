using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiChatRoom.BussinessLayer
{
    public class Message
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DateTime time;
        private string body;
        private User user;
        private string group_id;
        //	private MessageHandler messageHandler = new MessageHandler(this);

        public Message(CommunicationLayer.IMessage m, BussinessLayer.User user, string gid)
        {
            this.body = m.MessageContent;
            this.time = m.Date;
            this.user = user;
            this.group_id = gid;
            //	Save();
        }

        public void Save()
        {
            //MessageHandler.saveMassage(this);
        }
        public void Edit(string newbody)
        {
            this.body = newbody;
            //this.messageHandler

            //	this.MessageHandler.editMessageBody(this);
        }
        public BussinessLayer.User GetUser()
        {
            return this.user;
        }
        public DateTime GetTime()
        {
            return this.time;
        }

        public Boolean Equals(Message m)
        {
            return ((m.time == this.time) & (this.user == m.user) & (this.body == m.body));
        }
        public int CompareTo(Message m)
        {
            return this.time.CompareTo(m.time);
        }

    }
}
