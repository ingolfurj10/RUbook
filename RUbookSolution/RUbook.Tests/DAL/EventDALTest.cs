using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RUbook.DAL;
using Microsoft.AspNet;
using System.Collections.Generic;

namespace RUbook.Tests.DAL
{
    [TestClass]
    public class EventDALTest
    {
        [TestMethod]
        public void GetAllEventsOfUser() //öll event sem ákv notandi tileyrir -BÞ
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            var DAL = new EventDAL(db);
            //Act:
            var result = DAL.GetAllEventsOfUser("4f186767-6ee6-4c54-9ede-846529b7eaf7");
            //Assert:
            Assert.AreEqual(4, result.Count);//ákv notandi er skráður í 2 event
        }

        [TestMethod]
        public void GetEventMembers() //öll event sem ákv notandi tileyrir -BÞ
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            var DAL = new EventDAL(db);
            //Act:
            var result = DAL.GetEventMembers(1);
            //Assert:
            Assert.AreEqual(5, result.Count);//í þessu event eru skráðir 4 notendur
        }
    }
}
