using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] int enemyCount;
    public int desCount = 0;
    private GameManager GM = GameManager.Instance;
    

    public void incrementDestroyed()
    {
        desCount++;
        Debug.Log("Destroyed count: " + desCount);

        checkIfLevelComplete();
    }

    private void checkIfLevelComplete()
    {
        if (enemyCount == desCount)
        {
            // trigger some audio

            SwitchLevel();
        }
    }

    private void SwitchLevel()
    {
        GM.FadeToBlack();

        if (GM != null) 
        {
            GM.currentLevel++;

            if (GM.currentLevel >= 6)
            {
                GM.currentLevel = 0;
                GM.FinishedSimulation();
            }

            Debug.Log("Loading level " + GM.currentLevel);
            SceneManager.LoadScene("Level " + GM.currentLevel);
            GM.StartLevel();
        } else
        {
            Debug.LogError("GM is null | Cannot load scene");
        }
    }
}
