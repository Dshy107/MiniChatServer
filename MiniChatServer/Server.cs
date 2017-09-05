using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Server
    {
        public Server()
        {

        }
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            using (TcpClient socket = server.AcceptTcpClient())
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            { 
                while (true)
                {
                    string inlinje = sr.ReadLine();
                    //Console.WriteLine(inlinje);
                    string myLine = Console.ReadLine();
                    //sw.WriteLine(inlinje);
                    sw.Flush();

                    if (inlinje == "STOP!" || myLine == "STOP!")
                    {
                        server.Stop();
                    }
                }
            }
        }
        
        
        
    }
}
