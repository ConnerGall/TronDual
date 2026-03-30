using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    [SerializeField] private DroneSFX DroneSFX;

    private void Start()
    {
        if (DroneSFX == null)
        {
            DroneSFX = GetComponent<DroneSFX>();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerDisk"))
        {
            // Play SFX before destroying
            if (DroneSFX == null)
            {
                Debug.LogError("DroneSFX is NULL!!!!!!!! AHHHH!!!");
            }

            StartCoroutine(DroneSFX.PlayDroneDestroyedSFX());

            Destroy(gameObject);
        }
    }
}
