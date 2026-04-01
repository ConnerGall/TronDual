using System.Buffers;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiscSpawn : MonoBehaviour
{
    private AudioManager AM = AudioManager.Instance;

    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public Transform leftSpawnPoint;


    public int DiscCount = 0;

    public InputActionProperty rightspawnAction;
    public InputActionProperty leftspawnAction;

    void OnEnable()
    {
            rightspawnAction.action.Enable();
            leftspawnAction.action.Enable();

        rightspawnAction.action.performed += SpawnRight;
        leftspawnAction.action.performed += SpawnLeft;
    }

    void OnDisable()
    {
        rightspawnAction.action.performed -= SpawnRight;
        leftspawnAction.action.performed -= SpawnLeft;

        rightspawnAction.action.Disable();
        leftspawnAction.action.Disable();
    }
    private void SpawnRight(InputAction.CallbackContext context)
    {
        SpawnDisc(spawnPoint);
    }

    private void SpawnLeft(InputAction.CallbackContext context)
    {
        SpawnDisc(leftSpawnPoint);
    }

    private void SpawnDisc(Transform spawnTransform)
    {
        if (DiscCount <= 2)
        {
            GameObject newDisc = Instantiate(prefabToSpawn, spawnTransform.position, spawnTransform.rotation);
            DiscCount++;

            DiscDestroy destroyScript = newDisc.GetComponent<DiscDestroy>();
            destroyScript.disc = this;
            // play summon sfx
            AM.PlayDiscSummon();
        }
        else
        {
            // play cant summon sfx
            AM.PlayCantSummon();
        }
    }
   
   
}
