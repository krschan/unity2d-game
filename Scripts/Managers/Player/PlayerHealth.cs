using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invulnerabilityTime = 1f; // Invulnerability time after taking damage
    private int currentHealth;
    private bool isInvulnerable;
    private float invulnerabilityTimer;

    private void Start()
    {
        currentHealth = maxHealth;
        isInvulnerable = false;
        UpdateUI();
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer -= Time.deltaTime;
            if (invulnerabilityTimer <= 0)
            {
                isInvulnerable = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0 || isInvulnerable) return;

        currentHealth -= damage;
        isInvulnerable = true;
        invulnerabilityTimer = invulnerabilityTime;
        
        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateUI()
    {
        CanvasManager.Instance.UpdateHealthUI(currentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}