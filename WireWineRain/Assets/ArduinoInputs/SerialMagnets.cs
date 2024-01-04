using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;

public class SerialMagnets : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    private static string outgoingMsg = "";

    //SerialPort data_stream;
    //public string Com_Port = "COM3";
    //public int Baud_Rate = 115200;

    private static void DataThread()
    {
        sp = new SerialPort("COM3", 9600);
        sp.Open();

        while(true)
        {
            if(outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                outgoingMsg = "";
            }

            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            IOThread.Start();
        }
        catch 
        {
            Debug.Log("Start Error");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if(incomingMsg != "")
            {
                Debug.Log(incomingMsg);
            }
        }
        catch
        {

        }
    }
}
