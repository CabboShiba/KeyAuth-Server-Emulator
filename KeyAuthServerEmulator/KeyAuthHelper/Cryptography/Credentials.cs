using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography
{
    internal class Credentials
    {
        public static string Secret = String.Empty;
        public static string EncKey = null;
        public static bool SpoofIP = true;
        private static Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "qwertyuioplkjhgfdsazxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private static string GetSpoofedIP()
        {
            int q = Random.Next(100, 140);
            int w = Random.Next(20, 50);
            int e = Random.Next(10, 50);
            int r = Random.Next(20, 30);
            string IP = $"{q}.{w}.{e}.{r}";
            return IP;
        }

        public static string RandomDate()
        {
            int RandomDate = Random.Next(1, 5000);
            string Date = "191353" + RandomDate;
            return Date;
        }
        public static int RandomCreationDate()
        {
            int RandomDate = Random.Next(1609462861, 1640998861);
            return RandomDate;
        }
        public static int RandomNumber(int Min, int Max)
        {
            int Number = 1;
            if (Min >= Max)
            {
                Number = 1;
            }
            else
            {
                Number = Random.Next(Min, Max);
            }
            return Number;
        }
        private static string GetRealIP()
        {
            string IP = null;
            try
            {
                WebClient Client = new WebClient();
                IP = Client.DownloadString("https://api.ipify.org");
            }
            catch (Exception ex)
            {
                IP = GetSpoofedIP();
            }
            return IP;
        }
        public static string IP()
        {
            string IP = null;
            if (SpoofIP == true)
            {
                IP = GetSpoofedIP();
            }
            else if (SpoofIP == false)
            {
                IP = GetRealIP();
            }
            return IP;
        }
    }
}
