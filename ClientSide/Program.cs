using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace ClientSide
{
    class EmployeeTCPClient
    {
        public static void Main(string[] args)
        {
            // TcpClient client = new TcpClient(Dns.GetHostName(), 6666);
            TcpClient client = new TcpClient();
            bool connected = false;
            while (!connected)
            {
                try
                {
                    client.Connect(new IPEndPoint(GetLocalIpAddress(), 6666));
                    connected = true;
                }
                catch
                {
                    connected = false;
                }
            }
            try
            {
                Stream s = client.GetStream();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                // Console.WriteLine(sr.ReadLine());
                while (true)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    sw.WriteLine(name);
                    if (name == "") break;
                    Console.WriteLine(sr.ReadLine());
                }
                s.Close();
            }
            finally
            {
                // code in finally block is guranteed 
                // to execute irrespective of 
                // whether any exception occurs or does 
                // not occur in the try block
                client.Close();
            }
        }

        private static IPAddress GetLocalIpAddress()
        {
            string name = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return addr;
                }
            }
            return null;
        }
    }
}
