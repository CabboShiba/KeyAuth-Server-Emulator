using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class CheckEmulator
    {
        public static string Emulator(string Request)
        {
            string[] ok = Request.Split('&');
            string encrypted = null;
            string initiv = null;
            foreach (var k in ok)
            {
                if (k.StartsWith("init_iv="))
                {
                    string[] init = k.Split('=');
                    initiv = init[1];

                    
                    encrypted = Cryptography.encrypt(PayLoad.SessionValidated, Credentials.EncKey, initiv);
                }
              
            }
            Logger.SaveLog($"KeyAuthCheck: {PayLoad.SessionValidated}");
            return encrypted;
        }
    }
}
