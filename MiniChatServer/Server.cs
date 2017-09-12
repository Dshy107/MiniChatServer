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
            while (true)
            {
               TcpClient client = server.AcceptTcpClient();
               Task.Run(()=> DoClient(client));
            }
            
        }

            private static void DoClient(TcpClient client)
        {

            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string inlinje = sr.ReadLine();
                //Console.WriteLine(inlinje);
                string outLine = HandleClient(inlinje);
                //sw.WriteLine(inlinje);
                sw.WriteLine(outLine);
                sw.Flush();
            }
        }
        public static string HandleClient(string line)
        {
            Console.WriteLine("Server modtaget : " + line);
            return line;
        }
            
            }
            
        }
        
        
        
 