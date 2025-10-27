using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider uiSlider; // asignar prefab slider en cada jugador

    void Start()
    {
        currentHealth = maxHealth;
        if (uiSlider) uiSlider.maxValue = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateUI();
        if (currentHealth == 0) Die();
    }

    void UpdateUI()
    {
        if (uiSlider) uiSlider.value = currentHealth;
    }

    void Die()
    {
        // desactivar jugador (visual, física, etc)
        gameObject.SetActive(false);
        // notificar GameManager
        GameManager.Instance.PlayerDied(this.gameObject);
    }
}
