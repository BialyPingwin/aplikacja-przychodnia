using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aplikacja_przychodnia.Classes;

namespace FirmLocalDataBaseTest
{
    [TestClass]
    public class TestAdd
    {
        [TestMethod]
        public void TestAdd1()
        {
            Firm firm = new Firm();
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            CollectionAssert.AreEqual(list, fldb.ReturnList());
        }

        [TestMethod]
        public void TestAdd2()
        {
            Firm firm1 = new Firm();
            Firm firm2 = new Firm();
            List<Firm> list = new List<Firm>();
            list.Add(firm1);
            list.Add(firm2);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm1);
            CollectionAssert.AreNotEqual(list, fldb.ReturnList());
        }
    }

    [TestClass]
    public class TestRemove
    {
        [TestMethod]
        public void TestRemove1()
        {
            Firm firm1 = new Firm();
            Firm firm2 = new Firm();
            List<Firm> list = new List<Firm>();
            list.Add(firm1);
            list.Add(firm2);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm1);
            fldb.Add(firm2);

            list.Remove(firm2);
            fldb.Remove(firm2);

            CollectionAssert.AreEqual(list, fldb.ReturnList());
        }

        [TestMethod]
        public void TestRemove2()
        {
            Firm firm1 = new Firm();
            Firm firm2 = new Firm();
            List<Firm> list = new List<Firm>();
            list.Add(firm1);
            list.Add(firm2);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm1);
            fldb.Add(firm2);

            list.Remove(firm2);
            fldb.Remove(firm2);
            fldb.Remove(firm1);

            CollectionAssert.AreNotEqual(list, fldb.ReturnList());
        }
    }

    [TestClass]
    public class TestReturnList
    {
        [TestMethod]
        public void TestReturnList1()
        {
            Firm firm1 = new Firm();
            Firm firm2 = new Firm();
            List<Firm> list = new List<Firm>();
            list.Add(firm1);
            list.Add(firm2);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm1);
            fldb.Add(firm2);

            CollectionAssert.AreEqual(list, fldb.ReturnList());
        }
    }

    [TestClass]
    public class TestFindFirmConnectionByName
    {
        [TestMethod]
        public void TestFindFirmConnectionByName1()
        {
            Firm firm = new Firm();
            firm.FirmName = "Firma";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            string found = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirmName == firm.FirmName)
                {
                    found = list[i].ReturnConnectionInfo();
                }
            }

            string result = fldb.FindFirmConnectionByName(firm.FirmName);

            Assert.AreEqual(found, result);
        }

        [TestMethod]
        public void TestFindFirmConnectionByName2()
        {
            Firm firm = new Firm();
            firm.FirmName = "Firma";
            List<Firm> list = new List<Firm>();
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            string found = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirmName == firm.FirmName)
                {
                    found = list[i].ReturnConnectionInfo();
                }
            }
            string result = fldb.FindFirmConnectionByName(firm.FirmName);

            Assert.AreNotEqual(found, result);
        }
    }

    [TestClass]
    public class TestFindFirmConnectionByNIP
    {
        [TestMethod]
        public void TestFindFirmConnectionByNIP1()
        {
            Firm firm = new Firm();
            firm.NIP = "1234567890";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            string found = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NIP == firm.NIP)
                {
                    found = list[i].ReturnConnectionInfo();
                }
            }
            string result = fldb.FindFirmConnectionByNIP(firm.NIP);

            Assert.AreEqual(found, result);
        }

        [TestMethod]
        public void TestFindFirmConnectionByName2()
        {
            Firm firm = new Firm();
            firm.NIP = "Firma";
            List<Firm> list = new List<Firm>();
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            string found = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NIP == firm.NIP)
                {
                    found = list[i].ReturnConnectionInfo();
                }
            }
            string result = fldb.FindFirmConnectionByNIP(firm.NIP);

            Assert.AreNotEqual(found, result);
        }
    }

    [TestClass]
    public class TestIsNameAvailable
    {
        [TestMethod]
        public void TestIsNameAvailable1()
        {
            Firm firm = new Firm();
            firm.FirmName = "Firma";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            bool isAvailable = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirmName == firm.FirmName)
                {
                    break;
                }
                else
                {
                    if (i == list.Count - 1)
                    {
                        isAvailable = true;
                    }
                }
            }

            bool result = fldb.IsNameAvailable(firm.FirmName);
            Assert.AreEqual(isAvailable, result);
        }

        [TestMethod]
        public void TestIsNameAvailable2()
        {
            string name = "Inna";
            Firm firm = new Firm();
            firm.FirmName = "Firma";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            bool isAvailable = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirmName == name)
                {
                    break;
                }
                else
                {
                    if (i == list.Count - 1)
                    {
                        isAvailable = true;
                    }
                }
            }

            bool result = fldb.IsNameAvailable(name);
            Assert.AreEqual(isAvailable, result);
        }
    }

    [TestClass]
    public class TestIsNIPAvailable
    {
        [TestMethod]
        public void TestIsNIPAvailable1()
        {
            Firm firm = new Firm();
            firm.NIP = "1234567890";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            bool isAvailable = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NIP == firm.NIP)
                {
                    break;
                }
                else
                {
                    if (i == list.Count - 1)
                    {
                        isAvailable = true;
                    }
                }
            }

            bool result = fldb.IsNipAvailable(firm.NIP);
            Assert.AreEqual(isAvailable, result);
        }

        [TestMethod]
        public void TestIsNIPAvailable2()
        {
            string nip = "0987654321";
            Firm firm = new Firm();
            firm.NIP = "1234567890";
            List<Firm> list = new List<Firm>();
            list.Add(firm);
            FirmLocalDataBase fldb = new FirmLocalDataBase();
            fldb.Add(firm);
            bool isAvailable = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NIP == nip)
                {
                    break;
                }
                else
                {
                    if (i == list.Count - 1)
                    {
                        isAvailable = true;
                    }
                }
            }

            bool result = fldb.IsNipAvailable(nip);
            Assert.AreEqual(isAvailable, result);
        }
    }
}
