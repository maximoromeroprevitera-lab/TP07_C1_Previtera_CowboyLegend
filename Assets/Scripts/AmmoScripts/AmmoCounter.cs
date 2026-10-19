using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText;

    private PlayerAmmo playerAmmo;

    private void Start()
    {
        playerAmmo = FindFirstObjectByType<PlayerAmmo>();
    }

    private void Update()
    {
        if (playerAmmo == null) return;

        ammoText.text = playerAmmo.CurrentBullets + " / " + playerAmmo.ReserveBullets;
    }
}