using System;
using System.Linq;

namespace ClientConsole
{
    public static class RandomString
    {
        private static Random random = new Random();
        public static string Create(int length=5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
