using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using SteeringWheel;
//using System.Timers;
namespace ServerSide
{
    class EmployeeTCPServer
    {
        static TcpListener listener;
        static SteeringWheelInput st;
        const int LIMIT = 1; //5 concurrent clients

        public static void Main()
        {
            st = new SteeringWheelInput();
            while (!st.CheckDeviceConnected()) ;
            st.BootGamePort();

            listener = new TcpListener(GetLocalIpAddress(), 6666);
            listener.Start();
            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                t.Start();
            }
        }
        public static void Service()
        {
            while (true)
            {
                Socket soc = listener.AcceptSocket();

                Stream s = new NetworkStream(soc);
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true; // enable automatic flushing
                try
                {
                    while (true)
                    {
                        string name = sr.ReadLine();
                        if (name == "" || name == null) break;
                        //Console.WriteLine(name);
                        //string job = "Good";
                        //if (job == null) job = "No such employee";
                        try
                        {
                            st.UpdateStatus();
                            Console.WriteLine(st.Xaxis + " " + st.Yaxis);
                        }
                        catch
                        {
                            Console.WriteLine("shit1");
                            while (!st.CheckDeviceConnected()) ;
                            st.BootGamePort();
                            st.UpdateStatus();
                        }
                        Console.WriteLine(st.Xaxis + " " + st.Yaxis);
                        sw.WriteLine(st.Xaxis + " " + st.Yaxis);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("shit2");

                }
                finally
                {
                    s.Close();
                    soc.Close();
                }

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
