using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuiChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiChatRoom.Tests
{
    [TestClass()]
    public class PathsTests
    {
        [TestMethod()]
        public void lastDBPathPathsTest()
        {
            StringAssert.Contains(Paths.logDBPath(), "log_file");
             return;
        }
    }
}