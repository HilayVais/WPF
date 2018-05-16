using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.CommunicationLayer;
using System.IO;


namespace GuiChatRoom
{
    public class DBmanager
    {
       
        public static bool Register(string user, string gid)
        {
            try
            {
                // Create a string array with the lines of text
                string[] lines = { "#", user, gid };
                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = File.AppendText(Paths.UsersDBPath()))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddMessagetoDB(IMessage msg)
        {

            if (CheckIFExist(msg.Id.ToString())) return true;

            // Create a string array with the lines of text
            string[] lines = { "#", msg.Id.ToString(), msg.UserName, msg.GroupID, msg.MessageContent, msg.Date.ToString() };
            // Write the string array to a new file named "WriteLines.txt".

            StreamWriter outputFile;
            using (outputFile = File.AppendText(Paths.msgDBPath()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            outputFile.Close();

            return true;


        }
        public static bool AddMessagetoDB2(IMessage msg)
        {

            if (CheckIFExist2(msg.Id.ToString())) return true;

            // Create a string array with the lines of text
            string[] lines = { "#", msg.Id.ToString(), msg.UserName, msg.GroupID, msg.MessageContent, msg.Date.ToString() };
            // Write the string array to a new file named "WriteLines.txt".

            StreamWriter outputFile;
            using (outputFile = File.AppendText(Paths.lastmsgDBPath()))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            outputFile.Close();

            return true;


        }
        public static bool CheckIFExist(string gid_msg)
        {
            //init users db
            System.IO.StreamReader file = new System.IO.StreamReader(Paths.msgDBPath());
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line == "#")
                {

                    string id = file.ReadLine();
                    if (gid_msg.Trim().CompareTo(id.Trim()) == 0)
                    {

                        file.Close();
                        return true;
                    }
                    file.ReadLine();
                    file.ReadLine();
                    file.ReadLine();
                    file.ReadLine();
                }

            }

            file.Close();
            return false;
        }
        public static bool CheckIFExist2(string gid_msg)
        {
            //init users db
            System.IO.StreamReader file = new System.IO.StreamReader(Paths.lastmsgDBPath());
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line == "#")
                {

                    string id = file.ReadLine();
                    if (gid_msg.Trim().CompareTo(id.Trim()) == 0)
                    {

                        file.Close();
                        return true;
                    }
                    file.ReadLine();
                    file.ReadLine();
                    file.ReadLine();
                    file.ReadLine();
                }

            }

            file.Close();
            return false;
        }

        public static Stack<string> get_last_20_message(string server_url)
        {
            Stack<string> st = new Stack<string>();
            List<IMessage> last_10 = Communication.Instance.GetTenMessages(server_url);
            foreach (IMessage msg in last_10)
            {
                AddMessagetoDB2(msg);
            }




            System.IO.StreamReader file = new System.IO.StreamReader(Paths.lastmsgDBPath());
            string line;
            while ((line = file.ReadLine()) != null)
            {

                st.Push(string.Format("\n message id: {0} \n Username : {1} \n Group ID : {2} \n Message Content : {3} \n Date : {4} \n ---------------------------------------------- \n", file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine()));
            }
            file.Close();

            return st;
        }
        public static Stack<string> GETUSERMessage(string usrname, string Gid)
        {




            Stack<string> st = new Stack<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(Paths.msgDBPath());
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string id = file.ReadLine();
                string usr = file.ReadLine();
                string grid = file.ReadLine();
                if (usr == usrname && grid == Gid)
                    st.Push(string.Format("\n message id: {0} \n Username : {1} \n Group ID : {2} \n Message Content : {3} \n Date : {4} \n ---------------------------------------------- \n", id, usrname, grid, file.ReadLine(), file.ReadLine()));
            }
            file.Close();

            return st;
        }
    }
}