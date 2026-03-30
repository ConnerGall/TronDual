using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioManager AM;
    [SerializeField] private Image blackScreen;

    public int currentLevel = 0;

    private void Start()
    {
        AM = AudioManager.Instance;

        Color color = blackScreen.color;
        blackScreen.color = new Color(color.r, color.g, color.b, 0f);
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
    public void StartLevel()
    {
        FadeFromBlack();

        if (currentLevel == 0)
        {
            StartCoroutine(AM.PlayVoiceLine(7));
        } 
        else if (currentLevel > 0 && currentLevel < 6)
        {
            StartCoroutine(AM.PlayVoiceLine(currentLevel));
            AM.PlayMusic();
        } 
        else
        {
            Debug.LogError("Invalid current level | no voice line to play");
        }
    }

    
    public void FadeToBlack()
    {
        if (blackScreen != null)
        {
            StartCoroutine(FadeToBlackCoroutine());
        } else
        {
            Debug.LogError("blackScreen image is null!");
        }
        
    }

    public void FadeFromBlack()
    {
        if (blackScreen != null)
        {
            StartCoroutine(FadeFromBlackCoroutine());
        }
        else
        {
            Debug.LogError("blackScreen image is null!");
        }
    }

    private IEnumerator FadeToBlackCoroutine()
    {
        float duration = 3f;
        float time = 0f;

        Color color = blackScreen.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, time / duration);
            blackScreen.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure fully black at end
        blackScreen.color = new Color(color.r, color.g, color.b, 1f);
    }

    private IEnumerator FadeFromBlackCoroutine()
    {
        float duration = 3f;
        float time = 0f;

        Color color = blackScreen.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / duration);
            blackScreen.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure fully transparent at end
        blackScreen.color = new Color(color.r, color.g, color.b, 0f);
    }

    public void FinishedSimulation()
    {
        StartCoroutine(AM.PlayVoiceLine(0));
        SceneManager.LoadScene("StartMenu");
    }

    

} // end of class
