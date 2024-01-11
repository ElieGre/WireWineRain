using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;
    
    void Start()
    {
        // Deactivate the end game menu at the beginning
        endGameMenu.SetActive(false);
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
