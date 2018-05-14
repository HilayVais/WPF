using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DispatcherAndBinding
{
    public class ObservableObject 
    {
        public ObservableObject()
        {
            //create the chat room
        }
       
        public bool Login(string nickname, string groupID) {//try to log in
        
            if (nickname == "hilay" & groupID == "vais")
                return true;
            return false;
        }
        public void sendMessage(string msg)
        {
            //send the message
        }

    }
}