using System;
using Graphics_Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_add()
        {
            int actual = Graphics_Object.Form1.add(1, 2);
            Assert.AreEqual(actual, 3);
        }
    }
}
