using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public bool inside;

    void OnTriggerEnter(Collider other){
    inside = true;
    //Debug.Log("inside");

    }

    void OnTriggerExit(Collider other){
        inside = false;
    //Debug.Log("outside");
    
    }
}
