using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float stompThreshold = 0.5f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth == null) return;

        // Get the contact point
        ContactPoint2D contact = collision.GetContact(0);
        
        // Check if the player is above the ghost (stomping)
        bool isStomping = contact.normal.y < -stompThreshold;

        if (!isStomping)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}