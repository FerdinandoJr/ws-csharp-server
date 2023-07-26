using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace csharp_server
{
    public class Echo: WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Received message from client: "+ e.Data);
            Send(e.Data);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            String host = "ws://localhost:7890";

            WebSocketServer wssv = new WebSocketServer(host);

            wssv.AddWebSocketService<Echo>("/Echo");

            wssv.Start();
            Console.WriteLine("WS server started on "+host+"/Echo");

            Console.ReadKey();

            wssv.Stop();

        }
    }
} 
