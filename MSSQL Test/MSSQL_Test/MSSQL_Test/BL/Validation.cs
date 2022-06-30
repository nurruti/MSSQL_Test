using System;

namespace MSSQL_Test.BL
{
    public class Validation
    {
        public static bool CheckInt(String input)
        {
            int tempint = 0;
            return int.TryParse(input, out tempint);
        }

        public static bool CheckString(String input)
        {
            bool isValid = true;
            string tempString = input.Trim();
            if (string.IsNullOrEmpty(tempString))
            {
                isValid = false;
            }
            else if (tempString == "string")
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool CheckAge(String input)
        {
            bool isValid = true;
            int tempInt = Convert.ToInt32(input);
            if (tempInt < 15 || tempInt > 110)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
