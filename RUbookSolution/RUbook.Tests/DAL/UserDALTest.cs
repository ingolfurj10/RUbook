using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using System.Text;
//using RUbook;
using RUbook.DAL;
using Microsoft.AspNet;
using System.Collections.Generic;

namespace RUbook.Tests.DAL
{
    [TestClass]
    public class UserDALTest
    {
   
        [TestMethod]
        public void GetAllFriendsIds() //fá alla vini ákv notanda - BÞ
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Arrange:
            //const string user = "sigga@ru.is"; // ákveðinn  notandi
            var DAL = new UserDAL(db);
            //Act:
            List<string> result = DAL.GetAllFriendsIds("4f186767-6ee6-4c54-9ede-846529b7eaf7"); //köllum á fallið með id ákveðins notanda

            //Assert:
            Assert.AreEqual(3, result.Count); //þessi notandi á 3 vini

        }
    }


}
