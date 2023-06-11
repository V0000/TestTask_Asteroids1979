using Ship;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private bool playerIsTarget = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health healthComponent = collision.GetComponent<Health>();
        if (healthComponent != null)
        {
            bool isPlayer = collision.GetComponent<SpaceshipMovement>() != null;
            if (playerIsTarget)
            {
                if (isPlayer)
                {
                    HitEnemy(healthComponent);
                }
            }
            else
            {
                if (!isPlayer)
                {
                    HitEnemy(healthComponent);
                }
            }
        }
    }

    private void HitEnemy(Health enemyHealth)
    {
        enemyHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}