using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;
using GuiChatRoom.BussinessLayer;
using GuiChatRoom.CommunicationLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuiChatRoom
{
    public class ObservableObject1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                   (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ChatRoom c1;
        public ObservableObject1()
        {
            //Console.WriteLine("bgu URL"); fixed
            string url = "http://ise172.ise.bgu.ac.il:80";
            c1 = new ChatRoom(url);
        }

        public bool Login(string nickname, string groupID) {

            Boolean log = c1.LogIn(nickname, groupID);
            if (log)
            {
                DateTime c = DateTime.Now;
                // Create a string array with the lines of text
                string[] lines = { c + "    logged in " };
                // Write the string array to a new file named "WriteLines.txt".
                StreamWriter outputFile;
                using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                outputFile.Close();
            }
            else
            {

               // Console.WriteLine("login failed, check your nickname and ID");
                DateTime c2 = DateTime.Now;
                // Create a string array with the lines of text
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
            return true;
        }

        public Boolean Register(string nickname, string groupID){
            Boolean reg = c1.Registeration(nickname, groupID);
                if (reg)
                {
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
                }
                else
                {
                    DateTime c6 = DateTime.Now;
                    // Create a string array with the lines of text
                    string[] lines = { c6 + "     registaration failed  " };
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
            return true;
            }
        public void logOut()
        {
            c1.LogOut();
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
        }
    
        public Boolean sendMessage(string msg)
        {
            {
                Boolean send = c1.SendMessage(msg);
                if (send)
                {
                    DateTime c11 = DateTime.Now;
                    // Create a string array with the lines of text
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
                else
                {
                    DateTime c12 = DateTime.Now;
                    // Create a string array with the lines of text
                    string[] lines = { c12 + "    wrong sending message " };
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
            }
        }

        public User GetUser()
        {
            return c1.GetUser();
        }

        public void retrieve10Messages()
        {
            c1.Retrive10Messages();
            DateTime c5 = DateTime.Now;
            // Create a string array with the lines of text
            string[] lines = { c5 + "    Retrive10Messages " };
            // Write the string array to a new file named "WriteLines.txt".

            StreamWriter outputFile;
            using (outputFile = File.AppendText(GuiChatRoom.Paths.logDBPath()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            outputFile.Close();
        }

        public List<Message> GetAllMessages()
        {
            return c1.GetAllMsg();
        }




    }
}
