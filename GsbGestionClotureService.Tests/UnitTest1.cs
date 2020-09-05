using NUnit.Framework;
using System.IO;
using System;

namespace GsbGestionClotureService.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void getMoisPrecedentTest()
        {
            Assert.AreEqual("08", DateGestion.getMoisPrecedent());
            Assert.AreEqual("08", DateGestion.getMoisPrecedent(DateTime.Today));
        }

        [Test]
        public void getMoisPrecedentPersonnaliseTest()
        {
            DateTime aDate1 = new DateTime(2020, 06, 17);
            Assert.AreEqual("05", DateGestion.getMoisPrecedent(aDate1));

            DateTime aDate2 = new DateTime(2020, 01, 13);
            Assert.AreEqual("12", DateGestion.getMoisPrecedent(aDate2));
        }

        [Test]
        public void getMoisSuivantTest()
        {
            Assert.AreEqual("10", DateGestion.getMoisSuivant());
            Assert.AreEqual("10", DateGestion.getMoisSuivant(DateTime.Today));
        }

        [Test]
        public void entreTest()
        {
            Assert.IsTrue(DateGestion.entre(01, 20));
            Assert.IsTrue(DateGestion.entre(01, 20, DateTime.Today));
        }

        [Test]
        public void getYearTest()
        {
            Assert.AreEqual("2020", DateGestion.getAnneeDuMoisPrecedent(DateTime.Today));
        }

        [Test]
        public void getAnneeEtMoisPrecedentTest()
        {
            Assert.AreEqual("202008", DateGestion.getAnneeEtMoisPrecedent());

            DateTime aDate1 = new DateTime(2020, 06, 15);
            Assert.AreEqual("202005", DateGestion.getAnneeEtMoisPrecedent(aDate1));
        }
    }
}