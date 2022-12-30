using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography.CustomPayLoad;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography.AuthEmulator
{
    internal class LoginEmulator
    {
        public static string Emulator(string Request)
        {
            string[] SplitContent = Request.Split('&');
            string EncryptedResponse = null;
            string InitIV = null;
            foreach (var k in SplitContent)
            {
                if (k.StartsWith("init_iv="))
                {
                    string[] init = k.Split('=');
                    InitIV = init[1];
                    EncryptedResponse = Cryptography.encrypt(PayLoad.Login, Credentials.EncKey, InitIV);
                }

            }
            Logger.SaveLog($"KeyAuthLogin: {PayLoad.Login}");
            return EncryptedResponse;
        }
    }
}
