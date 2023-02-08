using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator
{
    internal class FileCheck
    {
        public static void Check()
        {
            string EncKey = Environment.CurrentDirectory + @"\EncKey.txt";
            string Secret = Environment.CurrentDirectory + @"\KeyAuthSecret.txt";
            string Strings = Environment.CurrentDirectory + @"\Strings.txt";
            if (File.Exists(EncKey))
            {
                KeyAuthServerEmulator.KeyAuthHelper.Cryptography.Credentials.EncKey = File.ReadAllText(Environment.CurrentDirectory + @"\EncKey.txt");
            }
            else
            {
                File.Create(EncKey);
            }
            try
            {
                if (!File.Exists(Secret))
                {
                    Program.Log($"Please provide Application Strings here: {Strings}", "CONFIG", ConsoleColor.Red);
                    File.Create(Secret);
                }
                else if (File.ReadAllLines(Secret)[0].Length > 0)
                {
                    BruteForce.BruteForceSecret = false;
                    Program.Log("Using KeyAuth Secret: " + File.ReadAllLines(Secret)[0], "CONFIG", ConsoleColor.Cyan);
                    Credentials.Secret = File.ReadAllLines(Secret)[0];
                    return;
                }
            }
            catch (Exception ex)
            {
                BruteForce.BruteForceSecret = true;
            }
            if (!File.Exists(Strings) || File.ReadAllText(Strings).Length == 0)
            {
                File.Create(Strings);
                Program.Log("Application Strings not found. In order to bruteforce the Secret, you need to provide a list of strings to bruteforce.", "INIT", ConsoleColor.Red);
                BruteForce.BruteForceSecret = false;
            }
            return;
        }
    }
}
