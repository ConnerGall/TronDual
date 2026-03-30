using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameManager GM;
    private AudioManager AM;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject levelSelectButtons;
    [SerializeField] private TMP_Text Title;


    private void Start()
    {
        AM = AudioManager.Instance;
        GM = GameManager.Instance;

        if (AM == null)
        {
            Debug.LogError("AudioManager is null in MainMenuManager");
        } else if (GM == null)
        {
            Debug.LogError("GameManager is null in MainMenuManager");
        } else
        {
            StartCoroutine(AM.PlayVoiceLine(6));
            AM.PlayMusic();
        }    
    }


    public void StartButton()
    {
        AM.MenuSelectSFX();

        Title.text = "Level Select";
        startButton.SetActive(false);
        quitButton.SetActive(false);
        levelSelectButtons.SetActive(true);

        GM.StartLevel(); // plays VL for level select
    }

    public void QuitButton()
    {
        AM.MenuSelectSFX();

        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        AM.MenuSelectSFX();

        if (GM != null) 
        {
            GM.currentLevel = level;
            SceneManager.LoadScene("Level " + level);
            GM.StartLevel();
        }
        else
        {
            Debug.LogError("GM is null | Cannot load scene");
        }
    }
} // end of class