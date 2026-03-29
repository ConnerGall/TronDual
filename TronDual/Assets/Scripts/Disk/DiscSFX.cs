using System.Collections;
using UnityEngine;

public class DiscSFX : MonoBehaviour
{
    [SerializeField] private AudioSource disc;
    [SerializeField] private AudioClip hitWall;
    [SerializeField] private AudioClip discWoosh;
    [SerializeField] private AudioClip catchDisc;


    void Awake()
    {
        if (disc == null)
        {
            disc = GetComponent<AudioSource>();
        }

        disc.volume = 0.7f;
    }

    public void PlayCatchDisc()
    {
        disc.clip = catchDisc;
        disc.Play();
    }

    public void PlayDiscFlying()
    {
        disc.clip = discWoosh;
        disc.Play();
    }

    public void DiscHitWall()
    {
        StartCoroutine(WooshAfterWall());

        PlayDiscFlying();
    }

    private IEnumerator WooshAfterWall()
    {
        disc.clip = hitWall;
        disc.Play();
        yield return new WaitForSeconds(hitWall.length);
    }
}
