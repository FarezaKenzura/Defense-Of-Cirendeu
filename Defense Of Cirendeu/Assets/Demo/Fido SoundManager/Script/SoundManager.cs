using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] backgroundMusicClips;
    public AudioClip[] sfxClips;

    public AudioSource backgroundMusicSource, sfxSource;

    private void Awake()
    {
        // Singleton pattern untuk memastikan hanya ada satu instance SoundManager di seluruh game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Subscribe ke event sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Memeriksa indeks build scene untuk memutuskan music background yang akan diputar
        int sceneIndex = scene.buildIndex;
        if (sceneIndex >= 0 && sceneIndex < backgroundMusicClips.Length)
        {
            PlayBackgroundMusic(backgroundMusicClips[sceneIndex]);
        }
        else
        {
            Debug.LogWarning("No background music assigned for scene index: " + sceneIndex);
        }
    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (musicClip == null)
        {
            Debug.LogWarning("No music clip provided!");
            return;
        }

        if (backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }

        backgroundMusicSource.clip = musicClip;
        backgroundMusicSource.Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < 0 || sfxIndex >= sfxClips.Length)
        {
            Debug.LogWarning("Invalid SFX index!");
            return;
        }

        sfxSource.PlayOneShot(sfxClips[sfxIndex]);
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }
    }
}
