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
    public class NicknameComparatorTests
    {
        [TestMethod()]
        public void CompareNickPathsTest()
        {
            NicknameComparator comp = new NicknameComparator();
            Assert.IsFalse(comp.CompareNick("hilay","vais") > 0);
            Assert.IsTrue(comp.CompareNick("vais", "hilay") > 0);
            Assert.IsTrue(comp.CompareNick("hilay", "hilay") ==  0);
        }
    }
}