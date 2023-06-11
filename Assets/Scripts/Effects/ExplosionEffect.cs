using System.Collections;
using UnityEngine;

namespace Effects
{
    public class ExplosionEffect : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            _particleSystem.Play();
            StartCoroutine(WaitForEffectCompletion());
        }

        private IEnumerator WaitForEffectCompletion()
        {
            while (_particleSystem.isPlaying)
            {
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}