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
            Assert.AreEqual("Michael", j1.getJudgeName());
            j1.setJudgeName("Thomas");
            Assert.AreEqual("Thomas", j1.getJudgeName());
        }
    }

