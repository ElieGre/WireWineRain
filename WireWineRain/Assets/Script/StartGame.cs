using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   string umbrellaInput = SerialMagnets.incomingMsg;

        if (umbrellaInput != "")
        {
            Debug.Log(umbrellaInput);
            if (umbrellaInput.Substring(0,1) == "0")
            {
                Debug.Log("Button");
                SceneManager.LoadScene("SampleScene");
                
            }
        }
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
