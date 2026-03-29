using System.Collections;
using UnityEngine;

public class DroneSFX : MonoBehaviour
{
    [SerializeField] private AudioClip droneIdle;
    [SerializeField] private AudioClip droneDestroy;
    [SerializeField] private AudioSource drone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

        if (drone == null)
        {
            drone = GetComponent<AudioSource>();
        }

        drone.volume = 0.7f;
        drone.clip = droneIdle;
        drone.Play();
    }

    public IEnumerator PlayDroneDestroyedSFX()
    {
        if (drone != null)
        {
            drone.Stop();
            drone.clip = droneDestroy;
            drone.Play();
        }
        else
        {
            Debug.LogError("Cannot find AudioSource for Drone");
        }

        yield return new WaitForSeconds(droneDestroy.length);
    }
}
