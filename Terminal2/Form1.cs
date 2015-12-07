using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SteeringWheelDirectx;
namespace Terminal2
{
    public partial class Form1 : Form
    {
        private Joystick joystick;
        private bool[] joystickButtons;
        public Form1()
        {
            InitializeComponent();
            joystick = new Joystick();
            connectToJoystick(joystick);
        }

        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
            }
        }

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                joyTimer.Enabled = true;
            }
            else
                joyTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                joystick.UpdateStatus();
                joystickButtons = joystick.buttons;
                output.Text = joystick.Xaxis + "";
                //if (joystick.Xaxis == 0)
                //    output.Text = "Left\n";

                //if (joystick.Xaxis == 65535)
                //    output.Text = "Right\n";

                //if (joystick.Yaxis == 0)
                //    output.Text = "Up\n";

                //if (joystick.Yaxis == 65535)
                //    output.Text = "Down\n";

                for (int i = 0; i < joystickButtons.Length; i++)
                {
                    if (joystickButtons[i] == true)
                        output.Text = "Button " + i + " Pressed\n";
                }
            }
            catch
            {
                joyTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }

        private void output_Click(object sender, EventArgs e)
        {
            output.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
