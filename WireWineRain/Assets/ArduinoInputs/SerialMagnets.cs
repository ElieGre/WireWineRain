using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;
using UnityEditor.VersionControl;

public class SerialMagnets : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    public static SerialPort sp;
    public static string incomingMsg = "";
    public static string outgoingMsg = "";
    public static bool isUmbrellaOpen;
    [SerializeField] PlayerHealth ph;
    private static void DataThread()
    {
        sp = new SerialPort("COM3", 9600);
        sp.Open();

        while(true)
        {
            if (outgoingMsg != "")
            {
                sp.WriteLine(outgoingMsg);
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
            if (incomingMsg != "")
            {
                
                //Debug.Log(incomingMsg);
                
            }
        }
        catch
        {

        }
    }
    public void SendMessageToArduino(string Message)
    {
        //if(Message != "")
        //{
        //    sp.WriteLine(Message);
        //    Message = "";
           
        //}
    }
}
