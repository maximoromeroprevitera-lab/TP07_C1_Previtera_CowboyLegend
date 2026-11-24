using UnityEngine;
public class SettingsMenu : MonoBehaviour
{
    // Warning: settingsPanel y mainPanel son public. Pasalos a [SerializeField] private.
    public GameObject settingsPanel;
    public GameObject mainPanel;
    public void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
