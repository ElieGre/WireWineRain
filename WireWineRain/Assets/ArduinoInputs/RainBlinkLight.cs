using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class RainBlinkLight : MonoBehaviour
{
    // RAIN INDEX: 0 - NO RAIN, 1 - ABOUT TO RAIN, 2 - RAINING
    [SerializeField] int RainControlIndex = 0;
    [SerializeField] SerialMagnets Connection;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if(RainControlIndex == 0)
        {
            NoRain();
        }
        else if (RainControlIndex == 1)
        {
            AboutToRain();
        }
        else if (RainControlIndex == 2)
        {
            Raining();
        }
    }

    public void NoRain()
    {
        SerialMagnets.outgoingMsg = "0";
    }
    public void AboutToRain()
    {
        SerialMagnets.outgoingMsg = "1";
    }
    public void Raining()
    {
        SerialMagnets.outgoingMsg = "2";
    }
}
