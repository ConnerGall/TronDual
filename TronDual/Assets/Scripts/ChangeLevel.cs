using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int enemyCount;
    public int desCount = 0;
    
    void Start()
    {
        
    }

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

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Loading Scene " + currentSceneIndex);
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
