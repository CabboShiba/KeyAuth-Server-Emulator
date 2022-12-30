using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading;
using System.Net.Sockets;
using static KeyAuthServerEmulator.Server;
using System.Net.Http;

/**
 * FULL CREDITS TO HTTPS://GITHUB.COM/CABBOSHIBA
 * DISCORD: FreeCabbo11#9191
 * TELEGRAM: HTTPS://T.ME/CABBOSHIBA
 * 
 * If you do not get an answer on Discord for 48 Hours, this means I got banned. Contact me on Telegram.
 */

namespace KeyAuthServerEmulator
{
    internal class Program
    {
        private static string LocalHostURL = null;
        private static bool KeyAuth = true;
        static void Main(string[] args)
        {
            FileCheck.Check();
            Console.Title = Utils.RandomString(12);
            
            KeyAuthHelper.Cryptography.Credentials.SpoofIP = true; //it hides your real IP. (recommended)
            if (HttpListener.IsSupported == false)
            {
                Log("HTTPListener is not supported on your PC/OS.", "SERVER", ConsoleColor.Red);
                Utils.Leave();
            }
            
            string SubDomain = "KeyAuthServerEmulator";
            
            LocalHostURL = $"http://127.0.0.1/{SubDomain}/";
            
            if (CheckServer(SubDomain) == true)
            {
                Log($"Looks like KeyAuthServerEmulator is already running here: {LocalHostURL}", "CONFIG", ConsoleColor.Cyan);
                Log("Do you want to use another RANDOM URL? [Example: http://127.0.0.1/xxx/]", "CONFIG", ConsoleColor.Cyan);
                Log("1- Random URL", "CONFIG", ConsoleColor.Cyan);
                Log("2- Custom URL", "CONFIG", ConsoleColor.Cyan);
                if(int.Parse(Console.ReadLine()) == 1)
                {
                    SubDomain = Utils.RandomString(12); 
                    LocalHostURL = $"http://127.0.0.1/{SubDomain}/";
                    Log($"Succesfully changed Server URL: {LocalHostURL}", "CONFIG", ConsoleColor.Cyan);
                }
                else
                {
                    Log("Please provide a different SubDomain: ", "CONFIG", ConsoleColor.Cyan);
                    SubDomain = Console.ReadLine();
                    if(SubDomain == "KeyAuthServerEmulator")
                    {
                        SubDomain = Utils.RandomString(12);
                        LocalHostURL = $"http://127.0.0.1/{SubDomain}/";
                    }
                }
            }
            try
            {
                ServerListener = new HttpListener();             
                ServerListener.Prefixes.Add(LocalHostURL);
                ServerListener.Start();
                Log($"Server succesfully started and listening on: {LocalHostURL}", "CONFIG", ConsoleColor.Cyan);
                Console.Title = $"[{DateTime.Now}] ServerEmulator started on {LocalHostURL}";
                if (KeyAuth == false)
                {
                    File.WriteAllText(Environment.CurrentDirectory + @"\PayLoad.txt", Payload);
                }
            }
            catch (Exception ex)
            {
                Log("Error detected: ", "ERROR", ConsoleColor.Red);
                Log(ex.ToString(), "ERROR", ConsoleColor.Red);
                Utils.Leave();
            }
            try
            {
                Task Listener = Server.StartServerListenerAsync();
                Listener.GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {
                Log("Error detected: ", "ERROR", ConsoleColor.Red);
                Log(ex.ToString(), "ERROR", ConsoleColor.Red);
                Utils.Leave();
            }
            Utils.Leave();
        }
        public static void Log(string Data, string Type, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"[{DateTime.Now} - {Type}] {Data}");
            Console.ResetColor();
        }
        
        //shit way to check if server is running, but idc
        private static bool CheckServer(string SubDomain)
        {
            try
            {
                WebClient Client = new WebClient();
                Client.DownloadString(LocalHostURL + SubDomain + "/");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
