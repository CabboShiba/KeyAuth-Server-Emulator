using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography
{
    internal class BruteForce
    {
        private static string LowerCase = "abcdefghjklmnopqrstuvwxyz";
        //  private static string WhiteList = $"~Åªq┼ôÉ;ª↓┼¿ÌÐ²¨Íï©¥¦à??©▲çº¦Ú♫?¦┼æ¹]Ü`ùäáì¿ë{{þ'Ô-æ\\Ç>ýOë~Í`Ý²?¾☼í☼½Ó¼½?ÁÜ%Ö½É»Þ→¨-_ß6þª>á^♣Ä~▲º{{ÞÑ~(▼?'Ä­¼[?";
        private static string WhiteList = $"1234567890{LowerCase}{LowerCase.ToUpper()}";
        private static bool BlackListed = false;
        public static bool BruteForceSecret = true;
        public static string GetSecret(string FilePath, string InitIV, string EncKey)
        {
            EncKey = EncKey.Remove(0, 7);
            InitIV = InitIV.Remove(0, 8);
            string Secret = null;
            var regex = new Regex("([A-Za-z0-9]){64}");
            foreach (var Line in File.ReadLines(FilePath))
            {
                string DecryptedKey = null;
                try
                {
                    var matches = regex.Matches(Line);
                    foreach (Match match in matches)
                    {
                        DecryptedKey = Cryptography.decrypt(EncKey, match.ToString(), InitIV);
                        if (Checker(match.ToString(), DecryptedKey) == true)
                        {
                            Secret = match.ToString();
                            return Secret;
                        }
                    }
                }
                catch (Exception ex)
                {
                    DecryptedKey = null;
                }
                if (Secret != null)
                {
                    break;
                }
            }
            return Secret;
        }

        private static void Found(string Line)
        {
            Program.Log($"Succesfully bruteforced Secret: {Line}", "INIT", ConsoleColor.Yellow);
        }
        private static bool Checker(string Hit, string DecryptedKey)
        {
            foreach (var Chars in DecryptedKey.ToCharArray())
            {
                if (!WhiteList.Contains(Chars.ToString()))
                {
                    BlackListed = true;
                    break;
                }
            }
            if (BlackListed == false)
            {
                Found(Hit);
                return true;
            }
            return false;
        }
    }
}
