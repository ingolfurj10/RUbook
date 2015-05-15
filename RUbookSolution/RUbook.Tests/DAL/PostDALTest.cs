using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RUbook.DAL;
using Microsoft.AspNet;
using System.Collections.Generic;
using RUbook.DAL;
using Microsoft.AspNet;
using System.Collections.Generic;

namespace RUbook.Tests.DAL
{
    [TestClass]
    public class PostDALTest
    {
       
        [TestMethod]
        public void GetGroupPosts()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            var DAL = new PostDAL(db);
            //Act:
            var restult = DAL.GetGroupPosts(2);
            //Assert:
            Assert.AreEqual(7, restult.Count);
        }

        [TestMethod]
        public void GetEventPosts()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            var DAL = new PostDAL(db);
            //Act:
            var restult = DAL.GetEventPosts(2);
            //Assert:
            Assert.AreEqual(4, restult.Count);
        }
    }
}
