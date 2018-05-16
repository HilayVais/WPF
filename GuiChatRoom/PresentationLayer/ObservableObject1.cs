using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherAndBinding
{
    class ObservableObject1
    {
        public ObservableObject1()
        {
            //create the chat room
        }

        public bool Login(string nickname, string groupID)
        {//try to log in

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
