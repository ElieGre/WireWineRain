using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class RainBlinkLight : MonoBehaviour
{
    // RAIN INDEX: 0 - NO RAIN, 1 - ABOUT TO RAIN, 2 - RAINING
    public int RainControlIndex = 0;
    [SerializeField] SerialMagnets Connection;
    [SerializeField] CollisionTest collision;

    private void Update()
    {
        if(collision.inside)
        {
            NoRain();
        }
        else
        {
            Raining();
        }
    }

    public void NoRain()
    {
        SerialMagnets.outgoingMsg = "0";
        Debug.Log("LED Off");
    }
    public void AboutToRain()
    {
        SerialMagnets.outgoingMsg = "1";
    }
    public void Raining()
    {
        SerialMagnets.outgoingMsg = "2";
        Debug.Log("LED On");
    }
}
