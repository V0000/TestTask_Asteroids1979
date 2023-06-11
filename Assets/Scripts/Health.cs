using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected bool godMode = false;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float destroyDistance = 15f;
    [SerializeField] private int pointsForKill = 1;
    [SerializeField] protected ParticleSystem destroyEffect;
    private int _currentHealth;

    public delegate void EnemyDestroyed(int amount);

    public static event EnemyDestroyed OnEnemyDestroyed;

    protected virtual void Start()
    {
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        float distance = transform.position.magnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnKillThisObject();
        }
    }

    protected virtual void OnKillThisObject()
    {
        OnEnemyDestroyed?.Invoke(pointsForKill);
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        if (!godMode)
        {
            Destroy(gameObject);
        }
    }
}