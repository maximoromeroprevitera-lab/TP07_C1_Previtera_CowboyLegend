using UnityEngine;
public class EnemyHealthBar : MonoBehaviour
{
    // Error: La barra de vida es un SpriteRenderer escalado por Transform (HealthBar y Fill en Enemy.prefab), no un Canvas en World Space como pide la consigna.
    // Armá un Canvas con Render Mode World Space como hijo del enemigo y usá una Image con fillAmount.
    [SerializeField] private Transform fill;
    private Vector3 originalScale;
    private void Start()
    {
        originalScale = fill.localScale;
    }
    public void SetHealth(float currentHealth, float maxHealth)
    {
        float healthPercent = currentHealth / maxHealth;

        fill.localScale = new Vector3(
            originalScale.x * healthPercent,
            originalScale.y,
            originalScale.z
        );
    }
}