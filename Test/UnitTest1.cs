using System;
using Graphics_Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_check_param()
        {
            Graphics_Object.Shape s = new Shape();
            string s1 = Graphics_Object.Form1.prepareParams("draw circle(200)", s);
            s1 = s1.Trim();
            Assert.AreEqual("200" , s1);
        }
        [TestMethod]
        public void Test_graphic_add_circle()
        {
            int actual = Graphics_Object.Form1.graphic_add_circle(2, 3);
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void Test_pro_sub()
        {
            int actual = Graphics_Object.Form1.graphic_sub_circle(5, 2);
            Assert.AreEqual(3, actual);
        }
    }
}
