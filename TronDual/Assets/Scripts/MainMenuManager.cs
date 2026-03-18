using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject levelSelectButtons;
    [SerializeField] private TMP_Text Title;

    public void StartButton()
    {
        Title.text = "Level Select";

        startButton.SetActive(false);
        quitButton.SetActive(false);
        levelSelectButtons.SetActive(true);
    }

    public void LevelSelect(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitButton()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}