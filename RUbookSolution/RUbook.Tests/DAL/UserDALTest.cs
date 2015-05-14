using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using System.Text;
//using RUbook;
using RUbook.DAL;

namespace RUbook.Tests.DAL
{
    [TestClass]
    public class UserDALTest
    {
    /*    [TestMethod]
        public void GetFriends() //fá alla vini notanda
        {
            //Arrange:
            const string user = "sombody"; //ákveðið ID = ákveðinn  notandi
            var DAL = new UserDAL(); 
            //Act:
            var result = DAL.GetFriends(user); //köllum á fallið með þessum ákv notandi

            //Assert:
            Assert.AreEqual(2, result.Count); //þessi notandi á 2 vini

        }*/
        [TestMethod]
        public void GetAllFriendsIds() //fá alla vini notanda - BÞ
        {
            //Arrange:
            const string user = "sombody"; //ákveðið ID = ákveðinn  notandi
            var DAL = new UserDAL(null);
            //Act:
            var result = DAL.GetAllFriendsIds(user); //köllum á fallið með þessum ákv notandi

            //Assert:
            Assert.AreEqual(2, result.Count); //þessi notandi á 2 vini

        }
    }


}
