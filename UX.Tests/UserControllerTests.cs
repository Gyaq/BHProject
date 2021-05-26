using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UX.Models;

namespace UX.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        //[TestMethod]
        //public void GetAllUsers()
        //{
        //    #region mock data
        //    var date1 = DateTime.Now;

        //    var mockUsers = new List<AppUserModel>()
        //    {
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName1",
        //            LastName="LastName1",
        //            Id=1,
        //            ImageUrl="url1",
        //            JoinDate=date1
        //        },
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName2",
        //            LastName="LastName2",
        //            Id=2,
        //            ImageUrl="url2",
        //            JoinDate=date1
        //        },
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName3",
        //            LastName="LastName3",
        //            Id=3,
        //            ImageUrl="url3",
        //            JoinDate=date1
        //        }
        //    };
        //    #endregion

        //    var userRepositoryMock = TestInitializer.MockUsersRepository;
        //    userRepositoryMock.Setup
        //          (x => x.GetAllUsers()).Returns(Task.FromResult(mockUsers));

        //    var users = userRepositoryMock.Object.GetAllUsers().Result;

        //    Assert.AreEqual(3, users.Count);
        //    Assert.AreEqual(mockUsers[0].Id, users[0].Id);
        //}

        //[TestMethod]
        //public void GetUser()
        //{
        //    #region mock data
        //    var date1 = DateTime.Now;

        //    var mockUsers = new List<AppUserModel>()
        //    {
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName1",
        //            LastName="LastName1",
        //            Id=1,
        //            ImageUrl="url1",
        //            JoinDate=date1
        //        },
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName2",
        //            LastName="LastName2",
        //            Id=2,
        //            ImageUrl="url2",
        //            JoinDate=date1
        //        },
        //        new AppUserModel()
        //        {
        //            FirstName="FirstName3",
        //            LastName="LastName3",
        //            Id=3,
        //            ImageUrl="url3",
        //            JoinDate=date1
        //        }
        //    };
        //    #endregion

        //    var userRepositoryMock = TestInitializer.MockUsersRepository;
        //    userRepositoryMock.Setup
        //          (x => x.GetUser(1)).Returns(Task.FromResult(mockUsers[0]));

        //    var user = userRepositoryMock.Object.GetUser(1).Result;

           
        //    Assert.AreEqual(mockUsers[0].Id, user.Id);
        //}
    }
}
