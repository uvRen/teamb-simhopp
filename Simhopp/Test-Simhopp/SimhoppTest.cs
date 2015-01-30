

using Simhopp;

namespace Nunit.Simhopp
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class JudgeTest
    {
        private Competition comp;
        private Judge j1;
        private Judge j2;
        
        [SetUp]
        public void SetUp()
        {
            comp = new Competition(0, "Test", "Test", "Test", 1, "Man", 1, 5);
            j1 = new Judge(0, "Mr. Test");
            j2 = new Judge(1, "Mrs. Fest");
            comp.AddJudge(j1);
            comp.AddJudge(j2);
        }

        [Test]
        public void EttTest()
        {
            Assert.AreEqual(comp.GetJudges()[0], j1);
            Assert.AreEqual(comp.GetJudges()[0], j2);
        }
    }
}
