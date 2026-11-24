using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    // Warning: Instance es un campo public con set libre, cualquier script puede pisarlo.
    // Usá public static AudioManager Instance { get; private set; } y destruí el duplicado en Awake si ya hay uno.
    public static AudioManager Instance;
    [Header("Audio Mixer")]
    // Warning: mixer, las tres AudioSource y todos los AudioClip son public. Pasalos a [SerializeField] private, ninguna otra clase los usa.
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
        // Warning: FindMatchingGroups("Music")[0] asume que la búsqueda devuelve al menos un grupo, y en Master.mixer los grupos se llaman "MusicVolume" y "SFXVolume".
        // Si no encuentra nada tira IndexOutOfRangeException en Awake. Serializá los AudioMixerGroup y asignalos por inspector.
        musicSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
        SfxSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        runSource.outputAudioMixerGroup = SfxSource.outputAudioMixerGroup;
    }
    private void Start()
    {
        // Warning: "MainMenu" es un string mágico. Usá una constante compartida con el resto de los nombres de escena.
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