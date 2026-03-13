using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] int enemyCount;
    TargetDestroy destroyedEnemies;
    public int desCount = 0;
    
    void Start()
    {
        
    }

    public void incrementDestroyed()
    {
        desCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == desCount)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }
}
