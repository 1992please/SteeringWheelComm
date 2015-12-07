using SteeringWheel;
using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!SteeringWheelInput.CheckDeviceConnected()) ;
            SteeringWheelInput st = new SteeringWheelInput();

            //Console.WriteLine("no joystick yet");
            //while (!st.connectedToTheSteeringWheel) ;
            //Console.WriteLine("connected");
            for (int i = 0; true; i++)
            {
                if (i % 50 == 0)
                {
                    st.UpdateStatus();
                    Console.WriteLine(st.Xaxis + " " + st.Yaxis + "\n");
                }
            }
        }
    }
}
