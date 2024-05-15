using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UP02;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPassword_Admin1_newLogin_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("Admin1", "newLogin");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_Admin1_Admin1_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("Admin1", "Admin1");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_space_space_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("", "");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_ThisIsAVeryLongPasswordThatExceedsTwentyCharacters_admin_trueresult()
        {

            TestClass window = new TestClass();
            bool actual = window.TestPassword("ThisIsAVeryLongPasswordThatExceedsTwentyCharacters", "admin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_password_newLogin_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("password", "newLogin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_PASSWORD_newLogin_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("PASSWORD", "newLogin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_username123Password_username123_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("username123Password", "username123");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_Password123username_username123_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("Password123username", "username");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_123456_newLogin_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("123456", "newLogin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPassword_space_newLogin_trueresult()
        {
            TestClass window = new TestClass();
            bool actual = window.TestPassword("", "newLogin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
