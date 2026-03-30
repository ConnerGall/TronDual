using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioManager AM;
    [SerializeField] private GameObject Enemies;

    public int currentLevel = 0;

    private void Start()
    {
        AM = AudioManager.Instance;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // run the logic to start each of the levels
    // music, voice lines, enemy spawns
    public void StartLevel()
    {
        if (currentLevel == 0)
        {
            StartCoroutine(AM.PlayVoiceLine(7));
        } 
        else if (currentLevel > 0 && currentLevel < 6)
        {
            StartCoroutine(AM.PlayVoiceLine(currentLevel));
        } 
        else
        {
            Debug.LogError("Invalid current level | no voice line to play");
        }

        AM.PlayMusic();
    }

    public void FinishedSimulation()
    {
        StartCoroutine(AM.PlayVoiceLine(0));
        SceneManager.LoadScene("StartMenu");
    }

    

} // end of class
