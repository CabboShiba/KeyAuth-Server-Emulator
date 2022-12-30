using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography.CustomPayLoad
{
    internal class PayLoad
    {
        public static string SessionValidated = "{\"success\":true,\"message\":\"Session is validated.\"}";
        public static string License = $"{{\"success\":true,\"message\":\"Logged in!\",\"info\":{{\"username\":\"{Credentials.RandomString(10)}\",\"subscriptions\":[{{\"subscription\":\"{Credentials.RandomString(10)}\",\"key\":\"{Credentials.RandomString(10)}\",\"expiry\":\"{Credentials.RandomDate()}\",\"timeleft\":{Credentials.RandomDate()}}}],\"ip\":\"{Credentials.IP()}\",\"hwid\":\"{Credentials.RandomString(30)}\",\"createdate\":\"{Credentials.RandomCreationDate()}\",\"lastlogin\":\"{Credentials.RandomCreationDate()}\"}}";
        public static string Login = $"{{\"success\":true,\"message\":\"Logged in!\",\"info\":{{\"username\":\"{Credentials.RandomString(10)}\",\"subscriptions\":[{{\"subscription\":\"{Credentials.RandomString(10)}\",\"key\":\"{Credentials.RandomString(10)}\",\"expiry\":\"{Credentials.RandomDate()}\",\"timeleft\":{Credentials.RandomDate()}}}],\"ip\":\"{Credentials.IP()}\",\"hwid\":\"{Credentials.RandomString(30)}\",\"createdate\":\"{Credentials.RandomCreationDate()}\",\"lastlogin\":\"{Credentials.RandomCreationDate()}\"}}";
        public static string Register = $"{{\"success\":true,\"message\":\"Logged in!\",\"info\":{{\"username\":\"{Credentials.RandomString(10)}\",\"subscriptions\":[{{\"subscription\":\"{Credentials.RandomString(10)}\",\"key\":\"{Credentials.RandomString(10)}\",\"expiry\":\"{Credentials.RandomDate()}\",\"timeleft\":{Credentials.RandomDate()}}}],\"ip\":\"{Credentials.IP()}\",\"hwid\":\"{Credentials.RandomString(30)}\",\"createdate\":\"{Credentials.RandomCreationDate()}\",\"lastlogin\":\"{Credentials.RandomCreationDate()}\"}}}}";
        public static string AntiBan = "{\"success\":true,\"message\":\"Session is validated.\"}";
        public static string CheckBlack = "{\"success\":false,\"message\":\"Client is not blacklisted\"}";
        public static string GetVar = $"{{\"success\":true,\"message\":\"Successfully retrieved variable\",\"response\":\"{Credentials.RandomString(10)}\"}}";
        public static string SetVar = "{\"success\":true,\"message\":\"Successfully set variable\"}";
        public static string VarJson = $"{{\"success\":true,\"message\":\"{Credentials.RandomString(Credentials.RandomNumber(4, 10))}\"}}";
        public static string Upgrade = $"{{\"success\":true,\"message\":\"Upgraded successfully\"}}";
    }
}
