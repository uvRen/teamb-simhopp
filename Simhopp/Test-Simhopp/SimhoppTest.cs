using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Simhopp;

    [TestClass]
    public class SimhoppTest
    {
        [TestMethod]
        public void TestJudge()
        {
            Judge j1 = new Judge(1, "Michael");
            Assert.AreEqual("Michael", j1.GetJudgeName());
            j1.SetJudgeName("Thomas");
            Assert.AreEqual("Thomas", j1.GetJudgeName());
        }
    }

