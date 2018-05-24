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
    public class GroupComparatorTests
    {
        [TestMethod()]
        public void groupComparePathsTest()
        {
            GroupComparator comp = new GroupComparator();
            Assert.IsFalse(comp.groupCompare("50", "61") > 0);
            Assert.IsTrue(comp.groupCompare("85", "19") > 0);
            Assert.IsTrue(comp.groupCompare("15", "15") == 0);
        }
    }
}