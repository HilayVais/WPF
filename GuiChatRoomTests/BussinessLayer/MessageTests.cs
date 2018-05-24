using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuiChatRoom.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiChatRoom.BussinessLayer.Tests
{
    [TestClass()]
    public class MessageTests
    {
        private static User u = new User("hilay", "35");
        private static string url = "http://ise172.ise.bgu.ac.il:80";
        private static Message m = new Message(CommunicationLayer.Communication.Send(url, u.GetGroupID(), u.GetNickname(), "111"), u, "35");


        [TestMethod()]
        public void EditTest()
        {
            m.Edit("new message");
            StringAssert.Contains(m.GetBody(), "new message");
        }
    }
}