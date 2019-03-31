using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

public class OrientationController
{
    // Store values read from sensor
    private Vector3 gravity;
    private Quaternion orientation;

    // Serial and threading for reading from sensor
    private SerialPort serialPort;
    Thread receiveThread;
    private string comPort;
   
    public OrientationController()
    {
        comPort = "/dev/ttyACM0";
        init();
    }

    public OrientationController(string port)
    {
        comPort = port;
        init();
    }

    public Vector3 getGravityVector()
    {
        return gravity;
    }

    public Quaternion getOrientation()
    {
        return orientation;
    }

    public string getCOMvalue()
    {
        return comPort;
    }

    // Thread for processing incoming sensor data
    private void init()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    private void ReceiveData()
    {
        comPort = Load("settings.txt");
        serialPort = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
        OpenConnection();

        while (true)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    string data = serialPort.ReadLine();
                    if (data != null)
                    {
                        data = data.Trim();
                        string[] inputs = data.Substring(0, data.Length).Split(';');
                        if (inputs.Length == 7)
                        {
                            orientation.x = -float.Parse(inputs[1]);
                            orientation.y = -float.Parse(inputs[2]);
                            orientation.z = float.Parse(inputs[0]);
                            orientation.w = float.Parse(inputs[3]);
                            gravity.x = float.Parse(inputs[4]);
                            gravity.y = float.Parse(inputs[5]);
                            gravity.z = float.Parse(inputs[6]);

                        }
                    }
                }
                catch (System.Exception)
                {

                }
            }

        }
    }

    void OpenConnection()
    {
        if (serialPort != null)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                serialPort.Open();
                serialPort.ReadTimeout = 50;
                Debug.Log("Port Opened!");
            }
        }
    }

    void OnDestroy()
    {
        serialPort.Close();
        if (receiveThread != null)
            receiveThread.Abort();
        Debug.Log("Port closed!");
    }

    // Read from a text file the port number of the controller.
    // The port number can be found in the device manager.
    string Load(string fileName)
    {
        string readPort = "";
        try
        {
            string line;
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        readPort = line;
                    }
                }
                while (line != null);
                theReader.Close();
                return readPort;
            }
        }
        catch (IOException)
        {
            return null;
        }
    }

   
}
