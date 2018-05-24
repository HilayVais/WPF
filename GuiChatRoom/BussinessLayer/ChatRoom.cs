using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuiChatRoom.BussinessLayer
{
    public class ChatRoom
    {
        private BussinessLayer.User loogedInUser = null;
        private List<BussinessLayer.Message> messages = new List<BussinessLayer.Message>();
        private List<BussinessLayer.User> users = new List<BussinessLayer.User>();
        public string url;
        private int msgCounter;
        public ChatRoom(string url)
        {
            //init users db
            System.IO.StreamReader file = new System.IO.StreamReader(Paths.UsersDBPath());
            string line;
            while ((line = file.ReadLine()) != null)
            {
                // if line ==# 
                string username = file.ReadLine();
                string gid = file.ReadLine();
                User us = new User(username, gid);
                users.Add(us);


            }

            file.Close();
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
            return DBmanager.Register(nickname, groupID); 
        }

        public Boolean LogIn(string nickname, string groupID)
        {
            BussinessLayer.User u = FindUser(nickname,groupID,true);
            if (u == null)
                return false;
            if (u.GetGroupID() != groupID)
                return false;
            loogedInUser = u;
            return true;
                  }

        private BussinessLayer.User FindUser(string nickname,string gID,Boolean  logIn)
        {
            foreach (BussinessLayer.User u in users)
                if (u.GetNickname() == nickname)
                    return u;
            if (logIn)
                return null;
            User newUser = new User(nickname, gID);
            return newUser;
        }

        public void Retrive10Messages()
        {
            List<BussinessLayer.Message> Rmessages = new List<BussinessLayer.Message>();
            List<CommunicationLayer.IMessage> RImessages = CommunicationLayer.Communication.Instance.GetTenMessages(url);
            foreach (CommunicationLayer.IMessage m in RImessages)
            {
                BussinessLayer.Message Cmessage = new BussinessLayer.Message(m, FindUser(m.UserName,m.GroupID,false), FindUser(m.UserName, m.GroupID,false).GetGroupID());
                if (containMessage(Cmessage))
                {
                    this.messages.Add(Cmessage);
                    Cmessage.Save();
                    msgCounter++;
                }
            }
        }

        public Boolean containMessage(Message m1)
        {
            foreach (Message m2 in messages)
                if (m1.Equals(m2))
                    return false;
            return true;
        }

        public List<BussinessLayer.Message> GetAllMsg()
        {
                return this.messages;
        }
        public Boolean SendMessage(string msg)
        {
            if (this.loogedInUser == null)
                return false;
            if (msg.Length > 150)
                return false;
            BussinessLayer.Message m = this.loogedInUser.SendMessage(msg, this);
           // messages.Add(m);
           //msgCounter++;
           // Retrive10Messages();
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
        public User GetUser()
        {
            return this.loogedInUser;
        }
    }
}