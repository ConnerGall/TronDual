using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    public int destoryedObjects = 0;
    public ChangeLevel change;
    private void OnCollisionEnter(Collision collision)
    {
        //change.incrementDestroyed();
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
