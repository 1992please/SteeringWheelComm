using SlimDX.DirectInput;
using System;
namespace SteeringWheel
{
    public class SteeringWheelInput
    {
        public bool connectedToTheSteeringWheel;
        public int Xaxis;
        public int Yaxis;

        Joystick mainScouter;
        JoystickState state = new JoystickState();
        DirectInput dinput = new DirectInput();
        public SteeringWheelInput()
        {
            Xaxis = -1;
            Yaxis = -1;
        }

        public bool CheckDeviceConnected()
        {

            var devices = dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);
            return devices.Count > 0;

        }

        public void BootGamePort()
        {
            var devices = dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);
            foreach (DeviceInstance device in dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                mainScouter = new Joystick(dinput, device.InstanceGuid);
                break;

            }
            if (mainScouter == null)
            {
                Console.Write("Shit");
                return;
            }




            foreach (DeviceObjectInstance deviceObject in mainScouter.GetObjects())
            {
                if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                    mainScouter.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
            }



            mainScouter.Acquire();
        }

        public void UpdateStatus()
        {
            if (mainScouter.Acquire().IsFailure)
            {
                return;
            }

            if (mainScouter.Poll().IsFailure)
            {
                return;
            }
            state = mainScouter.GetCurrentState();
            Xaxis = state.X;
            Yaxis = state.Y;
        }

    }
}
