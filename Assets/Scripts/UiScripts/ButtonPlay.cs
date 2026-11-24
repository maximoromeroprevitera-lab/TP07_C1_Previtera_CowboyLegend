using UnityEngine;
using UnityEngine.SceneManagement;
// Suggestion: using UnityEngine.Audio no se usa en este archivo, borralo.
using UnityEngine.Audio;

public class ButtonPlay : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
