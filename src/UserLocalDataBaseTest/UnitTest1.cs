using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aplikacja_przychodnia;
using aplikacja_przychodnia.Classes;

namespace UserLocalDataBaseTest
{
    [TestClass]
    public class TestAdd
    {
        [TestMethod]
        public void TestAdd1()
        {
            User user = new User("Adam", "Nowak", "anowak", "Hasło1");
            List<User> list = new List<User>();
            list.Add(user);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user);
            CollectionAssert.AreEqual(list, uldb.ReturnList());
        }

        [TestMethod]
        public void TestAdd2()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            CollectionAssert.AreNotEqual(list, uldb.ReturnList());
        }
    }

    [TestClass]
    public class TestRemove
    {
        [TestMethod]
        public void TestRemove1()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            list.Remove(user1);
            uldb.Remove(user1);
            CollectionAssert.AreEqual(list, uldb.ReturnList());
        }

        [TestMethod]
        public void TestRemove2()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            uldb.Remove(user1);

            CollectionAssert.AreNotEqual(list, uldb.ReturnList());
        }
    }

    [TestClass]
    public class TestReturnList
    {
        [TestMethod]
        public void TestReturnList1()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            CollectionAssert.AreEqual(list, uldb.ReturnList());
        }
    }

    [TestClass]
    public class TestLogin
    {
        [TestMethod]
        public void TestLogin1()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            User logged = null;
            string login = "anowak";
            string password = "Hasło1";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    if (list[i].password == password)
                    {
                        logged = list[i];
                    }
                }
            }

            User result = uldb.login(login, password);
            Assert.AreEqual(logged, result);
        }

        [TestMethod]
        public void TestLogin2()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            User logged = null;
            string login = "anowak";
            string password = "Hasło2";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    if (list[i].password == password)
                    {
                        logged = list[i];
                    }
                }
            }

            User result = uldb.login(login, password);
            Assert.AreEqual(logged, result);
        }

        [TestMethod]
        public void TestLogin3()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            User logged = null;
            string login = "Anowak";
            string password = "Hasło1";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    if (list[i].password == password)
                    {
                        logged = list[i];
                    }
                }
            }

            User result = uldb.login(login, password);
            Assert.AreEqual(logged, result);
        }
    }

    [TestClass]
    public class TestChangePassword
    {
        [TestMethod]
        public void TestChangePasswordTest1()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            string login = "anowak";
            string newPassword = "Hasło123";
            string changed = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    list[i].password = newPassword;
                    changed = newPassword;
                }
            }

            string result = "";
            uldb.ChangePassword(login, newPassword);
            foreach (User u in uldb.ReturnList())
            {
                if (u.login == login)
                {
                    result = u.password;
                }
            }

            Assert.AreEqual(changed, result);
        }
    }

    [TestClass]
    public class TestIsLoginFree
    {
        [TestMethod]
        public void TestIsLoginFree1()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            string login = "anowak";
            bool isFree = true;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    isFree = false;
                }
            }

            bool result = uldb.IsLoginFree(login);
            Assert.AreEqual(isFree, result);
        }

        [TestMethod]
        public void TestIsLoginFree2()
        {
            User user1 = new User("Adam", "Nowak", "anowak", "Hasło1");
            User user2 = new User("Maria", "Kowalska", "mkowalska", "Hasło2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            UserLocalDataBase uldb = new UserLocalDataBase();
            uldb.Add(user1);
            uldb.Add(user2);

            string login = "bkwiatkowski";
            bool isFree = true;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].login == login)
                {
                    isFree = false;
                }
            }

            bool result = uldb.IsLoginFree(login);
            Assert.AreEqual(isFree, result);
        }
    }
}
