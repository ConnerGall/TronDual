using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public int musicIndex = 0;
    private bool firstPlay = true;

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource narration;
    [SerializeField] private AudioSource globalSFX;

    [SerializeField] private AudioClip[] musicTracks;
    [SerializeField] private AudioClip[] menuSFX;
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioClip summonDisc;
    [SerializeField] private AudioClip cantSummonDisc;
    


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        globalSFX.volume = 0.7f;
    }

    public IEnumerator PlayVoiceLine(int index)
    {
        Debug.Log("Playing VL clip at index: " + index);
        narration.clip = voiceLines[index];
        narration.Play();
        yield return new WaitForSeconds(voiceLines[index].length);
    }

    #region Disc
    public void PlayDiscSummon()
    {
        globalSFX.clip = summonDisc;
        globalSFX.Play();
    }

    public void PlayCantSummon()
    {
        globalSFX.clip = cantSummonDisc;
        globalSFX.Play();
    }
    #endregion

    #region Menu SFX
    public void MenuHoverSFX()
    {
        globalSFX.clip = menuSFX[0];
        globalSFX.Play();
    }

    public void MenuSelectSFX()
    {
        globalSFX.clip = menuSFX[1];
        globalSFX.Play();
    }

    #endregion

    #region Music

    public void PlayMusic()
    {
        if (firstPlay)
        {
            firstPlay = false;
            music.clip = musicTracks[musicIndex];
            music.Play();

            musicIndex = (musicIndex == 0) ? 1 : 0;
            
        } else
        {
            StartCoroutine(FadeMusic());
        }
    }

    private IEnumerator FadeMusic()
    {
        Debug.Log("Fading out music...");

        float fadeDuration = 1f;
        float startVolume = 0.5f;

        while (music.volume > 0)
        {
            music.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        // switch track
        music.Stop();
        music.clip = musicTracks[musicIndex];
        music.Play();

        musicIndex = (musicIndex == 0) ? 1 : 0;

        // fade music in
        music.volume = 0f;

        while (music.volume < startVolume)
        {
            music.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        music.volume = startVolume;

        Debug.Log("Music track changed");
    }

    #endregion


} // end of class
