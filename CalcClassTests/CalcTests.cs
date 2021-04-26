using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcClass;

namespace CalcClassTests
{
    [TestClass]
    public class CalcTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient",
            @"Server=DESKTOP-FHEOHO4\MYSQLSERVER;Database=Tests;Integrated Security=SSPI",
            "TestsAdd",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestAdd_20_plus_10_30returned()
        {
            long a = (int)TestContext.DataRow["A"];
            long b = (int)TestContext.DataRow["B"];
            long expected = (int)TestContext.DataRow["Expected"];
            long actual = Calculations.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSub_20_subtract_10_10returned()
        {
            long expected = 10;
            long actual = Calculations.Sub(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMult_20_multiple_10_200returned()
        {
            long expected = 200;
            long actual = Calculations.Mult(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDiv_20_divide_10_2returned()
        {
            long expected = 2;
            long actual = Calculations.Div(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMod_20_module_10_0returned()
        {
            long expected = 0;
            long actual = Calculations.Mod(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestABS()
        {
            long a_ = -5;
            long expected = -5;
            long actual = Calculations.ABS(a_);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIABS()
        {
            long a_ = 5;
            long expected = -5;
            long actual = Calculations.IABS(a_);

            Assert.AreEqual(expected, actual);
        }
    }
}
