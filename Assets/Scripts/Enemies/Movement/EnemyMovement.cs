using UnityEngine;

namespace Enemies.Movement
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float minMovementSpeed = 3;
        [SerializeField] private float maxMovementSpeed = 5;
        [SerializeField] private float spreadAngle = 45;
        [SerializeField] private float forceMagnitude = 1f;

        protected float MovementSpeed;
        private Vector3 _direction;
        private Rigidbody2D _rb;
        protected Transform target;

        public Transform Target
        {
            set { target = value; }
        }

        protected virtual void Start()
        {
            // Генерируем случайную скорость и направление
            MovementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed);
            _direction = ChooseRandomDirection();

            _rb = GetComponent<Rigidbody2D>();
            _rb.AddForce(_direction * forceMagnitude, ForceMode2D.Impulse);
        }

        protected virtual void Update()
        {
            transform.Translate(_direction * (MovementSpeed * Time.deltaTime));
        }

        protected virtual Vector3 ChooseRandomDirection()
        {
            Vector3 direction;
            Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            center.z = transform.position.z;
            Vector3 targetDirection = center - transform.position;
            float angle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            direction = rotation * targetDirection.normalized;
            return direction;
        }
    }
}