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
    public class ChatRoomTests
    {
        [TestMethod()]
        public void LogInTest()
        {
            string url = "http://ise172.ise.bgu.ac.il:80";
            ChatRoom c1 = new ChatRoom(url);
            Assert.IsTrue(c1.LogIn("vaish","35"));//registered user
            Assert.IsFalse(c1.LogIn("in new user", "76"));//unregistered user
        }

        [TestMethod()]
        public void RegisterTest()
        {
            string url = "http://ise172.ise.bgu.ac.il:80";
            ChatRoom c1 = new ChatRoom(url);
            Assert.IsFalse(c1.Registeration("new user for tests", "65"));//unregistered user
        }

    }
}