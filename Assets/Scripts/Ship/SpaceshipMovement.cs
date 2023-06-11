using UnityEngine;

namespace Ship
{
    public class SpaceshipMovement : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 180f;
        [SerializeField] private float acceleration = 5f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float drag = 0.5f;

        private Rigidbody2D _rb;
        private Camera _mainCamera;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            // Вращение корабля
            float rotationInput = Input.GetAxis("Horizontal");
            _rb.rotation -= rotationInput * rotationSpeed * Time.fixedDeltaTime;

            // Движение вперед и назад
            float forwardInput = Input.GetAxis("Vertical");
            Vector2 forwardForce = transform.up * forwardInput * acceleration;
            _rb.AddForce(forwardForce);
        
            // Инерция
            _rb.velocity *= (1f - drag * Time.fixedDeltaTime);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);

            // Ограничение движения границами экрана
            Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
            viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
            viewportPosition.y = Mathf.Clamp01(viewportPosition.y);
            transform.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
        }
    }
}
