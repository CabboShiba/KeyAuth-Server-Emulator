using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
    internal class Server
    {
        public static HttpListener ServerListener;
        public static string Payload = string.Empty;
        public static string SavePayload = Environment.CurrentDirectory + @"\PayLoad\PayLoad.txt";
        private const int StatusCode = 200;
        public static async Task StartServerListenerAsync()
        {
            while (true)
            {
                HttpListenerContext ctx = await ServerListener.GetContextAsync();
                
                HttpListenerRequest Request = ctx.Request;
                
                HttpListenerResponse Response = ctx.Response;
                
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Program.Log($"Accepted request from: {Request.Url}", "SERVER", ConsoleColor.Green);
                Program.Log($"Request Host: {Request.UserHostName}", "SERVER", ConsoleColor.Green);
                Program.Log($"Request Method: {Request.HttpMethod}", "SERVER", ConsoleColor.Green);
                Program.Log($"Request KeepAlive: {Request.KeepAlive}", "SERVER", ConsoleColor.Green);
                Program.Log($"Request ContentType: {Request.ContentType}", "SERVER", ConsoleColor.Green);
                if(Request.UserAgent != null)
                {
                    Program.Log($"Request UserAgent: {Request.UserAgent}", "SERVER", ConsoleColor.Green);
                }
                if (Request.HttpMethod == "POST" || Request.HttpMethod == "PUT")
                {
                    string Data = GetData(Request);
                    Payload = CheckPacket.GetResponse(Data);
                    Program.Log($"Request Content: {Data.Substring(0, 30)}.....", "SERVER", ConsoleColor.Magenta);
                }
                try
                {
                    if (string.IsNullOrEmpty(Payload))
                    {
                        Payload = "UnknownRequest";
                    }
                    byte[] ResponsePayload = Encoding.UTF8.GetBytes(Payload);
                    Response.ContentType = "text/html";
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentLength64 = ResponsePayload.LongLength;
                    Response.StatusCode = StatusCode;
                    await Response.OutputStream.WriteAsync(ResponsePayload, 0, ResponsePayload.Length);
                    Response.Close();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.Log("Could not send Payload: ", "SERVER", ConsoleColor.Red);
                    Console.ResetColor();
                    Program.Log(ex.Message, "SERVER", ConsoleColor.Red );
                }
            }
        }


        public static string GetData(HttpListenerRequest Request)
        {
            using (System.IO.Stream body = Request.InputStream)
            {
                using (var reader = new System.IO.StreamReader(body, Request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
