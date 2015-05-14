using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RUbook.DAL;
using Microsoft.AspNet;
using System.Collections.Generic;

namespace RUbook.Tests.DAL
{
    [TestClass]
    public class GroupDALTest
    {
        [TestMethod]
        public void GetAllGroupsOfUser() //Allar grúppur sem ákv notandi tilheyrir -BÞ
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            // const string user = "sombody"; //ákveðið ID = ákveðinn  notandi
            var DAL = new GroupDAL(db);
            //Act:
            var result = DAL.GetAllGroupsOfUser("4f186767-6ee6-4c54-9ede-846529b7eaf7"); //köllum á fallið 
        }
        [TestMethod]
        public void GetGroupMembers() //Allir notendur sem tilheyra ákv grúppu -BÞ 
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
           //const int group = "some group id"; 
            var DAL = new GroupDAL(db);
            //Act:
            var result = DAL.GetGroupMembers(1); //köllum á fallið 

            //Assert:
            Assert.AreEqual(4, result.Count); //það tilheyra 4 notendur þessum hópi
        }
    }
	
}
