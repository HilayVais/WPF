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
    public class UserTests
    {
        [TestMethod()]
        public void SendMessagePathsTest()
        {
            
            User u = new User("hilay", "35");//more then 150 chars
            Assert.IsNull(u.SendMessage("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv",
              null));
        }
        [TestMethod()]
        public void GetGroupIDTest()
        {
            User u = new User("hilay", "35");
            StringAssert.Contains(u.GetGroupID(),"35");
        }
    }
}