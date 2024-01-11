using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;
    [SerializeField] GameObject UI;
    [SerializeField] PlayerHealth ph;
    void Start()
    {
        // Deactivate the end game menu at the beginning
        endGameMenu.SetActive(false);
    }

    private void Update()
    {
        string umbrellaInput = SerialMagnets.incomingMsg;

        if (umbrellaInput != "")
        {
            Debug.Log(umbrellaInput);
            if (umbrellaInput.Substring(0,1) == "0")
            {
                Debug.Log("Button");
                if (UI.activeSelf)
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }

    public void ShowEndGameMenu()
    {
        // Show the end game menu
        endGameMenu.SetActive(true);
    }

    public void ReloadScene()
    {
        // Reload the scene
        SceneManager.LoadScene("SampleScene");
    }
}
