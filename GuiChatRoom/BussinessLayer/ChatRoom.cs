using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiChatRoom.BussinessLayer
{
    public class ChatRoom
    {
        //
        private BussinessLayer.User loogedInUser = null;
        private List<BussinessLayer.Message> messages = new List<BussinessLayer.Message>();
        private List<BussinessLayer.User> users = new List<BussinessLayer.User>();
        public string url;
        private int msgCounter;
        public ChatRoom(string url)
        {
            this.url = url;
            msgCounter = 0;
        }

        public Boolean Registeration(string nickname, string groupID)
        {
            foreach (BussinessLayer.User u in users)
                if (u.GetNickname().Equals(nickname))
                    return false;
            BussinessLayer.User u1 = new BussinessLayer.User(nickname, groupID);
            users.Add(u1);
            this.loogedInUser = u1;
            //save the new user to persistent layer
            return true;
        }

        public Boolean LogIn(string nickname, string groupID)
        {
            BussinessLayer.User u = FindUser(nickname);
            if (u == null)
                return false;
            if (u.GetGroupID() != groupID)
                return false;
            loogedInUser = u;
            return true;
        }

        private BussinessLayer.User FindUser(string nickname)
        {
            foreach (BussinessLayer.User u in users)
                if (u.GetNickname() == nickname)
                    return u;
            return null;
        }

        public void Retrive10Messages()
        {
            List<BussinessLayer.Message> Rmessages = new List<BussinessLayer.Message>();
            List<CommunicationLayer.IMessage> RImessages = CommunicationLayer.Communication.Instance.GetTenMessages(url);
            foreach (CommunicationLayer.IMessage m in RImessages)
            {
                BussinessLayer.Message Cmessage = new BussinessLayer.Message(m, this.loogedInUser);
                if (!this.messages.Contains(Cmessage))
                {
                    this.messages.Add(Cmessage);
                    Cmessage.Save();
                    msgCounter++;
                }
            }
        }

        public List<BussinessLayer.Message> Getmsg(int n)
        {
            if (n > msgCounter)
                return null;
            else
                return this.messages.GetRange(msgCounter - n, n);
        }
        public Boolean SendMessage(string msg)
        {
            if (this.loogedInUser == null)
                return false;
            if (msg.Length > 150)
                return false;
            BussinessLayer.Message m = this.loogedInUser.SendMessage(msg, this);
            messages.Add(m);
            msgCounter++;
            Retrive10Messages();
            return true;
        }

        public void LogOut()
        {
            this.loogedInUser = null;
        }
        public List<BussinessLayer.Message> GetUserMsg(string nick, string groupID)
        {
            List<BussinessLayer.Message> output = new List<BussinessLayer.Message>();
            foreach (BussinessLayer.Message m in this.messages)
                if (m.GetUser().GetNickname().Equals(nick) && m.GetUser().GetGroupID().Equals(groupID))
                    output.Add(m);
            return output;
        }
    }
}