

using Simhopp;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Nunit.Simhopp
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTest
    {
        private Contest _contest;
        private List<Judge> _judges;
        private List<Diver> _divers;

        [SetUp]
        public void SetUp()
        {
            _judges = new List<Judge>();
            _divers = new List<Diver>();
            _contest = new Contest(0, "Nunit Test Contest", "2015-02-02", "Badhuset", 1, 1, 1, 5);

            _judges.Add(new Judge(0, "Mr. Test"));
            _judges.Add(new Judge(1, "Mrs. Fest"));
            _judges.Add(new Judge(2, "Konstapel Kuk"));
            _judges.Add(new Judge(3, "Domherre"));
            _judges.Add(new Judge(4, "McFlash"));

            _divers.Add(new Diver(0, "Kalle"));
            _divers.Add(new Diver(1, "Greger"));
            _divers.Add(new Diver(2, "Skitunge"));

            _contest.AddDivers(_divers);
            _contest.AddJudges(_judges);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, _contest);
                    _contest.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        Score s = new Score(0, null, _judges[k], (k + j)%11);
                        dive.AddScore(s);
                    }
                }
            }
        }

        [Test]
        public void DbConnect()
        {
            Assert.AreNotEqual(Database.ConnectToDatabase(), null);
        }

        [Test]
        public void DbAddDiver()
        {
            Assert.GreaterOrEqual(Database.AddDiverToDatabase(_divers[0]), 1);
        }
        [Test]
        public void DbRemoveDiver()
        {
            //Impelementerar sedan
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void DbAddJudge()
        {
            Assert.GreaterOrEqual(Database.AddJudgeToDatabase(_judges[0]), 1);
        }

        [Test]
        public void DbAddContest()
        {
            Assert.GreaterOrEqual(Database.AddEventToDatabase(_contest), -1);
        }

        [Test]
        public void DbSelectDivers()
        {
            Assert.GreaterOrEqual(Database.GetDivers().Count, 1);
        }

        [Test]
        public void DbSelectJudges()
        {

            Assert.GreaterOrEqual(Database.GetJudges().Count, 1);
        }

        [Test]
        public void DbAddSelectDiver()
        {
            int lastId = _divers[0].ID;
            int newId = Database.AddDiverToDatabase(_divers[0]);
            Assert.AreNotEqual(lastId, newId);
            Assert.AreEqual(newId, _divers[0].ID);

            Diver temp = Database.GetSpecificDiverFromDatabase(_divers[0].ID);
            Assert.AreEqual(_divers[0].ID, temp.ID);
        }
    }

    [TestFixture]
    public class ContestTest
    {
        private Contest _contest;
        private List<Judge> _judges;
        private List<Diver> _divers;
            
        [SetUp]
        public void SetUp()
        {
            _judges = new List<Judge>();
            _divers = new List<Diver>();
            _contest = new Contest(0, "Nunit Test Contest", "2015-02-02", "Badhuset", 1, 1, 5, 1);

            _judges.Add(new Judge(0, "Mr. Test"));
            _judges.Add(new Judge(1, "Mrs. Fest"));
            _judges.Add(new Judge(2, "Konstapel Kuk"));
            _judges.Add(new Judge(3, "Domherre"));
            _judges.Add(new Judge(4, "McFlash"));

            _divers.Add(new Diver(0, "Kalle"));
            _divers.Add(new Diver(1, "Greger"));
            _divers.Add(new Diver(2, "Skitunge"));

            _contest.AddDivers(_divers);
            _contest.AddJudges(_judges);



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Dive dive = new Dive(0, null, j + 1, _contest);
                    _contest.GetDivers()[i].AddDive(dive);

                    for (int k = 0; k < 5; k++)
                    {
                        Score s = new Score(0, null, _judges[k], (k + j) % 11);
                        dive.AddScore(s);
                    }
                }
            }
        }

        [Test]
        public void RunContest()
        {
            _contest.started = 1;
        }

        [Test]
        public void RunCheckDiveCount()
        {
            Assert.AreEqual(_contest.diveCount, _contest.GetDivers()[0].GetDives().Count);
        }

        [Test]
        public void RunSelectDivers()
        {
            Assert.AreEqual(_contest.GetDivers()[0], _divers[0]);
            Assert.AreEqual(_contest.GetDivers()[1], _divers[1]);
            Assert.AreEqual(_contest.GetDivers()[2], _divers[2]);
            Assert.AreEqual(_contest.GetDivers().Count, 3);
        }

        [Test]
        public void RunSelectJudges()
        {
            Assert.AreEqual(_contest.GetJudges()[0], _judges[0]);
            Assert.AreEqual(_contest.GetJudges()[1], _judges[1]);
            Assert.AreEqual(_contest.GetJudges()[2], _judges[2]);
            Assert.AreEqual(_contest.GetJudges()[3], _judges[3]);
            Assert.AreEqual(_contest.GetJudges()[4], _judges[4]);
            Assert.AreEqual(_contest.GetJudges().Count, 5);
        }

        [Test]
        public void RunScoreDive()
        {
            Assert.LessOrEqual(_divers[0].dives[0].score, 30);

            Diver tDiver = new Diver(-1, "Greger");
            Dive tDive = new Dive(-1, tDiver, 1, _contest);
            tDiver.AddDive(tDive);
            tDive.AddScore(new Score(0, tDive, _judges[0], 1));
            tDive.AddScore(new Score(0, tDive, _judges[1], 5));
            tDive.AddScore(new Score(0, tDive, _judges[2], 5));
            tDive.AddScore(new Score(0, tDive, _judges[3], 5));
            tDive.AddScore(new Score(0, tDive, _judges[4], 10));

            Assert.AreEqual(tDive.score, 15);
        }

        [Test]
        public void RunScoreGreaterThanMax()
        {
            Diver tDiver = new Diver(-1, "Gregers kompis");
            Dive tDive = new Dive(-1, tDiver, 1, _contest);
            tDiver.AddDive(tDive);
            tDive.AddScore(new Score(0, tDive, _judges[0], 11));
            tDive.AddScore(new Score(0, tDive, _judges[1], 11));
            tDive.AddScore(new Score(0, tDive, _judges[2], 11));
            tDive.AddScore(new Score(0, tDive, _judges[3], 11));
            tDive.AddScore(new Score(0, tDive, _judges[4], 11));

            Assert.AreEqual(tDive.score, 30);
        }

        [Test]
        public void RunSelectScoreJudge()
        {
            Assert.AreEqual(_divers[0].GetDives()[0].GetScores()[0].judge.GetJudgeName(), "Mr. Test");

            System.Diagnostics.Debug.WriteLine("Score: " + _divers[0].TotalScore);
        }

        [Test]
        public void TestDD()
        {
            DD.LoadDDTable();
            DiveType diveType = new DiveType(103, DiveType.DivePosition.A, DiveType.DiveHeight._1M);
            Assert.AreEqual(DD.Difficulty(diveType), 2.0);
            Assert.AreEqual(diveType.Difficulty, 2.0);
        }

    }
}
