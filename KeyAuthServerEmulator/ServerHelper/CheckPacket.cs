using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;

using KeyAuthServerEmulator.KeyAuthHelper.Cryptography;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography.AuthEmulator;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography.BanEmulator;
using KeyAuthServerEmulator.KeyAuthHelper.Cryptography.VarEmulator;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator
{
    internal class CheckPacket
    {
        public static string PacketType = "Unknown";
        public static string GetResponse(string Request)
        {
            string ReversedPacketType = null;
            string Response = "Unknown";
            try
            {
                ReversedPacketType = Encoding.ASCII.GetString(Cryptography.str_to_byte_arr(Request.Split('=')[1].Split('&')[0]));
                Program.Log($"Reversed PacketType: {ReversedPacketType}", "SERVER", ConsoleColor.Magenta);
            }
            catch(Exception ex)
            {
                Program.Log($"Could not reverse PacketType: {ex.Message}", "SERVER", ConsoleColor.Red);
                PacketType = "PacketTypeError";
                return null;
            }
            if (ReversedPacketType == "init")
            {
                if (BruteForce.BruteForceSecret == true)
                {
                    string[] Filter = Request.Split('&');
                    string EncKey = Filter[3];
                    string InitIV = Filter[6];
                    Program.Log("Detected Init Method from https://keyauth.win/ - Bruteforcing Secret...", "INIT", ConsoleColor.Yellow);
                    Credentials.Secret = null;
                    Credentials.Secret = BruteForce.GetSecret(Environment.CurrentDirectory + @"\Strings.txt", InitIV, EncKey);
                    File.WriteAllText(Environment.CurrentDirectory + @"\KeyAuthSecret.txt", Credentials.Secret);
                }
                PacketType = "KeyAuthInit";
                Response = InitEmulator.Emulator(Request);
                return Response;
            }
            else if (ReversedPacketType == "check")
            {
                Response = CheckEmulator.Emulator(Request);
                PacketType = "KeyAuthCheck"; 
                return Response;
            }
            else if (ReversedPacketType == "login")
            {
                Response = LoginEmulator.Emulator(Request);
                PacketType = "KeyAuthLogin";
                return Response;
            }
            else if (ReversedPacketType == "license")
            {
                Response = LicenseOnlyEmulator.Emulator(Request);
                PacketType = "KeyAuthLicenseOnly";
                return Response;
            }
            else if (ReversedPacketType == "register")
            {
                Response = RegisterEmulator.Emulator(Request);
                PacketType = "KeyAuthRegister";
                return Response;
            }
            else if (ReversedPacketType == "checkblacklist")
            {
                Response = CheckBlackEmulator.Emulator(Request);
                PacketType = "KeyAuthCheckBlack";
                return Response;
            }
            else if (ReversedPacketType == "getvar")
            {
                Response = GetVarEmulator.Emulator(Request);
                PacketType = "KeyAuthGetVar";
                return Response;
            }
            else if (ReversedPacketType == "setvar")
            {
                Response = SetVarEmulator.Emulator(Request); // buggy
                PacketType = "KeyAuthSetVar"; //buggy
                return Response;
            }
            else if (ReversedPacketType == "ban")
            {
                Response = AntiBanEmulator.Emulator(Request);
                PacketType = "KeyAuthBan";
                return Response;
            }
            else if (ReversedPacketType == "var")
            {
                Response = Var.Emulator(Request);
                PacketType = "KeyAuthVar"; ;
                return Response;
            }
            else if (ReversedPacketType == "upgrade")
            {
                Response = UpgradeEmulator.Emulator(Request);
                PacketType = "KeyAuthUpgrade";
                return Response;
            }
            else if (ReversedPacketType == "log")
            {
                Response = "";
                PacketType = "KeyAuthLog";
            }
            else
            {
                PacketType = "KeyAuthPacket [Unknown - Not Sure]";
            }
            return Response;
        }
    }
}
