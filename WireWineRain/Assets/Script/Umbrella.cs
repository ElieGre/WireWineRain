using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Umbrella : MonoBehaviour
{
    [SerializeField] Animator UmbrellaAnim;
    bool isUmbrellaOpen;
    [SerializeField] GameObject UI;
    [SerializeField] PlayerHealth ph;

    // Update is called once per frame
    void Update()
    {
        string umbrellaInput = SerialMagnets.incomingMsg;
        if(umbrellaInput != "")
        {
            if (umbrellaInput == "1")
            {
                isUmbrellaOpen = false;
                UmbrellaAnim.SetBool("IsOpen", false);
                Debug.Log("close");
            }
            if (umbrellaInput == "2")
            {
                isUmbrellaOpen = true;
                UmbrellaAnim.SetBool("IsOpen", true);
                Debug.Log("open");
            }
        }
        
    }
    
    public bool GetIsUmbrellaOpen()
    {
        return isUmbrellaOpen;
    }
}
