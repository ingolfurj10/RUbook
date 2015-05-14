using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RUbook.DAL;
namespace RUbook.Tests.DAL
{
    [TestClass]
    public class GroupDALTest
    {
        [TestMethod]
        public void GetAllGroupsOfUser() //Allar grúppur sem ákv notandi tilheyrir -BÞ
        {
            //Arrange:
            const string user = "sombody"; //ákveðið ID = ákveðinn  notandi
            var DAL = new GroupDAL(null);
            //Act:
            var result = DAL.GetAllGroupsOfUser(user); //köllum á fallið 

            //Assert:
            Assert.AreEqual(2, result.Count); //þessi notandi tilheyrir 2 hópum
        }

        [TestMethod]
        public void GetGroupMembers() //Allir notendur sem tilheyra ákv grúppu -BÞ 
        {
            //Arrange:
            string group = "some group id"; 
            var DAL = new GroupDAL(null);
            //Act:
            var result = DAL.GetGroupMembers(null); //köllum á fallið 

            //Assert:
            Assert.AreEqual(2, result.Count); //það tilheyra 2 notendr þessum hópi
        }
    }
}
