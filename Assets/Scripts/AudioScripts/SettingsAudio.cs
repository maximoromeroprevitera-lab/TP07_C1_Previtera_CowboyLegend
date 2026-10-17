using UnityEngine;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSfxVolume();

        // Los logs dicen qué slider se movió y cómo quedó cada parámetro del mixer.
        musicSlider.onValueChanged.AddListener(v =>
        {
            AudioManager.Instance.SetMusicVolume(v);
            LogState("MUSIC slider", musicSlider);
        });

        sfxSlider.onValueChanged.AddListener(v =>
        {
            AudioManager.Instance.SetSfxVolume(v);
            LogState("SFX slider", sfxSlider);
        });
    }

    private void LogState(string label, Slider slider)
    {
        Debug.Log($"{label} movido (objeto: {slider.name}) | MusicVolume = {AudioManager.Instance.GetMusicVolume():F2} | " +
                  $"SFXVolume = {AudioManager.Instance.GetSfxVolume():F2}", slider);
    }
}