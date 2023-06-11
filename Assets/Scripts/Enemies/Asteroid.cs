using UnityEngine;

namespace Enemies
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float minSize = 2f;
        [SerializeField] private float maxSize = 3f;

        private Rigidbody2D _rb;
        private void Start()
        {
            //делаем рандомный размер
            float size = Random.Range(minSize, maxSize);
            transform.localScale = new Vector3(size, size, size);
        
            //делаем массу такую же как размер
            _rb = GetComponent<Rigidbody2D>();
            _rb.mass = size;
        }
    }
}
