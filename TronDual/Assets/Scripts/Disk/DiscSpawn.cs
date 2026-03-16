using UnityEngine;
using UnityEngine.InputSystem;

public class DiscSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public int DiscCount = 0;

    public InputActionProperty spawnAction;

    void OnEnable()
    {
            spawnAction.action.Enable();
            spawnAction.action.performed += SpawnObject;
    }

    void OnDisable()
    {
        spawnAction.action.performed -= SpawnObject;
        spawnAction.action.Disable();
    }

    private void SpawnObject(InputAction.CallbackContext context)
    {
        if (DiscCount <= 2)
        {
            GameObject newDisc = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            DiscCount++;

            DiscDestroy destroyScript = newDisc.GetComponent<DiscDestroy>();
            destroyScript.disc = this;
        }
    }
   
}
