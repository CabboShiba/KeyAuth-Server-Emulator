using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography
{
    internal class InitEmulator
    {
        private static string Version = "1.0"; //default
        private static string AppName = Utils.RandomString(8); //default;
        private static string OwnerID = null; //default
        
        public static string Emulator(string EncryptedInitRequests)
        {
            string[] ok = EncryptedInitRequests.Split('&');
            string encrypted = null;
            string key = null;
            string initiv = null;
            foreach(var k in ok)
            {
                if (k.StartsWith("init_iv="))
                {
                    string[] init = k.Split('=');
                    initiv = init[1];
                }
                if (k.StartsWith("enckey="))
                {
                    string[] enckey = k.Split('=');
                    key = enckey[1];
                }
                if (k.StartsWith("ver="))
                {
                    string[] CryptedVersion = k.Split('=');
                    Version = CryptedVersion[1];
                }
                if (k.StartsWith("name="))
                {
                    string[] CryptedName = k.Split('=');
                    AppName = CryptedName[1];
                }
                if (k.StartsWith("ownerid="))
                {
                    string[] CryptedOwnerID = k.Split('=');
                    OwnerID = CryptedOwnerID[1];
                }
            }
            Credentials.EncKey = GetEncKey(key, initiv);
            Version = Cryptography.decrypt(Version, Credentials.Secret, initiv);
            AppName = Encoding.UTF8.GetString(Cryptography.str_to_byte_arr(AppName));
            OwnerID = Encoding.UTF8.GetString(Cryptography.str_to_byte_arr(OwnerID));
            string InitResponse = $"{{\"success\":true,\"message\":\"Initialized\",\"sessionid\":\"{Credentials.RandomString(10)}\",\"appinfo\":{{\"numUsers\":\"{Credentials.RandomNumber(11, 49)}\",\"numOnlineUsers\":\"{Credentials.RandomNumber(3, 10)}\",\"numKeys\":\"{Credentials.RandomNumber(5, 22)}\",\"version\":\"{Version}\",\"customerPanelLink\":\"https:\\/\\/keyauth.cc\\/panel\\/{Credentials.RandomString(6)}\\/{AppName}\\/\"}}}}";
            encrypted = Cryptography.encrypt(InitResponse, Credentials.Secret, initiv);
            GetKeyAuthData(Version, AppName, OwnerID);
            Logger.SaveLog($"KeyAuthInit: {InitResponse}");
            return encrypted;
        }

        private static string GetEncKey(string EncryptedEncKey, string InitIV)
        {
            string EncKey = Cryptography.decrypt(EncryptedEncKey, Credentials.Secret, InitIV);
            return EncKey;
        }

        private static void GetKeyAuthData(string Version, string Name, string OwnerID)
        {
            try
            {
                string Content = $"Application Name: {Name}\nOwnerId: {OwnerID}\nApplication Secret: {Credentials.Secret}\nApplication Version: {Version}";
                Program.Log("KeyAuth Application Info obtained.", "KEYAUTH", ConsoleColor.Yellow);
                File.WriteAllText(Environment.CurrentDirectory + @"\KeyAuthData.txt", Content);
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}
