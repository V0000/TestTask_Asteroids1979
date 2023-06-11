using UnityEngine;

namespace Weapons.Projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifespan = 5f;
        
        private float _timer;
        void Update()
        {
            _timer += Time.deltaTime;
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
            
            if (_timer >= lifespan)
            {
                Destroy(gameObject);
            }
        }
    }
}
