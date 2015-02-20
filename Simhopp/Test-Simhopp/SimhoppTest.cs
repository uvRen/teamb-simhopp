

using Simhopp;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Nunit.Simhopp
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class JudgeTest
    {
        private Contest comp;
        private List<Judge> judges;
        private Diver d1, d2, d3;
        [SetUp]
        public void SetUp()
        {
            judges = new List<Judge>();
            comp = new Contest(0, "Test", "Test", "Test", 1, 1, 1, 5);

            judges.Add(new Judge(0, "Mr. Test"));
            judges.Add(new Judge(1, "Mrs. Fest"));
            judges.Add(new Judge(2, "Konstapel Kuk"));
            judges.Add(new Judge(3, "Domherre"));
            judges.Add(new Judge(4, "McFlash"));

            comp.AddJudges(judges);

            d1 = new Diver(0, "Kalle");
            d2 = new Diver(0, "Greger");
            d3 = new Diver(0, "Skitunge");

            comp.AddDiver(d1);
            comp.AddDiver(d2);
            comp.AddDiver(d3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, comp);
                    comp.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        Score s = new Score(0, null, judges[k], (k + j) % 11);
                        dive.AddScore(s);
                    }
                }
            }
        }

        [Test]
        public void DatabaseTests()
        {

            Assert.AreNotEqual(Database.ConnectToDatabase(), null);
            Assert.GreaterOrEqual(Database.AddDiverToDatabase(d1), 0);
            Assert.GreaterOrEqual(Database.AddJudgeToDatabase(judges[0]), 0);
            Assert.GreaterOrEqual(Database.AddEventToDatabase(comp));
            Assert.GreaterOrEqual(Database.GetDivers().Count, 1);
            Assert.GreaterOrEqual(Database.GetJudges().Count, 1);

            int lastId = d1.ID;
            int newId = Database.AddDiverToDatabase(d1);
            Assert.AreNotEqual(lastId, newId);
            Assert.AreEqual(newId, d1.ID);



        }

        [Test]
        public void RunContest()
        {
            Assert.AreEqual(d1.GetDives()[0].GetScores()[0].judge.GetJudgeName(), "Mr. Test");
            System.Diagnostics.Debug.WriteLine("Score: " + d1.TotalScore);
        }

    }
}
