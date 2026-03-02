using UnityEngine;

public class DiscDestroy : MonoBehaviour
{
    int count = 0;
    public DiscSpawn disc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            count++;
        }
        Debug.Log(count);
        if (count >= 3)
        {
            Destroy(gameObject);
            if (disc != null)
            {
                disc.DiscCount--;
            }
            
            Debug.Log("Destroyed");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
