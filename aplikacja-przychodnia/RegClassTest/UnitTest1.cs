using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aplikacja_przychodnia.Classes;

namespace RegClassTest
{
    public class Check
    {
        public static bool IsFirstNameOk(string name)
        {
            bool isOk = false;
            if (name.Length >= 3 && Char.IsUpper(name[0]) && name.Length < 18)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsLetter(name[i]))
                    {
                        break;
                    }
                    else
                    {
                        if (i == name.Length - 1)
                        {
                            isOk = true;
                        }
                    }
                }
            }

            return isOk;
        }

        public static bool IsLastNameOk(string lastName)
        {
            bool isOk = false;
            if (lastName.Length >= 3 && Char.IsUpper(lastName[0]) && lastName.Length < 69)
            {
                for (int i = 0; i < lastName.Length; i++)
                {
                    if (!Char.IsLetter(lastName[i]))
                    {
                        if (lastName[i] == ' ' && i < 33 && (Char.IsLetter(lastName[i + 1]) || lastName[i + 1] == '-'))
                        {
                            continue;
                        }
                        if (lastName[i] == '-' && (Char.IsLetter(lastName[i + 1]) || (lastName[i + 1] == ' ' && Char.IsLetter(lastName[i + 3]))))
                        {
                            continue;
                        }
                        break;
                    }
                    else
                    {
                        if (i == lastName.Length - 1)
                        {
                            isOk = true;
                        }
                    }
                }
            }

            return isOk;
        }

        public static bool IsPESELOk(string pesel)
        {
            bool isOk = false;
            if (pesel.Length == 11)
            {
                for (int i = 0; i < pesel.Length; i++)
                {
                    if (!Char.IsDigit(pesel[i]))
                    {
                        break;
                    }
                    else
                    {
                        if (i == pesel.Length - 1)
                        {
                            isOk = true;
                        }
                    }
                }
            }

            return isOk;
        }

        public static bool IsNIPOk(string nip)
        {
            bool isOk = false;
            if (nip.Length == 10)
            {
                for (int i = 0; i < nip.Length; i++)
                {
                    if (!Char.IsDigit(nip[i]))
                    {
                        break;
                    }
                    else
                    {
                        if (i == nip.Length - 1)
                        {
                            isOk = true;
                        }
                    }
                }
            }

            return isOk;
        }

        public static bool IsPasswordOk(string password)
        {
            bool isOk = false;
            bool upper = false;
            bool digit = false;
            bool lower = false;
            if (password.Length >= 4 && password.Length <= 20)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Char.IsUpper(password[i]))
                    {
                        upper = true;
                    }
                    if (Char.IsDigit(password[i]))
                    {
                        digit = true;
                    }
                    if (Char.IsLower(password[i]))
                    {
                        lower = true;
                    }
                }

                if (upper && digit && lower)
                {
                    isOk = true;
                }
            }

            return isOk;
        }
    }
    [TestClass]
    public class TestCheckFirstName
    {
        [TestMethod]
        public void TestCheckFirstName1()
        {
            string name;
            name = "Ala";
            bool isNameOk = Check.IsFirstNameOk(name);


            bool result = RegClass.CheckFirstName(name);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckFirstName2()
        {
            string name;
            name = "ala";
            bool isNameOk = Check.IsFirstNameOk(name);
            bool result = RegClass.CheckFirstName(name);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckFirstName3()
        {
            string name;
            name = "Al";
            bool isNameOk = Check.IsFirstNameOk(name);
            bool result = RegClass.CheckFirstName(name);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckFirstName4()
        {
            string name;
            name = "Al3a";
            bool isNameOk = Check.IsFirstNameOk(name);
            bool result = RegClass.CheckFirstName(name);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckFirstName5()
        {
            string name;
            name = "Al.-a";
            bool isNameOk = Check.IsFirstNameOk(name);
            bool result = RegClass.CheckFirstName(name);
            Assert.AreEqual(isNameOk, result);
        }
    }

    [TestClass]
    public class TestCheckLastName
    {
        [TestMethod]
        public void TestCheckLastName1()
        {
            string lastName;
            lastName = "Nowak";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName2()
        {
            string lastName;
            lastName = "Nowak-Kowlska";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName3()
        {
            string lastName;
            lastName = "Nowak Kowalska";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName4()
        {
            string lastName;
            lastName = "Nowak - Kowalska";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName5()
        {
            string lastName;
            lastName = "Nowak 5";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName6()
        {
            string lastName;
            lastName = "nowak";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }

        [TestMethod]
        public void TestCheckLastName7()
        {
            string lastName;
            lastName = "No=.wak";
            bool isNameOk = Check.IsLastNameOk(lastName);
            bool result = RegClass.CheckLastName(lastName);
            Assert.AreEqual(isNameOk, result);
        }
    }

    [TestClass]
    public class TestCheckPESEL
    {
        [TestMethod]
        public void TestCheckPESEL1()
        {
            string pesel;
            pesel = "123";
            bool isPeselOk = Check.IsPESELOk(pesel);
            bool result = RegClass.CheckPESEL(pesel);
            Assert.AreEqual(isPeselOk, result);
        }

        [TestMethod]
        public void TestCheckPESEL2()
        {
            string pesel;
            pesel = "12345678901";
            bool isPeselOk = Check.IsPESELOk(pesel);
            bool result = RegClass.CheckPESEL(pesel);
            Assert.AreEqual(isPeselOk, result);
        }

        [TestMethod]
        public void TestCheckPESEL3()
        {
            string pesel;
            pesel = "1234567890123456";
            bool isPeselOk = Check.IsPESELOk(pesel);
            bool result = RegClass.CheckPESEL(pesel);
            Assert.AreEqual(isPeselOk, result);
        }
    }

    [TestClass]
    public class TestCheckNIP
    {
        [TestMethod]
        public void TestCheckNIP1()
        {
            string nip;
            nip = "123";
            bool isNipOk = Check.IsNIPOk(nip);
            bool result = RegClass.CheckNIP(nip);
            Assert.AreEqual(isNipOk, result);
        }

        [TestMethod]
        public void TestCheckNIP2()
        {
            string nip;
            nip = "1234567890";
            bool isNipOk = Check.IsNIPOk(nip);
            bool result = RegClass.CheckNIP(nip);
            Assert.AreEqual(isNipOk, result);
        }

        [TestMethod]
        public void TestCheckNIP3()
        {
            string nip;
            nip = "1234567890123456";
            bool isNipOk = Check.IsNIPOk(nip);
            bool result = RegClass.CheckNIP(nip);
            Assert.AreEqual(isNipOk, result);
        }
    }

    [TestClass]
    public class TestChcekPassword
    {
        [TestMethod]
        public void TestPassword1()
        {
            string password;
            password = "Hasło";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword2()
        {
            string password;
            password = "Hasło";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword3()
        {
            string password;
            password = "hasło1";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword4()
        {
            string password;
            password = "Hs3";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword5()
        {
            string password;
            password = "6hAsło";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword6()
        {
            string password;
            password = "Hasło123Hasło123Hasło123Hasło123";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword7()
        {
            string password;
            password = "12345";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }

        [TestMethod]
        public void TestPassword8()
        {
            string password;
            password = "HASŁO3";
            bool isPasswordOk = Check.IsPasswordOk(password);
            bool result = RegClass.CheckPassword(password);
            Assert.AreEqual(isPasswordOk, result);
        }
    }
}
