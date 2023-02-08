using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    internal class Logger
    {
        public static void SaveLog(string Content)
        {
            string Log = $"[{DateTime.Now}] {Content}\n";
            File.AppendAllText(Environment.CurrentDirectory + @"\ServerLogs.txt", Log);
        }
    }
}
