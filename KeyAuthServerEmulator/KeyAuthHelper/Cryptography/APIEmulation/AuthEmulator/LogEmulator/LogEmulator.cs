using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography.CustomPayLoad;

namespace KeyAuthServerEmulator.KeyAuthHelper.Cryptography.AuthEmulator.LogEmulator
{
    internal class LogEmulator
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
                    EncryptedResponse = Cryptography.encrypt(PayLoad.Register, Credentials.EncKey, InitIV);
                }

            }
            Logger.SaveLog($"KeyAuthLog: {PayLoad.Register}");
            return EncryptedResponse;
        }
    }
}
