using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework
{
    class Generator
    {


        public static string GetRandomString(int numberOfCharacters)
        {


            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[numberOfCharacters];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public static string GetRandomEmail()
        {
            return GetRandomString(10) + "@" + GetRandomString(7) + ".com";
        }

        public static int GetRandomNumber(int maxNumber)
        {
            return new Random().Next(maxNumber);
        }
    }
}
