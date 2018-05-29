using System;
using System.Collections.Generic;
using System.IO;
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
                {
                    DateTime c6 = DateTime.Now;
                    // Create a string array with the lines of text
                    string[] lines1 = { c6 + "     registaration failed  " };
                    // Write the string array to a new file named "WriteLines.txt".

                    StreamWriter outputFile1;
                    using (outputFile1 = File.AppendText(GuiChatRoom.Paths.logDBPath()))
                    {
                        foreach (string line in lines1)
                            outputFile1.WriteLine(line);
                    }

                    outputFile1.Close();
                    return false;
                }
            BussinessLayer.User u1 = new BussinessLayer.User(nickname, groupID);
            users.Add(u1);
            this.loogedInUser = u1;
            DateTime c4 = DateTime.Now;
            // Create a string array with the lines of text
            string[] lines = { c4 + "     registaration success " };
            // Write the string array to a new file named "WriteLines.txt".
            StreamWriter outputFile;
            using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            outputFile.Close();
            return DBmanager.Register(nickname, groupID); 
        }

        public Boolean LogIn(string nickname, string groupID)
        {
            BussinessLayer.User u = FindUser(nickname,groupID,true);
            if (u == null || u.GetGroupID() != groupID)
            {
                DateTime c2 = DateTime.Now;
                string[] lines = { c2 + "     login failed " };
                // Write the string array to a new file named "WriteLines.txt".

                StreamWriter outputFile;
                using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                outputFile.Close();
                return false;
            }
            else
            {
                DateTime c = DateTime.Now;
                string[] lines = { c + "    logged in " };
                // Write the string array to a new file named "WriteLines.txt".
                StreamWriter outputFile;
                using (outputFile = File.AppendText(Paths.logDBPath()))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                outputFile.Close();
                loogedInUser = u;
                return true;
            }
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

        public List<BussinessLayer.Message> Retrive10Messages()
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
            return this.messages;
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
            if (this.loogedInUser == null | msg.Length > 150)
            {
              /*  DateTime c12 = DateTime.Now;
                // Create a string array with the lines of text
                string[] lines = { c12 + "    wrong sending message " };
                // Write the string array to a new file named "WriteLines.txt".

                StreamWriter outputFile;
                using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                outputFile.Close();*/
                return false;
            }

            BussinessLayer.Message m = this.loogedInUser.SendMessage(msg, this);
            DateTime c11 = DateTime.Now;
            string[] lines = { c11 + "    message has been sent  " };
            // Write the string array to a new file named "WriteLines.txt".

            StreamWriter outputFile;
            //using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
            {
                //   foreach (string line in lines)
                //outputFile.WriteLine(line);
            }

            //outputFile.Close();
            return true;
        }

        public void LogOut()
        {
            DateTime c3 = DateTime.Now;
            // Create a string array with the lines of text
            string[] lines = { c3 + "    the user is logged out " };
            // Write the string array to a new file named "WriteLines.txt".
            StreamWriter outputFile;
            using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            outputFile.Close();
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