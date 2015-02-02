

using Simhopp;

namespace Nunit.Simhopp
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class JudgeTest
    {
        private Event comp;
        private Judge j1, j2, j3, j4;
        private Diver d1, d2, d3;
        [SetUp]
        public void SetUp()
        {
            comp = new Event(0, "Test", "Test", "Test", 1, "Man", 1, 5);
            
            j1 = new Judge(0, "Mr. Test");
            j2 = new Judge(1, "Mrs. Fest");
            j3 = new Judge(2, "Konstapel Kuk");
            j4 = new Judge(3, "Domherre");

            comp.AddJudge(j1);
            comp.AddJudge(j2);
            comp.AddJudge(j3);
            comp.AddJudge(j4);

            d1 = new Diver(0, "Kalle");
            d2 = new Diver(0, "Greger");
            d3 = new Diver(0, "Olof");


            comp.AddJudge(j1);
            comp.AddJudge(j2);
        }

        [Test]
        public void EttTest()
        {
            Assert.AreEqual(comp.GetJudges()[0], j1);
        }
    }
}
