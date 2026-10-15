using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Music")]
    public AudioSource musicSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
    [Header("Sound Effects")]
    public AudioSource sfxSource;
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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Start()
    {
        PlaySceneMusic(SceneManager.GetActiveScene().name);
        TestSound();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);
    }
    private void PlaySceneMusic(string sceneName)
    {
        AudioClip clip = null;

        if (sceneName == "MainMenu")
        {
            clip = mainMenuMusic;
        }
        else if (sceneName == "Game")
        {
            clip = gameplayMusic;
        }

        if (musicSource.clip == clip)
        {
            if (clip != null && !musicSource.isPlaying)
            {
                musicSource.Play();
            }

            return;
        }

        musicSource.Stop();
        musicSource.clip = clip;

        if (clip != null)
        {
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlayShoot()
    {
        sfxSource.PlayOneShot(shootSound);
    }
    public void PlayPlayerHit()
    {
        sfxSource.PlayOneShot(playerHitSound);
    }
    public void PlayEnemyHit()
    {
        sfxSource.PlayOneShot(enemyHitSound);
    }
    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }
    public void PlayEnemyDeath()
    {
        sfxSource.PlayOneShot(enemyDeathSound);
    }
    public void PlayGameOver()
    {
        musicSource.Stop();
        sfxSource.PlayOneShot(gameOverSound);
    }
    public void PlayButton()
    {
        if (sfxSource != null && sfxSource.isActiveAndEnabled && buttonSound != null)
        {
            sfxSource.PlayOneShot(buttonSound);
        }
        else
        {
            Debug.LogError("SFX Source is disabled or Button Sound is missing!");
        }
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
    public void StopRunning()
    {
        runSource.Stop();
    }
    public void TestSound()
    {
        Debug.Log("Testing sound");

        if (sfxSource != null && shootSound != null)
        {
            sfxSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogError("SFX Source or Shoot Sound is missing!");
        }
    }
}
