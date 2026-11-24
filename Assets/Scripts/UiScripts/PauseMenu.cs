using UnityEngine;
// Error: La clase Pausemenu está en un archivo que se llama distinto (PauseMenu.cs, difiere en mayúsculas).
// Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
public class Pausemenu : MonoBehaviour
{
    // Warning: Pausepanel, Settingspanel y Creditspanel son public y no siguen camelCase. Usá [SerializeField] private GameObject pausePanel;
    public GameObject Pausepanel;
    public GameObject Settingspanel;
    public GameObject Creditspanel;
    private void Update()
    {
        // Bug: Escape funciona aunque el GameOverPanel o el victoryPanel estén activos. Resume pone Time.timeScale = 1f y el juego sigue corriendo detrás del panel.
        // Ignorá el input de pausa cuando el juego terminó (exponé un estado desde GameManager y VictoryManager).
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausepanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Pausepanel.SetActive(true);
        Settingspanel.SetActive(false);
        Creditspanel.SetActive(false);

        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Pausepanel.SetActive(false);
        Settingspanel.SetActive(false);
        Creditspanel.SetActive(false);

        Time.timeScale = 1f;
    }
    public void OpenSettings()
    {
        Pausepanel.SetActive(false);
        Settingspanel.SetActive(true);
        Creditspanel.SetActive(false);
    }
    public void OpenCredits()
    {
        Pausepanel.SetActive(false);
        Settingspanel.SetActive(false);
        Creditspanel.SetActive(true);
    }
    public void Back()
    {
        Pausepanel.SetActive(true);
        Settingspanel.SetActive(false);
        Creditspanel.SetActive(false);
    }
}
