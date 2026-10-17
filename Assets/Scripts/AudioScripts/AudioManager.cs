using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Audio Mixer")]
    public AudioMixer mixer;
    [Header("Music")]
    public AudioSource musicSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;

    [Header("Sound Effects")]
    public AudioSource SfxSource;
    public AudioClip shootSound;
    public AudioClip playerHitSound;
    public AudioClip enemyHitSound;
    public AudioClip jumpSound;
    public AudioClip enemyDeathSound;
    public AudioClip gameOverSound;
    public AudioClip buttonSound;

    [Header("Running Sound")]
    public AudioSource runSource;
    public AudioClip runSound;
    private void Awake()
    {
        Instance = this;
        musicSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
        SfxSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        runSource.outputAudioMixerGroup = SfxSource.outputAudioMixerGroup;
    }
    private void Start()
    {
        AudioClip clip = SceneManager.GetActiveScene().name == "MainMenu" ? mainMenuMusic : gameplayMusic;

        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    private float GetVolume(string param) =>
        mixer.GetFloat(param, out float db) ? Mathf.Pow(10f, db / 20f) : 1f;
    private void SetVolume(string param, float value) =>
        mixer.SetFloat(param, Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
    public float GetMusicVolume() => GetVolume("MusicVolume");
    public float GetSfxVolume() => GetVolume("SFXVolume");
    public void SetMusicVolume(float value) => SetVolume("MusicVolume", value);
    public void SetSfxVolume(float value) => SetVolume("SFXVolume", value);

    public void PlayShoot() => SfxSource.PlayOneShot(shootSound);
    public void PlayPlayerHit() => SfxSource.PlayOneShot(playerHitSound);
    public void PlayEnemyHit() => SfxSource.PlayOneShot(enemyHitSound);
    public void PlayJump() => SfxSource.PlayOneShot(jumpSound);
    public void PlayEnemyDeath() => SfxSource.PlayOneShot(enemyDeathSound);
    public void PlayButton() => SfxSource.PlayOneShot(buttonSound);
    public void PlayGameOver()
    {
        musicSource.Stop();
        SfxSource.PlayOneShot(gameOverSound);
    }
    public void StartRunning()
    {
        if (runSound != null && !runSource.isPlaying)
        {
            runSource.clip = runSound;
            runSource.loop = true;
            runSource.Play();
        }
    }
    public void StopRunning() => runSource.Stop();
}