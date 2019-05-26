using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aplikacja_przychodnia.Classes
{

    public class RegClass
    {
        public static bool CheckFirstName(string item)
        {
            string reg = @"^[A-ZĘĄŃŁÓŚĆŻŹ][a-zęąńłóśźżź]{2,16}$";
            Regex rx = new Regex(reg);

            if (rx.IsMatch(item))
            {
                return true;
            }
            return false;
        }

        public static bool CheckLastName(string item)
        {
            string reg = @"^[A-ZĘĄŃŁÓŚĆŻŹ][a-zęąńłóśźżź]{2,32}((-| - | )[A-ZĘĄŃŁÓŚĆŻŹ]{1}[a-zęąńłóśźżź]{2,32})?$";
            Regex rx = new Regex(reg);

            if (rx.IsMatch(item))
            {
                return true;
            }
            return false;
        }

        public static bool CheckPESEL(string item)
        {
            string reg = @"^[0-9]{11}$";
            Regex rx = new Regex(reg);

            if (rx.IsMatch(item))
            {
                return true;
            }
            return false;
        }
        public static bool CheckNIP(string item)
        {
            string reg = @"^[0-9]{10}$";
            Regex rx = new Regex(reg);

            if (rx.IsMatch(item))
            {
                return true;
            }
            return false;
        }

        public static bool CheckPassword(string item)
        {
            string reg = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{4,20}$";
            Regex rx = new Regex(reg);

            if (rx.IsMatch(item))
            {
                return true;
            }
            return false;
        }
    }
}